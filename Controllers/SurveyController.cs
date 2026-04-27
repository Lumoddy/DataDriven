using System.Data;
using DataDriven.Data;
using DataDriven.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;

namespace DataDriven.Controllers;

[Route("survey")]
public class SurveyController(
    IConfiguration configuration,
    IDatabaseProcedureService procedureService,
    ILogger<SurveyController> logger) : Controller
{
    [Route("{surveyId}/{surveyPageIndex}")]
    public async Task<IActionResult> Page(
        [FromRoute] string surveyId,
        [FromRoute] string surveyPageIndex)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue)
            || surveyIdValue < 0
            || !int.TryParse(surveyPageIndex, out int surveyPageIndexValue)
            || surveyPageIndexValue < 0)
            return NotFound();

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        byte[] sessionTokenValue = new byte[32];

        SurveyPageModel? page = null;

        bool start_new_session
            = !Request.Cookies.TryGetValue("session", out string? sessionToken)
            || !Convert.TryFromBase64String(sessionToken, sessionTokenValue, out int bytesWritten)
            || bytesWritten != 32;

        if (!start_new_session)
        {
            page = await procedureService.QuerySurveyPageModel(
                connection,
                surveyIdValue,
                surveyPageIndexValue,
                sessionTokenValue);

            if (page == null && surveyPageIndexValue == 0)
                start_new_session = true;
        }

        if (start_new_session)
        {
            if (surveyPageIndexValue > 0)
            {
                logger.LogError(
                    "Invalid or expired session, cannot create a new one mid-way through survey.");
                return BadRequest();
            }

            sessionTokenValue = await procedureService.StartSurveySession(
                connection,
                surveyIdValue);

            sessionToken = Convert.ToBase64String(sessionTokenValue);

            Response.Cookies.Append("session", sessionToken);

            page = await procedureService.QuerySurveyPageModel(
                connection,
                surveyIdValue,
                surveyPageIndexValue,
                sessionTokenValue);
        }

        if (page == null)
            return NotFound();

        if (Request.HasFormContentType)
        {
            IFormCollection form = await Request.ReadFormAsync();

            List<IReadOnlyList<object?>> postedAnswers = [];

            foreach ((int questionIndex, ISurveyQuestionModel question) in page.Questions)
            {
                switch (question)
                {
                    case SurveyQuestionSmallTextModel smallText:
                    {
                        string? answer = form.TryGetValue(
                            $"question-{questionIndex}",
                            out StringValues rawAnswerValues)
                            ? rawAnswerValues.FirstOrDefault()
                            : null;

                        postedAnswers.Add([answer]);

                        break;
                    }
                    case SurveyQuestionCheckboxModel checkbox:
                    {
                        bool answer = form.ContainsKey(
                            $"question-{questionIndex}");

                        postedAnswers.Add([answer]);

                        break;
                    }
                    case SurveyQuestionRadioModel radio:
                    {
                        string? rawAnswer = form.TryGetValue(
                            $"question-{questionIndex}",
                            out StringValues rawAnswerValues)
                            ? rawAnswerValues.FirstOrDefault()
                            : null;

                        int? answer = int.TryParse(
                            rawAnswer,
                            out int integerAnswer)
                            && integerAnswer >= 0
                            && integerAnswer < radio.Options.Count
                            ? integerAnswer
                            : null;

                        postedAnswers.Add([answer]);

                        break;
                    }
                    case SurveyQuestionRadioOrOtherModel radio:
                    {
                        string? rawAnswer = form.TryGetValue(
                            $"question-{questionIndex}",
                            out StringValues rawAnswerValues)
                            ? rawAnswerValues.FirstOrDefault()
                            : null;

                        if (rawAnswer == "other")
                        {
                            string? answer = form.TryGetValue(
                                $"question-{questionIndex}-text",
                                out StringValues answerValues)
                                ? answerValues.FirstOrDefault()
                                : null;

                            postedAnswers.Add([answer]);
                        }
                        else
                        {
                            int? answer = int.TryParse(
                                rawAnswer,
                                out int integerAnswer)
                                && integerAnswer >= 0
                                && integerAnswer < radio.Options.Count
                                ? integerAnswer
                                : null;

                            postedAnswers.Add([answer]);
                        }

                        break;
                    }
                    case SurveyQuestionMultiSelectModel multiSelect:
                    {
                        IEnumerable<bool> answer = multiSelect.Options
                            .Select((_, i) => form.ContainsKey(
                                $"question-{questionIndex}-{i}"));

                        postedAnswers.Add([.. answer.Cast<object>()]);

                        break;
                    }
                    case SurveyQuestionMultiSelectAndOtherModel multiSelect:
                    {
                        string? textAnswer = form.ContainsKey(
                            $"question-{questionIndex}-other")
                            ? form.TryGetValue(
                                $"question-{questionIndex}-other-text",
                                out StringValues answerValues)
                                ? answerValues.FirstOrDefault()
                                : null
                            : null;

                        IEnumerable<bool> answer = multiSelect.Options
                            .Select((_, i) => form.ContainsKey(
                                $"question-{questionIndex}-{i}"));

                        postedAnswers.Add([textAnswer, .. answer]);

                        break;
                    }
                }
            }

            var errors = await procedureService.SubmitSurveyPageModel(
                connection,
                surveyIdValue,
                surveyPageIndexValue,
                sessionTokenValue,
                postedAnswers);

            if (errors != null)
            {
                bool foundError = false;
                foreach ((int questionIndex, int failedConditionIndex) in errors)
                {
                    Console.WriteLine($"{questionIndex}, {failedConditionIndex}");
                    foundError = true;
                }

                if (foundError)
                    return BadRequest();
            }

            surveyPageIndexValue += 1;

            if (surveyPageIndexValue == page.Parent!.PageCount)
            {
                return RedirectToAction(
                    nameof(FinalPage),
                    new { surveyId = surveyIdValue });
            }

            return RedirectToAction(
                nameof(Page),
                new
                {
                    surveyId = surveyIdValue,
                    surveyPageIndex = surveyPageIndexValue,
                });
        }

        return View(page);
    }

    [Route("{surveyId}")]
    public async Task<IActionResult> StartPage(
        [FromRoute] string surveyId)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue)
            || surveyIdValue < 0)
            return NotFound();

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        SurveyModel? survey = await procedureService.QuerySurvey(
            connection,
            surveyIdValue);

        if (survey == null)
            return NotFound();

        return View("StartPage", survey);
    }

    [Route("{surveyId}/done")]
    public async Task<IActionResult> FinalPage(
        [FromRoute] string surveyId)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue)
            || surveyIdValue < 0)
            return NotFound();

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        byte[] sessionTokenValue = new byte[32];

        if (!Request.Cookies.TryGetValue("session", out string? sessionToken)
            || !Convert.TryFromBase64String(sessionToken, sessionTokenValue, out int bytesWritten)
            || bytesWritten != 32)
            return NotFound();

        SurveyModel? survey = await procedureService.QuerySurvey(
            connection,
            surveyIdValue);

        if (survey == null)
            return NotFound();

        int? submissionIndex = await procedureService.SaveSurveySubmission(
            connection,
            surveyIdValue,
            sessionTokenValue);

        if (submissionIndex == null)
            return BadRequest();

        ViewData["index"] = submissionIndex.Value;
        return View("FinalPage", survey);
    }
}
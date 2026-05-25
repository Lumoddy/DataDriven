using System.Data;
using System.Net;
using System.Net.Sockets;
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

                        postedAnswers.Add([.. answer]);

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
                    nameof(RegisterPage),
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

        return View(survey);
    }

    [HttpGet]
    [Route("{surveyId}/done")]
    public async Task<IActionResult> RegisterPage(
        [FromRoute] string surveyId,
        [FromQuery] int? submissionIndex = null)
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

        if (!submissionIndex.HasValue)
        {
            byte[] sessionTokenValue = new byte[32];

            if (Request.Cookies.TryGetValue("session", out string? sessionToken)
                && Convert.TryFromBase64String(sessionToken, sessionTokenValue, out int bytesWritten)
                && bytesWritten == 32)
            {
                IPAddress address = Request.HttpContext.Connection.RemoteIpAddress!.MapToIPv4();
                byte[] buffer = [0, 0, 0, 0];
                address.TryWriteBytes(buffer.AsSpan(), out _);

                ulong intAddress
                    = ((ulong)buffer[0] << 24)
                    | ((ulong)buffer[1] << 16)
                    | ((ulong)buffer[2] << 8)
                    | ((ulong)buffer[3] << 0);

                submissionIndex = await procedureService.SaveSurveySubmission(
                    connection,
                    surveyIdValue,
                    sessionTokenValue,
                    intAddress);
            }
        }

        if (!submissionIndex.HasValue)
        {
            ViewData["index"] = null;
            return View("ReceiptPage", survey);
        }

        ViewData["index"] = submissionIndex.Value;
        return View("RegisterPage", survey);
    }

    [HttpPost]
    [Route("{surveyId}/done")]
    public async Task<IActionResult> RegisterPage(
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

        IFormCollection form = await Request.ReadFormAsync();
        if (!int.TryParse(form["submission_index"], out int submissionIndex))
            return NotFound();

        string? actionType = form.TryGetValue("action", out StringValues actionValue)
            ? actionValue.FirstOrDefault()
            : null;

        int? registeredMemberId = null;

        if (actionType == "register")
        {
            string? firstName = form.TryGetValue("first_name", out StringValues firstNameValue)
                ? firstNameValue.FirstOrDefault()
                : null;
            string? lastName = form.TryGetValue("last_name", out StringValues lastNameValue)
                ? lastNameValue.FirstOrDefault()
                : null;
            string? phoneNumber = form.TryGetValue("phone_number", out StringValues phoneValue)
                ? phoneValue.FirstOrDefault()
                : null;
            string? birthDateStr = form.TryGetValue("birth_date", out StringValues birthDateValue)
                ? birthDateValue.FirstOrDefault()
                : null;
            string? password = form.TryGetValue("password", out StringValues passwordValue)
                ? passwordValue.FirstOrDefault()
                : null;
            string? confirmPassword = form.TryGetValue("password_confirm", out StringValues confirmPasswordValue)
                ? confirmPasswordValue.FirstOrDefault()
                : null;

            if (string.IsNullOrWhiteSpace(firstName)
                || string.IsNullOrWhiteSpace(lastName)
                || string.IsNullOrWhiteSpace(phoneNumber)
                || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(confirmPassword)
                || !DateTime.TryParse(birthDateStr, out DateTime birthDate))
            {
                ViewData["memberError"] = "Please fill in all required fields.";
                ViewData["index"] = submissionIndex;
                return View("RegisterPage", survey);
            }

            if (password != confirmPassword)
            {
                ViewData["memberError"] = "Passwords do not match.";
                ViewData["index"] = submissionIndex;
                return View("RegisterPage", survey);
            }

            string passwordHash = Data.PasswordHasher.HashPassword(password);
            registeredMemberId = await procedureService.RegisterMember(
                connection,
                firstName,
                lastName,
                phoneNumber,
                birthDate,
                passwordHash);

            if (registeredMemberId == null)
            {
                ViewData["memberError"] = "Phone number is already registered. Please login instead.";
                ViewData["index"] = submissionIndex;
                return View("RegisterPage", survey);
            }
        }
        else if (actionType == "login")
        {
            string? phoneNumber = form.TryGetValue("phone_number", out StringValues phoneValue)
                ? phoneValue.FirstOrDefault()
                : null;
            string? password = form.TryGetValue("password", out StringValues passwordValue)
                ? passwordValue.FirstOrDefault()
                : null;

            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(password))
            {
                ViewData["memberError"] = "Please enter phone number and password.";
                ViewData["index"] = submissionIndex;
                return View("RegisterPage", survey);
            }

            var authResult = await procedureService.AuthenticateMember(
                connection,
                phoneNumber);

            if (authResult != null
                && !string.IsNullOrEmpty(authResult.PasswordHash)
                && Data.PasswordHasher.VerifyPassword(password, authResult.PasswordHash))
            {
                registeredMemberId = authResult.MemberId;
            }
            else
            {
                ViewData["memberError"] = "Invalid phone number or password.";
                ViewData["index"] = submissionIndex;
                return View("RegisterPage", survey);
            }
        }
        else
        {
            ViewData["memberError"] = "Unknown action.";
            ViewData["index"] = submissionIndex;
            return View("RegisterPage", survey);
        }

        if (registeredMemberId.HasValue)
        {
            bool linked = await procedureService.LinkSubmissionToMember(
                connection,
                surveyIdValue,
                submissionIndex,
                registeredMemberId.Value);

            if (!linked)
            {
                ViewData["memberError"] = "Unable to link the member account to the submission.";
                ViewData["index"] = submissionIndex;
                return View("RegisterPage", survey);
            }
        }

        return RedirectToAction(
            nameof(ReceiptPage),
            new { surveyId = surveyIdValue, submissionIndex });
    }

    [Route("{surveyId}/receipt")]
    public async Task<IActionResult> ReceiptPage(
        [FromRoute] string surveyId,
        [FromQuery] int? submissionIndex)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue)
            || surveyIdValue < 0)
            return NotFound();

        if (!submissionIndex.HasValue)
            return NotFound();

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));
        await connection.OpenAsync();

        SurveyModel? survey = await procedureService.QuerySurvey(
            connection,
            surveyIdValue);

        if (survey == null)
            return NotFound();

        ViewData["index"] = submissionIndex.Value;
        return View("ReceiptPage", survey);
    }
}
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using DataDriven.Data;
using DataDriven.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataDriven.Controllers;

[Route("staff")]
public class StaffController(
    IConfiguration configuration,
    IDatabaseProcedureService procedureService) : Controller
{
    [Route("")]
    public async Task<IActionResult> Index()
    {
        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        return View(await procedureService.QuerySurveys(connection));
    }

    [Route("search/{surveyId}")]
    public async Task<IActionResult> Search(
        [FromRoute] string surveyId)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue)
            || surveyIdValue < 0)
            return NotFound();

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        SurveyModel? survey = await procedureService.QuerySurveyModel(connection, surveyIdValue);

        if (survey == null)
            return NotFound();

        SqlCommand command = new(
            """
            SELECT * FROM
                [submission_answers_view]
            WHERE
                [submission_answers_view].[survey_id]
                    = @survey_id
            ORDER BY
                [submission_answers_view].[submission_index] ASC,
                [submission_answers_view].[survey_page_index] ASC,
                [submission_answers_view].[survey_question_index] ASC,
                [submission_answers_view].[submission_answer_index] ASC;
            """,
            connection);

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;

        SqlDataReader reader = await command.ExecuteReaderAsync();

        Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object?>>>> submissions = [];

        while (await reader.ReadAsync())
        {
            int submissionIndex = reader.GetSqlInt32(3).StrictValue();
            int pageIndex = reader.GetSqlInt32(1).StrictValue();
            int questionIndex = reader.GetSqlInt32(2).StrictValue();
            int answerIndex = reader.GetSqlInt32(4).StrictValue();

            if (!submissions.TryGetValue(
                submissionIndex,
                out Dictionary<int, Dictionary<int, Dictionary<int, object?>>>? page))
            {
                page = [];
                submissions.Add(submissionIndex, page);
            }

            if (!page.TryGetValue(
                pageIndex,
                out Dictionary<int, Dictionary<int, object?>>? question))
            {
                question = [];
                page.Add(pageIndex, question);
            }

            if (!question.TryGetValue(
                questionIndex,
                out Dictionary<int, object?>? answers))
            {
                answers = [];
                question.Add(questionIndex, answers);
            }

            int? integerArg = reader.GetSqlInt32(5).CheckedValue();

            string? textArg = reader.GetSqlString(6).CheckedValue();

            answers.Add(
                answerIndex,
                (integerArg, textArg) switch
                {
                    (int i, null) => i,
                    (null, string s) => s,
                    (null, null) => null,
                    _ => throw new InvalidDataException(
                        $"Answer has mixed type in submission '" +
                        $"{submissionIndex}' survey id " +
                        $"'{surveyId}' page '{pageIndex}' question '" +
                        $"{questionIndex}' argument '{answerIndex}'."),
                });
        }

        ViewData["answers"] = submissions.Keys.Select((submissionToken) =>
        {
            var pages = submissions[submissionToken];

            return survey.Pages!.Select((page, pageIndex) =>
            {
                var questions = pages.GetValueOrDefault(pageIndex);

                return page.Questions.OrderBy((x) => x.Key).Select<
                    KeyValuePair<int, ISurveyQuestionModel>,
                    ISurveyQuestionAnswer>((pair) =>
                {
                    (int questionIndex, ISurveyQuestionModel? question) = pair;

                    var answers = questions?.GetValueOrDefault(questionIndex);

                    switch (question)
                    {
                        case SurveyQuestionSmallTextModel smallText:
                        {
                            return new SurveyQuestionSmallTextAnswer(
                                smallText,
                                answers?[0] as string ?? "");
                        }
                        case SurveyQuestionCheckboxModel checkbox:
                        {
                            return new SurveyQuestionCheckboxAnswer(
                                checkbox,
                                answers?.ContainsKey(0) ?? false);
                        }
                        case SurveyQuestionRadioModel radio:
                        {
                            return new SurveyQuestionRadioAnswer(
                                radio,
                                answers?[0] as int?);
                        }
                        case SurveyQuestionRadioOrOtherModel radio:
                        {
                            return (SurveyQuestionRadioOrOtherAnswer)(answers?[0] switch
                            {
                                string x => new(radio, x),
                                int x => new(radio, x),
                                _ => new(radio),
                            });
                        }
                        case SurveyQuestionMultiSelectModel multiSelect:
                        {
                            return new SurveyQuestionMultiSelectAnswer(
                                multiSelect,
                                [.. Enumerable.Range(0, multiSelect.Options.Count)
                                    .Select((i) => answers?.ContainsKey(i) ?? false)]);
                        }
                        case SurveyQuestionMultiSelectAndOtherModel multiSelect:
                        {
                            return new SurveyQuestionMultiSelectAndOtherAnswer(
                                multiSelect,
                                [.. Enumerable.Range(0, multiSelect.Options.Count)
                                    .Select((i) => answers?.ContainsKey(i + 1) ?? false)],
                                answers?.GetValueOrDefault(0) as string);
                        }
                        default:
                        {
                            throw new UnreachableException();
                        }
                    }
                })
                    .ToArray();
            })
                .ToArray();
        })
            .ToArray();

        return View(survey);
    }
}
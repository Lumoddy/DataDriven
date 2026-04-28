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

    public class SessionTokenComparer : IEqualityComparer<byte[]>
    {
        public readonly static SessionTokenComparer Instance = new();

        public bool Equals(byte[]? x, byte[]? y)
        {
            switch ((x, y))
            {
                case (null, null): return true;
                case (byte[], null): return false;
                case (null, byte[]): return false;
                default:
                {
                    if (x.Length != y.Length)
                        return false;

                    for (int i = 0; i < x.Length; i += 1)
                    {
                        if (x[i] != y[i])
                            return false;
                    }

                    return true;
                }
            }
        }

        public int GetHashCode([DisallowNull] byte[] obj)
        {
            HashCode hash = new();
            hash.AddBytes(obj);
            return hash.ToHashCode();
        }
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
                [survey_session_answers_view]
            WHERE
                [survey_session_answers_view].[survey_id]
                    = @survey_id
            ORDER BY
                [survey_session_answers_view].[survey_session_token] ASC,
                [survey_session_answers_view].[survey_page_index] ASC,
                [survey_session_answers_view].[survey_question_index] ASC,
                [survey_session_answers_view].[survey_session_answer_index] ASC;
            """,
            connection);

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;

        SqlDataReader reader = await command.ExecuteReaderAsync();

        Dictionary<byte[], Dictionary<int, Dictionary<int, Dictionary<int, object?>>>> submission
            = new(SessionTokenComparer.Instance);

        while (await reader.ReadAsync())
        {
            byte[] sessionToken = reader.GetSqlBytes(3).StrictValue();
            int pageIndex = reader.GetSqlInt32(1).StrictValue();
            int questionIndex = reader.GetSqlInt32(2).StrictValue();
            int answerIndex = reader.GetSqlInt32(3).StrictValue();

            if (!submission.TryGetValue(
                sessionToken,
                out Dictionary<int, Dictionary<int, Dictionary<int, object?>>>? page))
            {
                page = [];
                submission.Add(sessionToken, page);
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
                        $"{Convert.ToHexString(sessionToken)}' survey id " +
                        $"'{surveyId}' page '{pageIndex}' question '" +
                        $"{questionIndex}' argument '{answerIndex}'."),
                });
        }

        ViewData["answers"] = submission.Keys.Select((submissionToken) =>
        {
            var pages = submission[submissionToken];

            return survey.Pages!.Select((page, pageIndex) =>
            {
                var questions = pages[pageIndex];

                return page.Questions.OrderBy((x) => x.Key).Select<
                    KeyValuePair<int, ISurveyQuestionModel>,
                    ISurveyQuestionAnswer>((pair) =>
                {
                    (int questionIndex, ISurveyQuestionModel? question) = pair;

                    var answers = questions[questionIndex];

                    switch (question)
                    {
                        case SurveyQuestionSmallTextModel smallText:
                        {
                            return new SurveyQuestionSmallTextAnswer(
                                smallText,
                                (string)answers[0]!);
                        }
                        case SurveyQuestionCheckboxModel checkbox:
                        {
                            return new SurveyQuestionCheckboxAnswer(
                                checkbox,
                                answers.ContainsKey(0));
                        }
                        case SurveyQuestionRadioModel radio:
                        {
                            return new SurveyQuestionRadioAnswer(
                                radio,
                                (int)answers[0]!);
                        }
                        case SurveyQuestionRadioOrOtherModel radio:
                        {
                            return answers[0] switch
                            {
                                string x => new SurveyQuestionRadioOrOtherAnswer(
                                    radio,
                                    x),
                                int x => new SurveyQuestionRadioOrOtherAnswer(
                                    radio,
                                    x),
                                _ => throw new UnreachableException(),
                            };
                        }
                        case SurveyQuestionMultiSelectModel multiSelect:
                        {
                            return new SurveyQuestionMultiSelectAnswer(
                                multiSelect,
                                [.. Enumerable.Range(0, multiSelect.Options.Count)
                                    .Select((i) => answers.ContainsKey(i))]);
                        }
                        case SurveyQuestionMultiSelectAndOtherModel multiSelect:
                        {
                            return new SurveyQuestionMultiSelectAndOtherAnswer(
                                multiSelect,
                                [.. Enumerable.Range(0, multiSelect.Options.Count)
                                    .Select((i) => answers.ContainsKey(i + 1))],
                                answers.GetValueOrDefault(0) as string);
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
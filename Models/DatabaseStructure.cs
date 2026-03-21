// This file was auto-generated based on ./Build/database/database_structure.yaml

using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial record Survey(
    int Id,
    string Name,
    string Description);

public record SqlSurvey(
    SqlInt32 SurveyId,
    SqlString Name,
    SqlString Description)
{
    public Survey Value => new(
        SurveyId.Value,
        Name.Value,
        Description.Value);

    public SqlSurvey(Survey data) : this(
        data.Id,
        data.Name,
        data.Description) { }

    public static explicit operator Survey(SqlSurvey value) => value.Value;
    public static implicit operator SqlSurvey(Survey value) => new(value);
}

public partial record SurveyPage(
    int SurveyId,
    int PageIndex,
    string Name,
    string Description);

public record SqlSurveyPage(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlString Name,
    SqlString Description)
{
    public SurveyPage Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        Name.Value,
        Description.Value);

    public SqlSurveyPage(SurveyPage data) : this(
        data.SurveyId,
        data.PageIndex,
        data.Name,
        data.Description) { }

    public static explicit operator SurveyPage(SqlSurveyPage value) => value.Value;
    public static implicit operator SqlSurveyPage(SurveyPage value) => new(value);
}

public partial record SurveyQuestion(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    string Prompt,
    byte AnswerType);

public record SqlSurveyQuestion(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlString Prompt,
    SqlByte AnswerType)
{
    public SurveyQuestion Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        Prompt.Value,
        AnswerType.Value);

    public SqlSurveyQuestion(SurveyQuestion data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Prompt,
        data.AnswerType) { }

    public static explicit operator SurveyQuestion(SqlSurveyQuestion value) => value.Value;
    public static implicit operator SqlSurveyQuestion(SurveyQuestion value) => new(value);
}

public partial record SurveyQuestionCondition(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int OtherPageIndex,
    int OtherQuestionIndex,
    string Condition);

public record SqlSurveyQuestionCondition(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 OtherSurveyPageIndex,
    SqlInt32 OtherSurveyQuestionIndex,
    SqlString Condition)
{
    public SurveyQuestionCondition Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        OtherSurveyPageIndex.Value,
        OtherSurveyQuestionIndex.Value,
        Condition.Value);

    public SqlSurveyQuestionCondition(SurveyQuestionCondition data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.OtherPageIndex,
        data.OtherQuestionIndex,
        data.Condition) { }

    public static explicit operator SurveyQuestionCondition(SqlSurveyQuestionCondition value) => value.Value;
    public static implicit operator SqlSurveyQuestionCondition(SurveyQuestionCondition value) => new(value);
}

public partial record SurveyAnswer(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int SurveySubmissionIndex,
    string AnswerValue);

public record SqlSurveyAnswer(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveySubmissionIndex,
    SqlString AnswerValue)
{
    public SurveyAnswer Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveySubmissionIndex.Value,
        AnswerValue.Value);

    public SqlSurveyAnswer(SurveyAnswer data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.SurveySubmissionIndex,
        data.AnswerValue) { }

    public static explicit operator SurveyAnswer(SqlSurveyAnswer value) => value.Value;
    public static implicit operator SqlSurveyAnswer(SurveyAnswer value) => new(value);
}

public partial record AnswerType(
    byte Id,
    string Name);

public record SqlAnswerType(
    SqlByte AnswerTypeId,
    SqlString Name)
{
    public AnswerType Value => new(
        AnswerTypeId.Value,
        Name.Value);

    public SqlAnswerType(AnswerType data) : this(
        data.Id,
        data.Name) { }

    public static explicit operator AnswerType(SqlAnswerType value) => value.Value;
    public static implicit operator SqlAnswerType(AnswerType value) => new(value);
}

public partial record RegisteredMember(
    int Id,
    string PhoneNumber,
    string PasswordHash,
    DateTime BirthDate,
    string FirstName,
    string LastName);

public record SqlRegisteredMember(
    SqlInt32 RegisteredMemberId,
    SqlString PhoneNumber,
    SqlString PasswordHash,
    SqlDateTime BirthDate,
    SqlString FirstName,
    SqlString LastName)
{
    public RegisteredMember Value => new(
        RegisteredMemberId.Value,
        PhoneNumber.Value,
        PasswordHash.Value,
        BirthDate.Value,
        FirstName.Value,
        LastName.Value);

    public SqlRegisteredMember(RegisteredMember data) : this(
        data.Id,
        data.PhoneNumber,
        data.PasswordHash,
        data.BirthDate,
        data.FirstName,
        data.LastName) { }

    public static explicit operator RegisteredMember(SqlRegisteredMember value) => value.Value;
    public static implicit operator SqlRegisteredMember(RegisteredMember value) => new(value);
}

public partial record SurveySubmission(
    int SurveyId,
    int Index,
    int? RegisteredMemberId);

public record SqlSurveySubmission(
    SqlInt32 SurveyId,
    SqlInt32 SurveySubmissionIndex,
    SqlInt32 RegisteredMemberId)
{
    public SurveySubmission Value => new(
        SurveyId.Value,
        SurveySubmissionIndex.Value,
        RegisteredMemberId.Value);

    public SqlSurveySubmission(SurveySubmission data) : this(
        data.SurveyId,
        data.Index,
        data.RegisteredMemberId ?? SqlInt32.Null) { }

    public static explicit operator SurveySubmission(SqlSurveySubmission value) => value.Value;
    public static implicit operator SqlSurveySubmission(SurveySubmission value) => new(value);
}

public class SqlDataDrivenDataAccess(
    SqlConnection source,
    bool sourceConsumed = true): IAsyncDisposable, IDisposable
{
    private const int VARCHAR_MAX_LENGTH = 2147483647;

    public SqlConnection Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    private SqlCommand SelectUniqueSqlSurveyCommand(
        SqlInt32 surveyId)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [name], [description] FROM [surveys] WHERE [survey_id] = @survey_id",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;

        return command;
    }

    public SqlSurvey? SelectUniqueSqlSurvey(
        SqlInt32 surveyId)
    {
        var command = SelectUniqueSqlSurveyCommand(
            surveyId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            Name: reader.GetSqlString(1),
            Description: reader.GetSqlString(2));
    }

    public Task<SqlSurvey?> SelectUniqueSqlSurveyAsync(
        SqlInt32 surveyId)
    {
        return SelectUniqueSqlSurveyAsync(
            surveyId,
            CancellationToken.None);
    }

    public async Task<SqlSurvey?> SelectUniqueSqlSurveyAsync(
        SqlInt32 surveyId,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyCommand(
            surveyId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            Name: reader.GetSqlString(1),
            Description: reader.GetSqlString(2));
    }

    private SqlCommand InsertSqlSurveyCommand(
        SqlInt32 surveyId,
        SqlString name,
        SqlString description)
    {
        var command = new SqlCommand(
            "INSERT INTO [surveys] ([survey_id], [name], [description]) VALUES (@survey_id, @name, @description)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("name", SqlDbType.VarChar, 255).SqlValue = name;
        command.Parameters.Add("description", SqlDbType.VarChar, VARCHAR_MAX_LENGTH).SqlValue = description;

        return command;
    }

    public void InsertSqlSurvey(SqlSurvey survey)
    {
        var command = InsertSqlSurveyCommand(
            survey.SurveyId,
            survey.Name,
            survey.Description);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyAsync(SqlSurvey survey)
        => InsertSqlSurveyAsync(survey, CancellationToken.None);

    public Task InsertSqlSurveyAsync(
        SqlSurvey survey,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyCommand(
            survey.SurveyId,
            survey.Name,
            survey.Description);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyPageCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [name], [description] FROM [survey_pages] WHERE [survey_id] = @survey_id AND [survey_page_index] = @survey_page_index",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;

        return command;
    }

    public SqlSurveyPage? SelectUniqueSqlSurveyPage(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex)
    {
        var command = SelectUniqueSqlSurveyPageCommand(
            surveyId,
            surveyPageIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            Name: reader.GetSqlString(2),
            Description: reader.GetSqlString(3));
    }

    public Task<SqlSurveyPage?> SelectUniqueSqlSurveyPageAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex)
    {
        return SelectUniqueSqlSurveyPageAsync(
            surveyId,
            surveyPageIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyPage?> SelectUniqueSqlSurveyPageAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyPageCommand(
            surveyId,
            surveyPageIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            Name: reader.GetSqlString(2),
            Description: reader.GetSqlString(3));
    }

    private SqlCommand InsertSqlSurveyPageCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlString name,
        SqlString description)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [name], [description]) VALUES (@survey_id, @survey_page_index, @name, @description)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("name", SqlDbType.VarChar, 1023).SqlValue = name;
        command.Parameters.Add("description", SqlDbType.VarChar, VARCHAR_MAX_LENGTH).SqlValue = description;

        return command;
    }

    public void InsertSqlSurveyPage(SqlSurveyPage surveyPage)
    {
        var command = InsertSqlSurveyPageCommand(
            surveyPage.SurveyId,
            surveyPage.SurveyPageIndex,
            surveyPage.Name,
            surveyPage.Description);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyPageAsync(SqlSurveyPage surveyPage)
        => InsertSqlSurveyPageAsync(surveyPage, CancellationToken.None);

    public Task InsertSqlSurveyPageAsync(
        SqlSurveyPage surveyPage,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyPageCommand(
            surveyPage.SurveyId,
            surveyPage.SurveyPageIndex,
            surveyPage.Name,
            surveyPage.Description);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [prompt], [answer_type] FROM [survey_questions] WHERE [survey_id] = @survey_id AND [survey_page_index] = @survey_page_index AND [survey_question_index] = @survey_question_index",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;

        return command;
    }

    public SqlSurveyQuestion? SelectUniqueSqlSurveyQuestion(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            Prompt: reader.GetSqlString(3),
            AnswerType: reader.GetSqlByte(4));
    }

    public Task<SqlSurveyQuestion?> SelectUniqueSqlSurveyQuestionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex)
    {
        return SelectUniqueSqlSurveyQuestionAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestion?> SelectUniqueSqlSurveyQuestionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            Prompt: reader.GetSqlString(3),
            AnswerType: reader.GetSqlByte(4));
    }

    private SqlCommand InsertSqlSurveyQuestionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlString prompt,
        SqlByte answerType)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [prompt], [answer_type]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @prompt, @answer_type)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("prompt", SqlDbType.VarChar, 1023).SqlValue = prompt;
        command.Parameters.Add("answer_type", SqlDbType.TinyInt).SqlValue = answerType;

        return command;
    }

    public void InsertSqlSurveyQuestion(SqlSurveyQuestion surveyQuestion)
    {
        var command = InsertSqlSurveyQuestionCommand(
            surveyQuestion.SurveyId,
            surveyQuestion.SurveyPageIndex,
            surveyQuestion.SurveyQuestionIndex,
            surveyQuestion.Prompt,
            surveyQuestion.AnswerType);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionAsync(SqlSurveyQuestion surveyQuestion)
        => InsertSqlSurveyQuestionAsync(surveyQuestion, CancellationToken.None);

    public Task InsertSqlSurveyQuestionAsync(
        SqlSurveyQuestion surveyQuestion,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionCommand(
            surveyQuestion.SurveyId,
            surveyQuestion.SurveyPageIndex,
            surveyQuestion.SurveyQuestionIndex,
            surveyQuestion.Prompt,
            surveyQuestion.AnswerType);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionConditionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 otherSurveyPageIndex,
        SqlInt32 otherSurveyQuestionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [other_survey_page_index], [other_survey_question_index], [condition] FROM [survey_question_conditions] WHERE [survey_id] = @survey_id AND [survey_page_index] = @survey_page_index AND [survey_question_index] = @survey_question_index AND [other_survey_page_index] = @other_survey_page_index AND [other_survey_question_index] = @other_survey_question_index",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("other_survey_page_index", SqlDbType.Int).SqlValue = otherSurveyPageIndex;
        command.Parameters.Add("other_survey_question_index", SqlDbType.Int).SqlValue = otherSurveyQuestionIndex;

        return command;
    }

    public SqlSurveyQuestionCondition? SelectUniqueSqlSurveyQuestionCondition(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 otherSurveyPageIndex,
        SqlInt32 otherSurveyQuestionIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionConditionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            otherSurveyPageIndex,
            otherSurveyQuestionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            OtherSurveyPageIndex: reader.GetSqlInt32(3),
            OtherSurveyQuestionIndex: reader.GetSqlInt32(4),
            Condition: reader.GetSqlString(5));
    }

    public Task<SqlSurveyQuestionCondition?> SelectUniqueSqlSurveyQuestionConditionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 otherSurveyPageIndex,
        SqlInt32 otherSurveyQuestionIndex)
    {
        return SelectUniqueSqlSurveyQuestionConditionAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            otherSurveyPageIndex,
            otherSurveyQuestionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionCondition?> SelectUniqueSqlSurveyQuestionConditionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 otherSurveyPageIndex,
        SqlInt32 otherSurveyQuestionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionConditionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            otherSurveyPageIndex,
            otherSurveyQuestionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            OtherSurveyPageIndex: reader.GetSqlInt32(3),
            OtherSurveyQuestionIndex: reader.GetSqlInt32(4),
            Condition: reader.GetSqlString(5));
    }

    private SqlCommand InsertSqlSurveyQuestionConditionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 otherSurveyPageIndex,
        SqlInt32 otherSurveyQuestionIndex,
        SqlString condition)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_conditions] ([survey_id], [survey_page_index], [survey_question_index], [other_survey_page_index], [other_survey_question_index], [condition]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @other_survey_page_index, @other_survey_question_index, @condition)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("other_survey_page_index", SqlDbType.Int).SqlValue = otherSurveyPageIndex;
        command.Parameters.Add("other_survey_question_index", SqlDbType.Int).SqlValue = otherSurveyQuestionIndex;
        command.Parameters.Add("condition", SqlDbType.VarChar, 255).SqlValue = condition;

        return command;
    }

    public void InsertSqlSurveyQuestionCondition(SqlSurveyQuestionCondition surveyQuestionCondition)
    {
        var command = InsertSqlSurveyQuestionConditionCommand(
            surveyQuestionCondition.SurveyId,
            surveyQuestionCondition.SurveyPageIndex,
            surveyQuestionCondition.SurveyQuestionIndex,
            surveyQuestionCondition.OtherSurveyPageIndex,
            surveyQuestionCondition.OtherSurveyQuestionIndex,
            surveyQuestionCondition.Condition);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionConditionAsync(SqlSurveyQuestionCondition surveyQuestionCondition)
        => InsertSqlSurveyQuestionConditionAsync(surveyQuestionCondition, CancellationToken.None);

    public Task InsertSqlSurveyQuestionConditionAsync(
        SqlSurveyQuestionCondition surveyQuestionCondition,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionConditionCommand(
            surveyQuestionCondition.SurveyId,
            surveyQuestionCondition.SurveyPageIndex,
            surveyQuestionCondition.SurveyQuestionIndex,
            surveyQuestionCondition.OtherSurveyPageIndex,
            surveyQuestionCondition.OtherSurveyQuestionIndex,
            surveyQuestionCondition.Condition);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveySubmissionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_submission_index], [answer_value] FROM [survey_answers] WHERE [survey_id] = @survey_id AND [survey_page_index] = @survey_page_index AND [survey_question_index] = @survey_question_index AND [survey_submission_index] = @survey_submission_index",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_submission_index", SqlDbType.Int).SqlValue = surveySubmissionIndex;

        return command;
    }

    public SqlSurveyAnswer? SelectUniqueSqlSurveyAnswer(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveySubmissionIndex)
    {
        var command = SelectUniqueSqlSurveyAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveySubmissionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveySubmissionIndex: reader.GetSqlInt32(3),
            AnswerValue: reader.GetSqlString(4));
    }

    public Task<SqlSurveyAnswer?> SelectUniqueSqlSurveyAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveySubmissionIndex)
    {
        return SelectUniqueSqlSurveyAnswerAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveySubmissionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyAnswer?> SelectUniqueSqlSurveyAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveySubmissionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveySubmissionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveySubmissionIndex: reader.GetSqlInt32(3),
            AnswerValue: reader.GetSqlString(4));
    }

    private SqlCommand InsertSqlSurveyAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveySubmissionIndex,
        SqlString answerValue)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_answers] ([survey_id], [survey_page_index], [survey_question_index], [survey_submission_index], [answer_value]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_submission_index, @answer_value)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_submission_index", SqlDbType.Int).SqlValue = surveySubmissionIndex;
        command.Parameters.Add("answer_value", SqlDbType.VarChar, 4095).SqlValue = answerValue;

        return command;
    }

    public void InsertSqlSurveyAnswer(SqlSurveyAnswer surveyAnswer)
    {
        var command = InsertSqlSurveyAnswerCommand(
            surveyAnswer.SurveyId,
            surveyAnswer.SurveyPageIndex,
            surveyAnswer.SurveyQuestionIndex,
            surveyAnswer.SurveySubmissionIndex,
            surveyAnswer.AnswerValue);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyAnswerAsync(SqlSurveyAnswer surveyAnswer)
        => InsertSqlSurveyAnswerAsync(surveyAnswer, CancellationToken.None);

    public Task InsertSqlSurveyAnswerAsync(
        SqlSurveyAnswer surveyAnswer,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyAnswerCommand(
            surveyAnswer.SurveyId,
            surveyAnswer.SurveyPageIndex,
            surveyAnswer.SurveyQuestionIndex,
            surveyAnswer.SurveySubmissionIndex,
            surveyAnswer.AnswerValue);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlAnswerTypeCommand(
        SqlByte answerTypeId)
    {
        var command = new SqlCommand(
            "SELECT [answer_type_id], [name] FROM [answer_types] WHERE [answer_type_id] = @answer_type_id",
            source);

        command.Parameters.Add("answer_type_id", SqlDbType.TinyInt).SqlValue = answerTypeId;

        return command;
    }

    public SqlAnswerType? SelectUniqueSqlAnswerType(
        SqlByte answerTypeId)
    {
        var command = SelectUniqueSqlAnswerTypeCommand(
            answerTypeId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            AnswerTypeId: reader.GetSqlByte(0),
            Name: reader.GetSqlString(1));
    }

    public Task<SqlAnswerType?> SelectUniqueSqlAnswerTypeAsync(
        SqlByte answerTypeId)
    {
        return SelectUniqueSqlAnswerTypeAsync(
            answerTypeId,
            CancellationToken.None);
    }

    public async Task<SqlAnswerType?> SelectUniqueSqlAnswerTypeAsync(
        SqlByte answerTypeId,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlAnswerTypeCommand(
            answerTypeId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            AnswerTypeId: reader.GetSqlByte(0),
            Name: reader.GetSqlString(1));
    }

    private SqlCommand InsertSqlAnswerTypeCommand(
        SqlByte answerTypeId,
        SqlString name)
    {
        var command = new SqlCommand(
            "INSERT INTO [answer_types] ([answer_type_id], [name]) VALUES (@answer_type_id, @name)",
            source);

        command.Parameters.Add("answer_type_id", SqlDbType.TinyInt).SqlValue = answerTypeId;
        command.Parameters.Add("name", SqlDbType.VarChar, 255).SqlValue = name;

        return command;
    }

    public void InsertSqlAnswerType(SqlAnswerType answerType)
    {
        var command = InsertSqlAnswerTypeCommand(
            answerType.AnswerTypeId,
            answerType.Name);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlAnswerTypeAsync(SqlAnswerType answerType)
        => InsertSqlAnswerTypeAsync(answerType, CancellationToken.None);

    public Task InsertSqlAnswerTypeAsync(
        SqlAnswerType answerType,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlAnswerTypeCommand(
            answerType.AnswerTypeId,
            answerType.Name);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlRegisteredMemberCommand(
        SqlInt32 registeredMemberId)
    {
        var command = new SqlCommand(
            "SELECT [registered_member_id], [phone_number], [password_hash], [birth_date], [first_name], [last_name] FROM [registered_members] WHERE [registered_member_id] = @registered_member_id",
            source);

        command.Parameters.Add("registered_member_id", SqlDbType.Int).SqlValue = registeredMemberId;

        return command;
    }

    public SqlRegisteredMember? SelectUniqueSqlRegisteredMember(
        SqlInt32 registeredMemberId)
    {
        var command = SelectUniqueSqlRegisteredMemberCommand(
            registeredMemberId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            RegisteredMemberId: reader.GetSqlInt32(0),
            PhoneNumber: reader.GetSqlString(1),
            PasswordHash: reader.GetSqlString(2),
            BirthDate: reader.GetSqlDateTime(3),
            FirstName: reader.GetSqlString(4),
            LastName: reader.GetSqlString(5));
    }

    public Task<SqlRegisteredMember?> SelectUniqueSqlRegisteredMemberAsync(
        SqlInt32 registeredMemberId)
    {
        return SelectUniqueSqlRegisteredMemberAsync(
            registeredMemberId,
            CancellationToken.None);
    }

    public async Task<SqlRegisteredMember?> SelectUniqueSqlRegisteredMemberAsync(
        SqlInt32 registeredMemberId,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlRegisteredMemberCommand(
            registeredMemberId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            RegisteredMemberId: reader.GetSqlInt32(0),
            PhoneNumber: reader.GetSqlString(1),
            PasswordHash: reader.GetSqlString(2),
            BirthDate: reader.GetSqlDateTime(3),
            FirstName: reader.GetSqlString(4),
            LastName: reader.GetSqlString(5));
    }

    private SqlCommand InsertSqlRegisteredMemberCommand(
        SqlInt32 registeredMemberId,
        SqlString phoneNumber,
        SqlString passwordHash,
        SqlDateTime birthDate,
        SqlString firstName,
        SqlString lastName)
    {
        var command = new SqlCommand(
            "INSERT INTO [registered_members] ([registered_member_id], [phone_number], [password_hash], [birth_date], [first_name], [last_name]) VALUES (@registered_member_id, @phone_number, @password_hash, @birth_date, @first_name, @last_name)",
            source);

        command.Parameters.Add("registered_member_id", SqlDbType.Int).SqlValue = registeredMemberId;
        command.Parameters.Add("phone_number", SqlDbType.VarChar).SqlValue = phoneNumber;
        command.Parameters.Add("password_hash", SqlDbType.VarChar, 255).SqlValue = passwordHash;
        command.Parameters.Add("birth_date", SqlDbType.DateTime).SqlValue = birthDate;
        command.Parameters.Add("first_name", SqlDbType.VarChar, 255).SqlValue = firstName;
        command.Parameters.Add("last_name", SqlDbType.VarChar, 255).SqlValue = lastName;

        return command;
    }

    public void InsertSqlRegisteredMember(SqlRegisteredMember registeredMember)
    {
        var command = InsertSqlRegisteredMemberCommand(
            registeredMember.RegisteredMemberId,
            registeredMember.PhoneNumber,
            registeredMember.PasswordHash,
            registeredMember.BirthDate,
            registeredMember.FirstName,
            registeredMember.LastName);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlRegisteredMemberAsync(SqlRegisteredMember registeredMember)
        => InsertSqlRegisteredMemberAsync(registeredMember, CancellationToken.None);

    public Task InsertSqlRegisteredMemberAsync(
        SqlRegisteredMember registeredMember,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlRegisteredMemberCommand(
            registeredMember.RegisteredMemberId,
            registeredMember.PhoneNumber,
            registeredMember.PasswordHash,
            registeredMember.BirthDate,
            registeredMember.FirstName,
            registeredMember.LastName);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveySubmissionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveySubmissionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_submission_index], [registered_member_id] FROM [survey_submissions] WHERE [survey_id] = @survey_id AND [survey_submission_index] = @survey_submission_index",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_submission_index", SqlDbType.Int).SqlValue = surveySubmissionIndex;

        return command;
    }

    public SqlSurveySubmission? SelectUniqueSqlSurveySubmission(
        SqlInt32 surveyId,
        SqlInt32 surveySubmissionIndex)
    {
        var command = SelectUniqueSqlSurveySubmissionCommand(
            surveyId,
            surveySubmissionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveySubmissionIndex: reader.GetSqlInt32(1),
            RegisteredMemberId: reader.GetSqlInt32(2));
    }

    public Task<SqlSurveySubmission?> SelectUniqueSqlSurveySubmissionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveySubmissionIndex)
    {
        return SelectUniqueSqlSurveySubmissionAsync(
            surveyId,
            surveySubmissionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveySubmission?> SelectUniqueSqlSurveySubmissionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveySubmissionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveySubmissionCommand(
            surveyId,
            surveySubmissionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveySubmissionIndex: reader.GetSqlInt32(1),
            RegisteredMemberId: reader.GetSqlInt32(2));
    }

    private SqlCommand InsertSqlSurveySubmissionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveySubmissionIndex,
        SqlInt32 registeredMemberId)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_submissions] ([survey_id], [survey_submission_index], [registered_member_id]) VALUES (@survey_id, @survey_submission_index, @registered_member_id)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_submission_index", SqlDbType.Int).SqlValue = surveySubmissionIndex;
        command.Parameters.Add("registered_member_id", SqlDbType.Int).SqlValue = registeredMemberId;

        return command;
    }

    public void InsertSqlSurveySubmission(SqlSurveySubmission surveySubmission)
    {
        var command = InsertSqlSurveySubmissionCommand(
            surveySubmission.SurveyId,
            surveySubmission.SurveySubmissionIndex,
            surveySubmission.RegisteredMemberId);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveySubmissionAsync(SqlSurveySubmission surveySubmission)
        => InsertSqlSurveySubmissionAsync(surveySubmission, CancellationToken.None);

    public Task InsertSqlSurveySubmissionAsync(
        SqlSurveySubmission surveySubmission,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveySubmissionCommand(
            surveySubmission.SurveyId,
            surveySubmission.SurveySubmissionIndex,
            surveySubmission.RegisteredMemberId);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlSurveyReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int nameColumnIndex,
    int descriptionColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurvey>, IEnumerator<SqlSurvey>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurvey Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            Name: source.GetSqlString(nameColumnIndex),
            Description: source.GetSqlString(descriptionColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurvey IAsyncEnumerator<SqlSurvey>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlSurveyPageReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int nameColumnIndex,
    int descriptionColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyPage>, IEnumerator<SqlSurveyPage>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyPage Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            Name: source.GetSqlString(nameColumnIndex),
            Description: source.GetSqlString(descriptionColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyPage IAsyncEnumerator<SqlSurveyPage>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlSurveyQuestionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int promptColumnIndex,
    int answerTypeColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestion>, IEnumerator<SqlSurveyQuestion>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestion Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            Prompt: source.GetSqlString(promptColumnIndex),
            AnswerType: source.GetSqlByte(answerTypeColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestion IAsyncEnumerator<SqlSurveyQuestion>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlSurveyQuestionConditionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int otherSurveyPageIndexColumnIndex,
    int otherSurveyQuestionIndexColumnIndex,
    int conditionColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionCondition>, IEnumerator<SqlSurveyQuestionCondition>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionCondition Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            OtherSurveyPageIndex: source.GetSqlInt32(otherSurveyPageIndexColumnIndex),
            OtherSurveyQuestionIndex: source.GetSqlInt32(otherSurveyQuestionIndexColumnIndex),
            Condition: source.GetSqlString(conditionColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionCondition IAsyncEnumerator<SqlSurveyQuestionCondition>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlSurveyAnswerReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveySubmissionIndexColumnIndex,
    int answerValueColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyAnswer>, IEnumerator<SqlSurveyAnswer>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyAnswer Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveySubmissionIndex: source.GetSqlInt32(surveySubmissionIndexColumnIndex),
            AnswerValue: source.GetSqlString(answerValueColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyAnswer IAsyncEnumerator<SqlSurveyAnswer>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlAnswerTypeReader(
    SqlDataReader source,
    int answerTypeIdColumnIndex,
    int nameColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlAnswerType>, IEnumerator<SqlAnswerType>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlAnswerType Current
    {
        get => new(
            AnswerTypeId: source.GetSqlByte(answerTypeIdColumnIndex),
            Name: source.GetSqlString(nameColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlAnswerType IAsyncEnumerator<SqlAnswerType>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlRegisteredMemberReader(
    SqlDataReader source,
    int registeredMemberIdColumnIndex,
    int phoneNumberColumnIndex,
    int passwordHashColumnIndex,
    int birthDateColumnIndex,
    int firstNameColumnIndex,
    int lastNameColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlRegisteredMember>, IEnumerator<SqlRegisteredMember>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlRegisteredMember Current
    {
        get => new(
            RegisteredMemberId: source.GetSqlInt32(registeredMemberIdColumnIndex),
            PhoneNumber: source.GetSqlString(phoneNumberColumnIndex),
            PasswordHash: source.GetSqlString(passwordHashColumnIndex),
            BirthDate: source.GetSqlDateTime(birthDateColumnIndex),
            FirstName: source.GetSqlString(firstNameColumnIndex),
            LastName: source.GetSqlString(lastNameColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlRegisteredMember IAsyncEnumerator<SqlRegisteredMember>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

public class SqlSurveySubmissionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveySubmissionIndexColumnIndex,
    int registeredMemberIdColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveySubmission>, IEnumerator<SqlSurveySubmission>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveySubmission Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveySubmissionIndex: source.GetSqlInt32(surveySubmissionIndexColumnIndex),
            RegisteredMemberId: source.GetSqlInt32(registeredMemberIdColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveySubmission IAsyncEnumerator<SqlSurveySubmission>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}

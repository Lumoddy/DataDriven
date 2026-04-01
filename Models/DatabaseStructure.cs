// This file was auto-generated based on ./Build/database/database_structure.yaml

using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial record Survey(
    int Id,
    string Title,
    string Author,
    string Description);

public record SqlSurvey(
    SqlInt32 SurveyId,
    SqlString SurveyTitle,
    SqlString SurveyAuthor,
    SqlString SurveyDescription)
{
    public const string TABLE = "[surveys]";

    public const string ID = "[survey_id]";

    public const string TABLE_ID = $"[surveys].[survey_id]";

    public const string TITLE = "[survey_title]";

    public const string TABLE_TITLE = $"[surveys].[survey_title]";

    public const string AUTHOR = "[survey_author]";

    public const string TABLE_AUTHOR = $"[surveys].[survey_author]";

    public const string DESCRIPTION = "[survey_description]";

    public const string TABLE_DESCRIPTION = $"[surveys].[survey_description]";

    public Survey Value => new(
        SurveyId.Value,
        SurveyTitle.Value,
        SurveyAuthor.Value,
        SurveyDescription.Value);

    public SqlSurvey(Survey data) : this(
        data.Id,
        data.Title,
        data.Author,
        data.Description) { }

    public static explicit operator Survey(SqlSurvey value) => value.Value;
    public static implicit operator SqlSurvey(Survey value) => new(value);
}

public partial record SurveyPage(
    int SurveyId,
    int Index,
    string Title,
    string Description);

public record SqlSurveyPage(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlString SurveyPageTitle,
    SqlString SurveyPageDescription)
{
    public const string TABLE = "[survey_pages]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_pages].[survey_id]";

    public const string INDEX = "[survey_page_index]";

    public const string TABLE_INDEX = $"[survey_pages].[survey_page_index]";

    public const string TITLE = "[survey_page_title]";

    public const string TABLE_TITLE = $"[survey_pages].[survey_page_title]";

    public const string DESCRIPTION = "[survey_page_description]";

    public const string TABLE_DESCRIPTION = $"[survey_pages].[survey_page_description]";

    public SurveyPage Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyPageTitle.Value,
        SurveyPageDescription.Value);

    public SqlSurveyPage(SurveyPage data) : this(
        data.SurveyId,
        data.Index,
        data.Title,
        data.Description) { }

    public static explicit operator SurveyPage(SqlSurveyPage value) => value.Value;
    public static implicit operator SqlSurveyPage(SurveyPage value) => new(value);
}

public partial record AnswerType(
    byte Id,
    string Name);

public record SqlAnswerType(
    SqlByte AnswerTypeId,
    SqlString AnswerTypeName)
{
    public const string TABLE = "[answer_types]";

    public const string ID = "[answer_type_id]";

    public const string TABLE_ID = $"[answer_types].[answer_type_id]";

    public const string NAME = "[answer_type_name]";

    public const string TABLE_NAME = $"[answer_types].[answer_type_name]";

    public AnswerType Value => new(
        AnswerTypeId.Value,
        AnswerTypeName.Value);

    public SqlAnswerType(AnswerType data) : this(
        data.Id,
        data.Name) { }

    public static explicit operator AnswerType(SqlAnswerType value) => value.Value;
    public static implicit operator SqlAnswerType(AnswerType value) => new(value);
}

public partial record SurveyQuestion(
    int SurveyId,
    int PageIndex,
    int Index,
    string Title,
    byte Type);

public record SqlSurveyQuestion(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlString SurveyQuestionPrompt,
    SqlByte SurveyQuestionAnswerType)
{
    public const string TABLE = "[survey_questions]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_questions].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_questions].[survey_page_index]";

    public const string INDEX = "[survey_question_index]";

    public const string TABLE_INDEX = $"[survey_questions].[survey_question_index]";

    public const string TITLE = "[survey_question_prompt]";

    public const string TABLE_TITLE = $"[survey_questions].[survey_question_prompt]";

    public const string TYPE = "[survey_question_answer_type]";

    public const string TABLE_TYPE = $"[survey_questions].[survey_question_answer_type]";

    public SurveyQuestion Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionPrompt.Value,
        SurveyQuestionAnswerType.Value);

    public SqlSurveyQuestion(SurveyQuestion data) : this(
        data.SurveyId,
        data.PageIndex,
        data.Index,
        data.Title,
        data.Type) { }

    public static explicit operator SurveyQuestion(SqlSurveyQuestion value) => value.Value;
    public static implicit operator SqlSurveyQuestion(SurveyQuestion value) => new(value);
}

public partial record RegisteredMember(
    int Id,
    string PasswordHash,
    string PhoneNumber,
    DateTime BirthDate,
    string FirstName,
    string LastName);

public record SqlRegisteredMember(
    SqlInt32 RegisteredMemberId,
    SqlString RegisteredMemberPasswordHash,
    SqlString RegisteredMemberPhoneNumber,
    SqlDateTime RegisteredMemberBirthDate,
    SqlString RegisteredMemberFirstName,
    SqlString RegisteredMemberLastName)
{
    public const string TABLE = "[registered_members]";

    public const string ID = "[registered_member_id]";

    public const string TABLE_ID = $"[registered_members].[registered_member_id]";

    public const string PASSWORD_HASH = "[registered_member_password_hash]";

    public const string TABLE_PASSWORD_HASH = $"[registered_members].[registered_member_password_hash]";

    public const string PHONE_NUMBER = "[registered_member_phone_number]";

    public const string TABLE_PHONE_NUMBER = $"[registered_members].[registered_member_phone_number]";

    public const string BIRTH_DATE = "[registered_member_birth_date]";

    public const string TABLE_BIRTH_DATE = $"[registered_members].[registered_member_birth_date]";

    public const string FIRST_NAME = "[registered_member_first_name]";

    public const string TABLE_FIRST_NAME = $"[registered_members].[registered_member_first_name]";

    public const string LAST_NAME = "[registered_member_last_name]";

    public const string TABLE_LAST_NAME = $"[registered_members].[registered_member_last_name]";

    public RegisteredMember Value => new(
        RegisteredMemberId.Value,
        RegisteredMemberPasswordHash.Value,
        RegisteredMemberPhoneNumber.Value,
        RegisteredMemberBirthDate.Value,
        RegisteredMemberFirstName.Value,
        RegisteredMemberLastName.Value);

    public SqlRegisteredMember(RegisteredMember data) : this(
        data.Id,
        data.PasswordHash,
        data.PhoneNumber,
        data.BirthDate,
        data.FirstName,
        data.LastName) { }

    public static explicit operator RegisteredMember(SqlRegisteredMember value) => value.Value;
    public static implicit operator SqlRegisteredMember(RegisteredMember value) => new(value);
}

public partial record Submission(
    int SurveyId,
    int Index,
    int? RegisteredMemberId);

public record SqlSubmission(
    SqlInt32 SurveyId,
    SqlInt32 SubmissionIndex,
    SqlInt32 RegisteredMemberId)
{
    public const string TABLE = "[submissions]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[submissions].[survey_id]";

    public const string INDEX = "[submission_index]";

    public const string TABLE_INDEX = $"[submissions].[submission_index]";

    public const string REGISTERED_MEMBER_ID = "[registered_member_id]";

    public const string TABLE_REGISTERED_MEMBER_ID = $"[submissions].[registered_member_id]";

    public Submission Value => new(
        SurveyId.Value,
        SubmissionIndex.Value,
        RegisteredMemberId.Value);

    public SqlSubmission(Submission data) : this(
        data.SurveyId,
        data.Index,
        data.RegisteredMemberId ?? SqlInt32.Null) { }

    public static explicit operator Submission(SqlSubmission value) => value.Value;
    public static implicit operator SqlSubmission(Submission value) => new(value);
}

public partial record SubmissionTextAnswer(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int SubmissionIndex,
    int AnswerIndex,
    string Value);

public record SqlSubmissionTextAnswer(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 SubmissionAnswerIndex,
    SqlString SubmissionAnswerText)
{
    public const string TABLE = "[submission_text_answers]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[submission_text_answers].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[submission_text_answers].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[submission_text_answers].[survey_question_index]";

    public const string SUBMISSION_INDEX = "[submission_index]";

    public const string TABLE_SUBMISSION_INDEX = $"[submission_text_answers].[submission_index]";

    public const string ANSWER_INDEX = "[submission_answer_index]";

    public const string TABLE_ANSWER_INDEX = $"[submission_text_answers].[submission_answer_index]";

    public const string VALUE = "[submission_answer_text]";

    public const string TABLE_VALUE = $"[submission_text_answers].[submission_answer_text]";

    public SubmissionTextAnswer Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SubmissionIndex.Value,
        SubmissionAnswerIndex.Value,
        SubmissionAnswerText.Value);

    public SqlSubmissionTextAnswer(SubmissionTextAnswer data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.SubmissionIndex,
        data.AnswerIndex,
        data.Value) { }

    public static explicit operator SubmissionTextAnswer(SqlSubmissionTextAnswer value) => value.Value;
    public static implicit operator SqlSubmissionTextAnswer(SubmissionTextAnswer value) => new(value);
}

public partial record SubmissionIntegerAnswer(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int SubmissionIndex,
    int AnswerIndex,
    int Value);

public record SqlSubmissionIntegerAnswer(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 SubmissionAnswerIndex,
    SqlInt32 SubmissionAnswerInteger)
{
    public const string TABLE = "[submission_integer_answers]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[submission_integer_answers].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[submission_integer_answers].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[submission_integer_answers].[survey_question_index]";

    public const string SUBMISSION_INDEX = "[submission_index]";

    public const string TABLE_SUBMISSION_INDEX = $"[submission_integer_answers].[submission_index]";

    public const string ANSWER_INDEX = "[submission_answer_index]";

    public const string TABLE_ANSWER_INDEX = $"[submission_integer_answers].[submission_answer_index]";

    public const string VALUE = "[submission_answer_integer]";

    public const string TABLE_VALUE = $"[submission_integer_answers].[submission_answer_integer]";

    public SubmissionIntegerAnswer Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SubmissionIndex.Value,
        SubmissionAnswerIndex.Value,
        SubmissionAnswerInteger.Value);

    public SqlSubmissionIntegerAnswer(SubmissionIntegerAnswer data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.SubmissionIndex,
        data.AnswerIndex,
        data.Value) { }

    public static explicit operator SubmissionIntegerAnswer(SqlSubmissionIntegerAnswer value) => value.Value;
    public static implicit operator SqlSubmissionIntegerAnswer(SubmissionIntegerAnswer value) => new(value);
}

public partial record SubmissionBoolAnswer(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int SubmissionIndex,
    int Index,
    bool Value);

public record SqlSubmissionBoolAnswer(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 SubmissionAnswerIndex,
    SqlBoolean SubmissionAnswerBool)
{
    public const string TABLE = "[submission_bool_answers]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[submission_bool_answers].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[submission_bool_answers].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[submission_bool_answers].[survey_question_index]";

    public const string SUBMISSION_INDEX = "[submission_index]";

    public const string TABLE_SUBMISSION_INDEX = $"[submission_bool_answers].[submission_index]";

    public const string INDEX = "[submission_answer_index]";

    public const string TABLE_INDEX = $"[submission_bool_answers].[submission_answer_index]";

    public const string VALUE = "[submission_answer_bool]";

    public const string TABLE_VALUE = $"[submission_bool_answers].[submission_answer_bool]";

    public SubmissionBoolAnswer Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SubmissionIndex.Value,
        SubmissionAnswerIndex.Value,
        SubmissionAnswerBool.Value);

    public SqlSubmissionBoolAnswer(SubmissionBoolAnswer data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.SubmissionIndex,
        data.Index,
        data.Value) { }

    public static explicit operator SubmissionBoolAnswer(SqlSubmissionBoolAnswer value) => value.Value;
    public static implicit operator SqlSubmissionBoolAnswer(SubmissionBoolAnswer value) => new(value);
}

public partial record SurveyQuestionAnswerOption(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    string Text);

public record SqlSurveyQuestionAnswerOption(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyAnswerOptionIndex,
    SqlString SurveyAnswerOptionText)
{
    public const string TABLE = "[survey_question_answer_options]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_answer_options].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_answer_options].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_answer_options].[survey_question_index]";

    public const string INDEX = "[survey_answer_option_index]";

    public const string TABLE_INDEX = $"[survey_question_answer_options].[survey_answer_option_index]";

    public const string TEXT = "[survey_answer_option_text]";

    public const string TABLE_TEXT = $"[survey_question_answer_options].[survey_answer_option_text]";

    public SurveyQuestionAnswerOption Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyAnswerOptionIndex.Value,
        SurveyAnswerOptionText.Value);

    public SqlSurveyQuestionAnswerOption(SurveyQuestionAnswerOption data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.Text) { }

    public static explicit operator SurveyQuestionAnswerOption(SqlSurveyQuestionAnswerOption value) => value.Value;
    public static implicit operator SqlSurveyQuestionAnswerOption(SurveyQuestionAnswerOption value) => new(value);
}

public partial record SurveyQuestionShowConditionType(
    byte Id,
    string Name);

public record SqlSurveyQuestionShowConditionType(
    SqlByte SurveyQuestionShowConditionTypeId,
    SqlString SurveyQuestionShowConditionTypeName)
{
    public const string TABLE = "[survey_question_show_condition_types]";

    public const string ID = "[survey_question_show_condition_type_id]";

    public const string TABLE_ID = $"[survey_question_show_condition_types].[survey_question_show_condition_type_id]";

    public const string NAME = "[survey_question_show_condition_type_name]";

    public const string TABLE_NAME = $"[survey_question_show_condition_types].[survey_question_show_condition_type_name]";

    public SurveyQuestionShowConditionType Value => new(
        SurveyQuestionShowConditionTypeId.Value,
        SurveyQuestionShowConditionTypeName.Value);

    public SqlSurveyQuestionShowConditionType(SurveyQuestionShowConditionType data) : this(
        data.Id,
        data.Name) { }

    public static explicit operator SurveyQuestionShowConditionType(SqlSurveyQuestionShowConditionType value) => value.Value;
    public static implicit operator SqlSurveyQuestionShowConditionType(SurveyQuestionShowConditionType value) => new(value);
}

public partial record SurveyQuestionShowCondition(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    byte Type,
    bool IsOrOperator);

public record SqlSurveyQuestionShowCondition(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionShowConditionIndex,
    SqlByte SurveyQuestionShowConditionType,
    SqlBoolean SurveyQuestionShowConditionOperator)
{
    public const string TABLE = "[survey_question_show_conditions]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_show_conditions].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_show_conditions].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_show_conditions].[survey_question_index]";

    public const string INDEX = "[survey_question_show_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_show_conditions].[survey_question_show_condition_index]";

    public const string TYPE = "[survey_question_show_condition_type]";

    public const string TABLE_TYPE = $"[survey_question_show_conditions].[survey_question_show_condition_type]";

    public const string IS_OR_OPERATOR = "[survey_question_show_condition_operator]";

    public const string TABLE_IS_OR_OPERATOR = $"[survey_question_show_conditions].[survey_question_show_condition_operator]";

    public SurveyQuestionShowCondition Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionShowConditionIndex.Value,
        SurveyQuestionShowConditionType.Value,
        SurveyQuestionShowConditionOperator.Value);

    public SqlSurveyQuestionShowCondition(SurveyQuestionShowCondition data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.Type,
        data.IsOrOperator) { }

    public static explicit operator SurveyQuestionShowCondition(SqlSurveyQuestionShowCondition value) => value.Value;
    public static implicit operator SqlSurveyQuestionShowCondition(SurveyQuestionShowCondition value) => new(value);
}

public partial record SurveyQuestionShowConditionsRefArg(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    int ArgIndex,
    int ReferencedPageIndex,
    int ReferencedQuestionIndex);

public record SqlSurveyQuestionShowConditionsRefArg(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionShowConditionIndex,
    SqlInt32 SurveyQuestionShowConditionArgIndex,
    SqlInt32 ReferencedSurveyPageIndex,
    SqlInt32 ReferencedSurveyQuestionIndex)
{
    public const string TABLE = "[survey_question_show_conditions_ref_args]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_show_conditions_ref_args].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_show_conditions_ref_args].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_show_conditions_ref_args].[survey_question_index]";

    public const string INDEX = "[survey_question_show_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_show_conditions_ref_args].[survey_question_show_condition_index]";

    public const string ARG_INDEX = "[survey_question_show_condition_arg_index]";

    public const string TABLE_ARG_INDEX = $"[survey_question_show_conditions_ref_args].[survey_question_show_condition_arg_index]";

    public const string REFERENCED_PAGE_INDEX = "[referenced_survey_page_index]";

    public const string TABLE_REFERENCED_PAGE_INDEX = $"[survey_question_show_conditions_ref_args].[referenced_survey_page_index]";

    public const string REFERENCED_QUESTION_INDEX = "[referenced_survey_question_index]";

    public const string TABLE_REFERENCED_QUESTION_INDEX = $"[survey_question_show_conditions_ref_args].[referenced_survey_question_index]";

    public SurveyQuestionShowConditionsRefArg Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionShowConditionIndex.Value,
        SurveyQuestionShowConditionArgIndex.Value,
        ReferencedSurveyPageIndex.Value,
        ReferencedSurveyQuestionIndex.Value);

    public SqlSurveyQuestionShowConditionsRefArg(SurveyQuestionShowConditionsRefArg data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.ArgIndex,
        data.ReferencedPageIndex,
        data.ReferencedQuestionIndex) { }

    public static explicit operator SurveyQuestionShowConditionsRefArg(SqlSurveyQuestionShowConditionsRefArg value) => value.Value;
    public static implicit operator SqlSurveyQuestionShowConditionsRefArg(SurveyQuestionShowConditionsRefArg value) => new(value);
}

public partial record SurveyQuestionShowConditionsIntegerArg(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    int ArgIndex,
    int ArgValue);

public record SqlSurveyQuestionShowConditionsIntegerArg(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionShowConditionIndex,
    SqlInt32 SurveyQuestionShowConditionArgIndex,
    SqlInt32 SurveyQuestionShowConditionArgInteger)
{
    public const string TABLE = "[survey_question_show_conditions_integer_args]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_show_conditions_integer_args].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_show_conditions_integer_args].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_show_conditions_integer_args].[survey_question_index]";

    public const string INDEX = "[survey_question_show_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_show_conditions_integer_args].[survey_question_show_condition_index]";

    public const string ARG_INDEX = "[survey_question_show_condition_arg_index]";

    public const string TABLE_ARG_INDEX = $"[survey_question_show_conditions_integer_args].[survey_question_show_condition_arg_index]";

    public const string ARG_VALUE = "[survey_question_show_condition_arg_integer]";

    public const string TABLE_ARG_VALUE = $"[survey_question_show_conditions_integer_args].[survey_question_show_condition_arg_integer]";

    public SurveyQuestionShowConditionsIntegerArg Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionShowConditionIndex.Value,
        SurveyQuestionShowConditionArgIndex.Value,
        SurveyQuestionShowConditionArgInteger.Value);

    public SqlSurveyQuestionShowConditionsIntegerArg(SurveyQuestionShowConditionsIntegerArg data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.ArgIndex,
        data.ArgValue) { }

    public static explicit operator SurveyQuestionShowConditionsIntegerArg(SqlSurveyQuestionShowConditionsIntegerArg value) => value.Value;
    public static implicit operator SqlSurveyQuestionShowConditionsIntegerArg(SurveyQuestionShowConditionsIntegerArg value) => new(value);
}

public partial record SurveyQuestionShowConditionsTextArg(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    int ArgIndex,
    string ArgValue);

public record SqlSurveyQuestionShowConditionsTextArg(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionShowConditionIndex,
    SqlInt32 SurveyQuestionShowConditionArgIndex,
    SqlString SurveyQuestionShowConditionArgText)
{
    public const string TABLE = "[survey_question_show_conditions_text_args]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_show_conditions_text_args].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_show_conditions_text_args].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_show_conditions_text_args].[survey_question_index]";

    public const string INDEX = "[survey_question_show_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_show_conditions_text_args].[survey_question_show_condition_index]";

    public const string ARG_INDEX = "[survey_question_show_condition_arg_index]";

    public const string TABLE_ARG_INDEX = $"[survey_question_show_conditions_text_args].[survey_question_show_condition_arg_index]";

    public const string ARG_VALUE = "[survey_question_show_condition_arg_text]";

    public const string TABLE_ARG_VALUE = $"[survey_question_show_conditions_text_args].[survey_question_show_condition_arg_text]";

    public SurveyQuestionShowConditionsTextArg Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionShowConditionIndex.Value,
        SurveyQuestionShowConditionArgIndex.Value,
        SurveyQuestionShowConditionArgText.Value);

    public SqlSurveyQuestionShowConditionsTextArg(SurveyQuestionShowConditionsTextArg data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.ArgIndex,
        data.ArgValue) { }

    public static explicit operator SurveyQuestionShowConditionsTextArg(SqlSurveyQuestionShowConditionsTextArg value) => value.Value;
    public static implicit operator SqlSurveyQuestionShowConditionsTextArg(SurveyQuestionShowConditionsTextArg value) => new(value);
}

public partial record SurveyQuestionValidationConditionType(
    byte Id,
    string Name);

public record SqlSurveyQuestionValidationConditionType(
    SqlByte SurveyQuestionValidationConditionTypeId,
    SqlString SurveyQuestionValidationConditionTypeName)
{
    public const string TABLE = "[survey_question_validation_condition_types]";

    public const string ID = "[survey_question_validation_condition_type_id]";

    public const string TABLE_ID = $"[survey_question_validation_condition_types].[survey_question_validation_condition_type_id]";

    public const string NAME = "[survey_question_validation_condition_type_name]";

    public const string TABLE_NAME = $"[survey_question_validation_condition_types].[survey_question_validation_condition_type_name]";

    public SurveyQuestionValidationConditionType Value => new(
        SurveyQuestionValidationConditionTypeId.Value,
        SurveyQuestionValidationConditionTypeName.Value);

    public SqlSurveyQuestionValidationConditionType(SurveyQuestionValidationConditionType data) : this(
        data.Id,
        data.Name) { }

    public static explicit operator SurveyQuestionValidationConditionType(SqlSurveyQuestionValidationConditionType value) => value.Value;
    public static implicit operator SqlSurveyQuestionValidationConditionType(SurveyQuestionValidationConditionType value) => new(value);
}

public partial record SurveyQuestionValidationCondition(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    byte Type,
    bool IsOrOperator);

public record SqlSurveyQuestionValidationCondition(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionValidationConditionIndex,
    SqlByte SurveyQuestionValidationConditionType,
    SqlBoolean SurveyQuestionValidationConditionOperator)
{
    public const string TABLE = "[survey_question_validation_conditions]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_validation_conditions].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_validation_conditions].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_validation_conditions].[survey_question_index]";

    public const string INDEX = "[survey_question_validation_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_validation_conditions].[survey_question_validation_condition_index]";

    public const string TYPE = "[survey_question_validation_condition_type]";

    public const string TABLE_TYPE = $"[survey_question_validation_conditions].[survey_question_validation_condition_type]";

    public const string IS_OR_OPERATOR = "[survey_question_validation_condition_operator]";

    public const string TABLE_IS_OR_OPERATOR = $"[survey_question_validation_conditions].[survey_question_validation_condition_operator]";

    public SurveyQuestionValidationCondition Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionValidationConditionIndex.Value,
        SurveyQuestionValidationConditionType.Value,
        SurveyQuestionValidationConditionOperator.Value);

    public SqlSurveyQuestionValidationCondition(SurveyQuestionValidationCondition data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.Type,
        data.IsOrOperator) { }

    public static explicit operator SurveyQuestionValidationCondition(SqlSurveyQuestionValidationCondition value) => value.Value;
    public static implicit operator SqlSurveyQuestionValidationCondition(SurveyQuestionValidationCondition value) => new(value);
}

public partial record SurveyQuestionValidationConditionsRefArg(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    int ArgIndex,
    int ReferencedPageIndex,
    int ReferencedQuestionIndex);

public record SqlSurveyQuestionValidationConditionsRefArg(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionValidationConditionIndex,
    SqlInt32 SurveyQuestionValidationConditionArgIndex,
    SqlInt32 ReferencedSurveyPageIndex,
    SqlInt32 ReferencedSurveyQuestionIndex)
{
    public const string TABLE = "[survey_question_validation_conditions_ref_args]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_validation_conditions_ref_args].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_validation_conditions_ref_args].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_validation_conditions_ref_args].[survey_question_index]";

    public const string INDEX = "[survey_question_validation_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_validation_conditions_ref_args].[survey_question_validation_condition_index]";

    public const string ARG_INDEX = "[survey_question_validation_condition_arg_index]";

    public const string TABLE_ARG_INDEX = $"[survey_question_validation_conditions_ref_args].[survey_question_validation_condition_arg_index]";

    public const string REFERENCED_PAGE_INDEX = "[referenced_survey_page_index]";

    public const string TABLE_REFERENCED_PAGE_INDEX = $"[survey_question_validation_conditions_ref_args].[referenced_survey_page_index]";

    public const string REFERENCED_QUESTION_INDEX = "[referenced_survey_question_index]";

    public const string TABLE_REFERENCED_QUESTION_INDEX = $"[survey_question_validation_conditions_ref_args].[referenced_survey_question_index]";

    public SurveyQuestionValidationConditionsRefArg Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionValidationConditionIndex.Value,
        SurveyQuestionValidationConditionArgIndex.Value,
        ReferencedSurveyPageIndex.Value,
        ReferencedSurveyQuestionIndex.Value);

    public SqlSurveyQuestionValidationConditionsRefArg(SurveyQuestionValidationConditionsRefArg data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.ArgIndex,
        data.ReferencedPageIndex,
        data.ReferencedQuestionIndex) { }

    public static explicit operator SurveyQuestionValidationConditionsRefArg(SqlSurveyQuestionValidationConditionsRefArg value) => value.Value;
    public static implicit operator SqlSurveyQuestionValidationConditionsRefArg(SurveyQuestionValidationConditionsRefArg value) => new(value);
}

public partial record SurveyQuestionValidationConditionsIntegerArg(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    int ArgIndex,
    int ArgValue);

public record SqlSurveyQuestionValidationConditionsIntegerArg(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionValidationConditionIndex,
    SqlInt32 SurveyQuestionValidationConditionArgIndex,
    SqlInt32 SurveyQuestionValidationConditionArgInteger)
{
    public const string TABLE = "[survey_question_validation_conditions_integer_args]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_validation_conditions_integer_args].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_validation_conditions_integer_args].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_validation_conditions_integer_args].[survey_question_index]";

    public const string INDEX = "[survey_question_validation_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_validation_conditions_integer_args].[survey_question_validation_condition_index]";

    public const string ARG_INDEX = "[survey_question_validation_condition_arg_index]";

    public const string TABLE_ARG_INDEX = $"[survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_index]";

    public const string ARG_VALUE = "[survey_question_validation_condition_arg_integer]";

    public const string TABLE_ARG_VALUE = $"[survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_integer]";

    public SurveyQuestionValidationConditionsIntegerArg Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionValidationConditionIndex.Value,
        SurveyQuestionValidationConditionArgIndex.Value,
        SurveyQuestionValidationConditionArgInteger.Value);

    public SqlSurveyQuestionValidationConditionsIntegerArg(SurveyQuestionValidationConditionsIntegerArg data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.ArgIndex,
        data.ArgValue) { }

    public static explicit operator SurveyQuestionValidationConditionsIntegerArg(SqlSurveyQuestionValidationConditionsIntegerArg value) => value.Value;
    public static implicit operator SqlSurveyQuestionValidationConditionsIntegerArg(SurveyQuestionValidationConditionsIntegerArg value) => new(value);
}

public partial record SurveyQuestionValidationConditionsTextArg(
    int SurveyId,
    int PageIndex,
    int QuestionIndex,
    int Index,
    int ArgIndex,
    string ArgValue);

public record SqlSurveyQuestionValidationConditionsTextArg(
    SqlInt32 SurveyId,
    SqlInt32 SurveyPageIndex,
    SqlInt32 SurveyQuestionIndex,
    SqlInt32 SurveyQuestionValidationConditionIndex,
    SqlInt32 SurveyQuestionValidationConditionArgIndex,
    SqlString SurveyQuestionValidationConditionArgText)
{
    public const string TABLE = "[survey_question_validation_conditions_text_args]";

    public const string SURVEY_ID = "[survey_id]";

    public const string TABLE_SURVEY_ID = $"[survey_question_validation_conditions_text_args].[survey_id]";

    public const string PAGE_INDEX = "[survey_page_index]";

    public const string TABLE_PAGE_INDEX = $"[survey_question_validation_conditions_text_args].[survey_page_index]";

    public const string QUESTION_INDEX = "[survey_question_index]";

    public const string TABLE_QUESTION_INDEX = $"[survey_question_validation_conditions_text_args].[survey_question_index]";

    public const string INDEX = "[survey_question_validation_condition_index]";

    public const string TABLE_INDEX = $"[survey_question_validation_conditions_text_args].[survey_question_validation_condition_index]";

    public const string ARG_INDEX = "[survey_question_validation_condition_arg_index]";

    public const string TABLE_ARG_INDEX = $"[survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_index]";

    public const string ARG_VALUE = "[survey_question_validation_condition_arg_text]";

    public const string TABLE_ARG_VALUE = $"[survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_text]";

    public SurveyQuestionValidationConditionsTextArg Value => new(
        SurveyId.Value,
        SurveyPageIndex.Value,
        SurveyQuestionIndex.Value,
        SurveyQuestionValidationConditionIndex.Value,
        SurveyQuestionValidationConditionArgIndex.Value,
        SurveyQuestionValidationConditionArgText.Value);

    public SqlSurveyQuestionValidationConditionsTextArg(SurveyQuestionValidationConditionsTextArg data) : this(
        data.SurveyId,
        data.PageIndex,
        data.QuestionIndex,
        data.Index,
        data.ArgIndex,
        data.ArgValue) { }

    public static explicit operator SurveyQuestionValidationConditionsTextArg(SqlSurveyQuestionValidationConditionsTextArg value) => value.Value;
    public static implicit operator SqlSurveyQuestionValidationConditionsTextArg(SurveyQuestionValidationConditionsTextArg value) => new(value);
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
            "SELECT [survey_id], [survey_title], [survey_author], [survey_description] FROM [surveys] WHERE [survey_id,[object Object]] = @survey_id,[object Object]",
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
            SurveyTitle: reader.GetSqlString(1),
            SurveyAuthor: reader.GetSqlString(2),
            SurveyDescription: reader.GetSqlString(3));
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
            SurveyTitle: reader.GetSqlString(1),
            SurveyAuthor: reader.GetSqlString(2),
            SurveyDescription: reader.GetSqlString(3));
    }

    private SqlCommand InsertSqlSurveyCommand(
        SqlInt32 surveyId,
        SqlString surveyTitle,
        SqlString surveyAuthor,
        SqlString surveyDescription)
    {
        var command = new SqlCommand(
            "INSERT INTO [surveys] ([survey_id], [survey_title], [survey_author], [survey_description]) VALUES (@survey_id, @survey_title, @survey_author, @survey_description)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_title", SqlDbType.VarChar, 255).SqlValue = surveyTitle;
        command.Parameters.Add("survey_author", SqlDbType.VarChar, 255).SqlValue = surveyAuthor;
        command.Parameters.Add("survey_description", SqlDbType.VarChar, VARCHAR_MAX_LENGTH).SqlValue = surveyDescription;

        return command;
    }

    public void InsertSqlSurvey(SqlSurvey survey)
    {
        var command = InsertSqlSurveyCommand(
            survey.SurveyId,
            survey.SurveyTitle,
            survey.SurveyAuthor,
            survey.SurveyDescription);

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
            survey.SurveyTitle,
            survey.SurveyAuthor,
            survey.SurveyDescription);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyPageCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_page_title], [survey_page_description] FROM [survey_pages] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object]",
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
            SurveyPageTitle: reader.GetSqlString(2),
            SurveyPageDescription: reader.GetSqlString(3));
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
            SurveyPageTitle: reader.GetSqlString(2),
            SurveyPageDescription: reader.GetSqlString(3));
    }

    private SqlCommand InsertSqlSurveyPageCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlString surveyPageTitle,
        SqlString surveyPageDescription)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES (@survey_id, @survey_page_index, @survey_page_title, @survey_page_description)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_page_title", SqlDbType.VarChar, 1023).SqlValue = surveyPageTitle;
        command.Parameters.Add("survey_page_description", SqlDbType.VarChar, VARCHAR_MAX_LENGTH).SqlValue = surveyPageDescription;

        return command;
    }

    public void InsertSqlSurveyPage(SqlSurveyPage surveyPage)
    {
        var command = InsertSqlSurveyPageCommand(
            surveyPage.SurveyId,
            surveyPage.SurveyPageIndex,
            surveyPage.SurveyPageTitle,
            surveyPage.SurveyPageDescription);

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
            surveyPage.SurveyPageTitle,
            surveyPage.SurveyPageDescription);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlAnswerTypeCommand(
        SqlByte answerTypeId)
    {
        var command = new SqlCommand(
            "SELECT [answer_type_id], [answer_type_name] FROM [answer_types] WHERE [answer_type_id,[object Object]] = @answer_type_id,[object Object]",
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
            AnswerTypeName: reader.GetSqlString(1));
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
            AnswerTypeName: reader.GetSqlString(1));
    }

    private SqlCommand InsertSqlAnswerTypeCommand(
        SqlByte answerTypeId,
        SqlString answerTypeName)
    {
        var command = new SqlCommand(
            "INSERT INTO [answer_types] ([answer_type_id], [answer_type_name]) VALUES (@answer_type_id, @answer_type_name)",
            source);

        command.Parameters.Add("answer_type_id", SqlDbType.TinyInt).SqlValue = answerTypeId;
        command.Parameters.Add("answer_type_name", SqlDbType.VarChar, 255).SqlValue = answerTypeName;

        return command;
    }

    public void InsertSqlAnswerType(SqlAnswerType answerType)
    {
        var command = InsertSqlAnswerTypeCommand(
            answerType.AnswerTypeId,
            answerType.AnswerTypeName);

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
            answerType.AnswerTypeName);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type] FROM [survey_questions] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object]",
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
            SurveyQuestionPrompt: reader.GetSqlString(3),
            SurveyQuestionAnswerType: reader.GetSqlByte(4));
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
            SurveyQuestionPrompt: reader.GetSqlString(3),
            SurveyQuestionAnswerType: reader.GetSqlByte(4));
    }

    private SqlCommand InsertSqlSurveyQuestionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlString surveyQuestionPrompt,
        SqlByte surveyQuestionAnswerType)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_prompt, @survey_question_answer_type)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_prompt", SqlDbType.VarChar, 1023).SqlValue = surveyQuestionPrompt;
        command.Parameters.Add("survey_question_answer_type", SqlDbType.TinyInt).SqlValue = surveyQuestionAnswerType;

        return command;
    }

    public void InsertSqlSurveyQuestion(SqlSurveyQuestion surveyQuestion)
    {
        var command = InsertSqlSurveyQuestionCommand(
            surveyQuestion.SurveyId,
            surveyQuestion.SurveyPageIndex,
            surveyQuestion.SurveyQuestionIndex,
            surveyQuestion.SurveyQuestionPrompt,
            surveyQuestion.SurveyQuestionAnswerType);

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
            surveyQuestion.SurveyQuestionPrompt,
            surveyQuestion.SurveyQuestionAnswerType);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlRegisteredMemberCommand(
        SqlInt32 registeredMemberId)
    {
        var command = new SqlCommand(
            "SELECT [registered_member_id], [registered_member_password_hash], [registered_member_phone_number], [registered_member_birth_date], [registered_member_first_name], [registered_member_last_name] FROM [registered_members] WHERE [registered_member_id,[object Object]] = @registered_member_id,[object Object]",
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
            RegisteredMemberPasswordHash: reader.GetSqlString(1),
            RegisteredMemberPhoneNumber: reader.GetSqlString(2),
            RegisteredMemberBirthDate: reader.GetSqlDateTime(3),
            RegisteredMemberFirstName: reader.GetSqlString(4),
            RegisteredMemberLastName: reader.GetSqlString(5));
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
            RegisteredMemberPasswordHash: reader.GetSqlString(1),
            RegisteredMemberPhoneNumber: reader.GetSqlString(2),
            RegisteredMemberBirthDate: reader.GetSqlDateTime(3),
            RegisteredMemberFirstName: reader.GetSqlString(4),
            RegisteredMemberLastName: reader.GetSqlString(5));
    }

    private SqlCommand InsertSqlRegisteredMemberCommand(
        SqlInt32 registeredMemberId,
        SqlString registeredMemberPasswordHash,
        SqlString registeredMemberPhoneNumber,
        SqlDateTime registeredMemberBirthDate,
        SqlString registeredMemberFirstName,
        SqlString registeredMemberLastName)
    {
        var command = new SqlCommand(
            "INSERT INTO [registered_members] ([registered_member_id], [registered_member_password_hash], [registered_member_phone_number], [registered_member_birth_date], [registered_member_first_name], [registered_member_last_name]) VALUES (@registered_member_id, @registered_member_password_hash, @registered_member_phone_number, @registered_member_birth_date, @registered_member_first_name, @registered_member_last_name)",
            source);

        command.Parameters.Add("registered_member_id", SqlDbType.Int).SqlValue = registeredMemberId;
        command.Parameters.Add("registered_member_password_hash", SqlDbType.VarChar, 255).SqlValue = registeredMemberPasswordHash;
        command.Parameters.Add("registered_member_phone_number", SqlDbType.VarChar, 13).SqlValue = registeredMemberPhoneNumber;
        command.Parameters.Add("registered_member_birth_date", SqlDbType.DateTime).SqlValue = registeredMemberBirthDate;
        command.Parameters.Add("registered_member_first_name", SqlDbType.VarChar, 255).SqlValue = registeredMemberFirstName;
        command.Parameters.Add("registered_member_last_name", SqlDbType.VarChar, 255).SqlValue = registeredMemberLastName;

        return command;
    }

    public void InsertSqlRegisteredMember(SqlRegisteredMember registeredMember)
    {
        var command = InsertSqlRegisteredMemberCommand(
            registeredMember.RegisteredMemberId,
            registeredMember.RegisteredMemberPasswordHash,
            registeredMember.RegisteredMemberPhoneNumber,
            registeredMember.RegisteredMemberBirthDate,
            registeredMember.RegisteredMemberFirstName,
            registeredMember.RegisteredMemberLastName);

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
            registeredMember.RegisteredMemberPasswordHash,
            registeredMember.RegisteredMemberPhoneNumber,
            registeredMember.RegisteredMemberBirthDate,
            registeredMember.RegisteredMemberFirstName,
            registeredMember.RegisteredMemberLastName);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSubmissionCommand(
        SqlInt32 surveyId,
        SqlInt32 submissionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [submission_index], [registered_member_id] FROM [submissions] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [submission_index,[object Object]] = @submission_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;

        return command;
    }

    public SqlSubmission? SelectUniqueSqlSubmission(
        SqlInt32 surveyId,
        SqlInt32 submissionIndex)
    {
        var command = SelectUniqueSqlSubmissionCommand(
            surveyId,
            submissionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SubmissionIndex: reader.GetSqlInt32(1),
            RegisteredMemberId: reader.GetSqlInt32(2));
    }

    public Task<SqlSubmission?> SelectUniqueSqlSubmissionAsync(
        SqlInt32 surveyId,
        SqlInt32 submissionIndex)
    {
        return SelectUniqueSqlSubmissionAsync(
            surveyId,
            submissionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSubmission?> SelectUniqueSqlSubmissionAsync(
        SqlInt32 surveyId,
        SqlInt32 submissionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSubmissionCommand(
            surveyId,
            submissionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SubmissionIndex: reader.GetSqlInt32(1),
            RegisteredMemberId: reader.GetSqlInt32(2));
    }

    private SqlCommand InsertSqlSubmissionCommand(
        SqlInt32 surveyId,
        SqlInt32 submissionIndex,
        SqlInt32 registeredMemberId)
    {
        var command = new SqlCommand(
            "INSERT INTO [submissions] ([survey_id], [submission_index], [registered_member_id]) VALUES (@survey_id, @submission_index, @registered_member_id)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;
        command.Parameters.Add("registered_member_id", SqlDbType.Int).SqlValue = registeredMemberId;

        return command;
    }

    public void InsertSqlSubmission(SqlSubmission submission)
    {
        var command = InsertSqlSubmissionCommand(
            submission.SurveyId,
            submission.SubmissionIndex,
            submission.RegisteredMemberId);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSubmissionAsync(SqlSubmission submission)
        => InsertSqlSubmissionAsync(submission, CancellationToken.None);

    public Task InsertSqlSubmissionAsync(
        SqlSubmission submission,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSubmissionCommand(
            submission.SurveyId,
            submission.SubmissionIndex,
            submission.RegisteredMemberId);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSubmissionTextAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [submission_index], [submission_answer_index], [submission_answer_text] FROM [submission_text_answers] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [submission_index,[object Object]] = @submission_index,[object Object] AND [submission_answer_index,[object Object]] = @submission_answer_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;
        command.Parameters.Add("submission_answer_index", SqlDbType.Int).SqlValue = submissionAnswerIndex;

        return command;
    }

    public SqlSubmissionTextAnswer? SelectUniqueSqlSubmissionTextAnswer(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        var command = SelectUniqueSqlSubmissionTextAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SubmissionIndex: reader.GetSqlInt32(3),
            SubmissionAnswerIndex: reader.GetSqlInt32(4),
            SubmissionAnswerText: reader.GetSqlString(5));
    }

    public Task<SqlSubmissionTextAnswer?> SelectUniqueSqlSubmissionTextAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        return SelectUniqueSqlSubmissionTextAnswerAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex,
            CancellationToken.None);
    }

    public async Task<SqlSubmissionTextAnswer?> SelectUniqueSqlSubmissionTextAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSubmissionTextAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SubmissionIndex: reader.GetSqlInt32(3),
            SubmissionAnswerIndex: reader.GetSqlInt32(4),
            SubmissionAnswerText: reader.GetSqlString(5));
    }

    private SqlCommand InsertSqlSubmissionTextAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex,
        SqlString submissionAnswerText)
    {
        var command = new SqlCommand(
            "INSERT INTO [submission_text_answers] ([survey_id], [survey_page_index], [survey_question_index], [submission_index], [submission_answer_index], [submission_answer_text]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @submission_index, @submission_answer_index, @submission_answer_text)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;
        command.Parameters.Add("submission_answer_index", SqlDbType.Int).SqlValue = submissionAnswerIndex;
        command.Parameters.Add("submission_answer_text", SqlDbType.VarChar, VARCHAR_MAX_LENGTH).SqlValue = submissionAnswerText;

        return command;
    }

    public void InsertSqlSubmissionTextAnswer(SqlSubmissionTextAnswer submissionTextAnswer)
    {
        var command = InsertSqlSubmissionTextAnswerCommand(
            submissionTextAnswer.SurveyId,
            submissionTextAnswer.SurveyPageIndex,
            submissionTextAnswer.SurveyQuestionIndex,
            submissionTextAnswer.SubmissionIndex,
            submissionTextAnswer.SubmissionAnswerIndex,
            submissionTextAnswer.SubmissionAnswerText);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSubmissionTextAnswerAsync(SqlSubmissionTextAnswer submissionTextAnswer)
        => InsertSqlSubmissionTextAnswerAsync(submissionTextAnswer, CancellationToken.None);

    public Task InsertSqlSubmissionTextAnswerAsync(
        SqlSubmissionTextAnswer submissionTextAnswer,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSubmissionTextAnswerCommand(
            submissionTextAnswer.SurveyId,
            submissionTextAnswer.SurveyPageIndex,
            submissionTextAnswer.SurveyQuestionIndex,
            submissionTextAnswer.SubmissionIndex,
            submissionTextAnswer.SubmissionAnswerIndex,
            submissionTextAnswer.SubmissionAnswerText);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSubmissionIntegerAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [submission_index], [submission_answer_index], [submission_answer_integer] FROM [submission_integer_answers] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [submission_index,[object Object]] = @submission_index,[object Object] AND [submission_answer_index,[object Object]] = @submission_answer_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;
        command.Parameters.Add("submission_answer_index", SqlDbType.Int).SqlValue = submissionAnswerIndex;

        return command;
    }

    public SqlSubmissionIntegerAnswer? SelectUniqueSqlSubmissionIntegerAnswer(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        var command = SelectUniqueSqlSubmissionIntegerAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SubmissionIndex: reader.GetSqlInt32(3),
            SubmissionAnswerIndex: reader.GetSqlInt32(4),
            SubmissionAnswerInteger: reader.GetSqlInt32(5));
    }

    public Task<SqlSubmissionIntegerAnswer?> SelectUniqueSqlSubmissionIntegerAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        return SelectUniqueSqlSubmissionIntegerAnswerAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex,
            CancellationToken.None);
    }

    public async Task<SqlSubmissionIntegerAnswer?> SelectUniqueSqlSubmissionIntegerAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSubmissionIntegerAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SubmissionIndex: reader.GetSqlInt32(3),
            SubmissionAnswerIndex: reader.GetSqlInt32(4),
            SubmissionAnswerInteger: reader.GetSqlInt32(5));
    }

    private SqlCommand InsertSqlSubmissionIntegerAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex,
        SqlInt32 submissionAnswerInteger)
    {
        var command = new SqlCommand(
            "INSERT INTO [submission_integer_answers] ([survey_id], [survey_page_index], [survey_question_index], [submission_index], [submission_answer_index], [submission_answer_integer]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @submission_index, @submission_answer_index, @submission_answer_integer)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;
        command.Parameters.Add("submission_answer_index", SqlDbType.Int).SqlValue = submissionAnswerIndex;
        command.Parameters.Add("submission_answer_integer", SqlDbType.Int).SqlValue = submissionAnswerInteger;

        return command;
    }

    public void InsertSqlSubmissionIntegerAnswer(SqlSubmissionIntegerAnswer submissionIntegerAnswer)
    {
        var command = InsertSqlSubmissionIntegerAnswerCommand(
            submissionIntegerAnswer.SurveyId,
            submissionIntegerAnswer.SurveyPageIndex,
            submissionIntegerAnswer.SurveyQuestionIndex,
            submissionIntegerAnswer.SubmissionIndex,
            submissionIntegerAnswer.SubmissionAnswerIndex,
            submissionIntegerAnswer.SubmissionAnswerInteger);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSubmissionIntegerAnswerAsync(SqlSubmissionIntegerAnswer submissionIntegerAnswer)
        => InsertSqlSubmissionIntegerAnswerAsync(submissionIntegerAnswer, CancellationToken.None);

    public Task InsertSqlSubmissionIntegerAnswerAsync(
        SqlSubmissionIntegerAnswer submissionIntegerAnswer,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSubmissionIntegerAnswerCommand(
            submissionIntegerAnswer.SurveyId,
            submissionIntegerAnswer.SurveyPageIndex,
            submissionIntegerAnswer.SurveyQuestionIndex,
            submissionIntegerAnswer.SubmissionIndex,
            submissionIntegerAnswer.SubmissionAnswerIndex,
            submissionIntegerAnswer.SubmissionAnswerInteger);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSubmissionBoolAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [submission_index], [submission_answer_index], [submission_answer_bool] FROM [submission_bool_answers] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [submission_index,[object Object]] = @submission_index,[object Object] AND [submission_answer_index,[object Object]] = @submission_answer_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;
        command.Parameters.Add("submission_answer_index", SqlDbType.Int).SqlValue = submissionAnswerIndex;

        return command;
    }

    public SqlSubmissionBoolAnswer? SelectUniqueSqlSubmissionBoolAnswer(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        var command = SelectUniqueSqlSubmissionBoolAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SubmissionIndex: reader.GetSqlInt32(3),
            SubmissionAnswerIndex: reader.GetSqlInt32(4),
            SubmissionAnswerBool: reader.GetSqlBoolean(5));
    }

    public Task<SqlSubmissionBoolAnswer?> SelectUniqueSqlSubmissionBoolAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex)
    {
        return SelectUniqueSqlSubmissionBoolAnswerAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex,
            CancellationToken.None);
    }

    public async Task<SqlSubmissionBoolAnswer?> SelectUniqueSqlSubmissionBoolAnswerAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSubmissionBoolAnswerCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            submissionIndex,
            submissionAnswerIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SubmissionIndex: reader.GetSqlInt32(3),
            SubmissionAnswerIndex: reader.GetSqlInt32(4),
            SubmissionAnswerBool: reader.GetSqlBoolean(5));
    }

    private SqlCommand InsertSqlSubmissionBoolAnswerCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 submissionIndex,
        SqlInt32 submissionAnswerIndex,
        SqlBoolean submissionAnswerBool)
    {
        var command = new SqlCommand(
            "INSERT INTO [submission_bool_answers] ([survey_id], [survey_page_index], [survey_question_index], [submission_index], [submission_answer_index], [submission_answer_bool]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @submission_index, @submission_answer_index, @submission_answer_bool)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("submission_index", SqlDbType.Int).SqlValue = submissionIndex;
        command.Parameters.Add("submission_answer_index", SqlDbType.Int).SqlValue = submissionAnswerIndex;
        command.Parameters.Add("submission_answer_bool", SqlDbType.Bit).SqlValue = submissionAnswerBool;

        return command;
    }

    public void InsertSqlSubmissionBoolAnswer(SqlSubmissionBoolAnswer submissionBoolAnswer)
    {
        var command = InsertSqlSubmissionBoolAnswerCommand(
            submissionBoolAnswer.SurveyId,
            submissionBoolAnswer.SurveyPageIndex,
            submissionBoolAnswer.SurveyQuestionIndex,
            submissionBoolAnswer.SubmissionIndex,
            submissionBoolAnswer.SubmissionAnswerIndex,
            submissionBoolAnswer.SubmissionAnswerBool);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSubmissionBoolAnswerAsync(SqlSubmissionBoolAnswer submissionBoolAnswer)
        => InsertSqlSubmissionBoolAnswerAsync(submissionBoolAnswer, CancellationToken.None);

    public Task InsertSqlSubmissionBoolAnswerAsync(
        SqlSubmissionBoolAnswer submissionBoolAnswer,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSubmissionBoolAnswerCommand(
            submissionBoolAnswer.SurveyId,
            submissionBoolAnswer.SurveyPageIndex,
            submissionBoolAnswer.SurveyQuestionIndex,
            submissionBoolAnswer.SubmissionIndex,
            submissionBoolAnswer.SubmissionAnswerIndex,
            submissionBoolAnswer.SubmissionAnswerBool);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionAnswerOptionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyAnswerOptionIndex,
        SqlInt32 surveyQuestionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text] FROM [survey_question_answer_options] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_answer_option_index,[object Object]] = @survey_answer_option_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_answer_option_index", SqlDbType.Int).SqlValue = surveyAnswerOptionIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;

        return command;
    }

    public SqlSurveyQuestionAnswerOption? SelectUniqueSqlSurveyQuestionAnswerOption(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyAnswerOptionIndex,
        SqlInt32 surveyQuestionIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionAnswerOptionCommand(
            surveyId,
            surveyPageIndex,
            surveyAnswerOptionIndex,
            surveyQuestionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyAnswerOptionIndex: reader.GetSqlInt32(3),
            SurveyAnswerOptionText: reader.GetSqlString(4));
    }

    public Task<SqlSurveyQuestionAnswerOption?> SelectUniqueSqlSurveyQuestionAnswerOptionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyAnswerOptionIndex,
        SqlInt32 surveyQuestionIndex)
    {
        return SelectUniqueSqlSurveyQuestionAnswerOptionAsync(
            surveyId,
            surveyPageIndex,
            surveyAnswerOptionIndex,
            surveyQuestionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionAnswerOption?> SelectUniqueSqlSurveyQuestionAnswerOptionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyAnswerOptionIndex,
        SqlInt32 surveyQuestionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionAnswerOptionCommand(
            surveyId,
            surveyPageIndex,
            surveyAnswerOptionIndex,
            surveyQuestionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyAnswerOptionIndex: reader.GetSqlInt32(3),
            SurveyAnswerOptionText: reader.GetSqlString(4));
    }

    private SqlCommand InsertSqlSurveyQuestionAnswerOptionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyAnswerOptionIndex,
        SqlString surveyAnswerOptionText)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_answer_option_index, @survey_answer_option_text)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_answer_option_index", SqlDbType.Int).SqlValue = surveyAnswerOptionIndex;
        command.Parameters.Add("survey_answer_option_text", SqlDbType.VarChar, 1023).SqlValue = surveyAnswerOptionText;

        return command;
    }

    public void InsertSqlSurveyQuestionAnswerOption(SqlSurveyQuestionAnswerOption surveyQuestionAnswerOption)
    {
        var command = InsertSqlSurveyQuestionAnswerOptionCommand(
            surveyQuestionAnswerOption.SurveyId,
            surveyQuestionAnswerOption.SurveyPageIndex,
            surveyQuestionAnswerOption.SurveyQuestionIndex,
            surveyQuestionAnswerOption.SurveyAnswerOptionIndex,
            surveyQuestionAnswerOption.SurveyAnswerOptionText);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionAnswerOptionAsync(SqlSurveyQuestionAnswerOption surveyQuestionAnswerOption)
        => InsertSqlSurveyQuestionAnswerOptionAsync(surveyQuestionAnswerOption, CancellationToken.None);

    public Task InsertSqlSurveyQuestionAnswerOptionAsync(
        SqlSurveyQuestionAnswerOption surveyQuestionAnswerOption,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionAnswerOptionCommand(
            surveyQuestionAnswerOption.SurveyId,
            surveyQuestionAnswerOption.SurveyPageIndex,
            surveyQuestionAnswerOption.SurveyQuestionIndex,
            surveyQuestionAnswerOption.SurveyAnswerOptionIndex,
            surveyQuestionAnswerOption.SurveyAnswerOptionText);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionShowConditionTypeCommand(
        SqlByte surveyQuestionShowConditionTypeId)
    {
        var command = new SqlCommand(
            "SELECT [survey_question_show_condition_type_id], [survey_question_show_condition_type_name] FROM [survey_question_show_condition_types] WHERE [survey_question_show_condition_type_id,[object Object]] = @survey_question_show_condition_type_id,[object Object]",
            source);

        command.Parameters.Add("survey_question_show_condition_type_id", SqlDbType.TinyInt).SqlValue = surveyQuestionShowConditionTypeId;

        return command;
    }

    public SqlSurveyQuestionShowConditionType? SelectUniqueSqlSurveyQuestionShowConditionType(
        SqlByte surveyQuestionShowConditionTypeId)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionTypeCommand(
            surveyQuestionShowConditionTypeId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyQuestionShowConditionTypeId: reader.GetSqlByte(0),
            SurveyQuestionShowConditionTypeName: reader.GetSqlString(1));
    }

    public Task<SqlSurveyQuestionShowConditionType?> SelectUniqueSqlSurveyQuestionShowConditionTypeAsync(
        SqlByte surveyQuestionShowConditionTypeId)
    {
        return SelectUniqueSqlSurveyQuestionShowConditionTypeAsync(
            surveyQuestionShowConditionTypeId,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionShowConditionType?> SelectUniqueSqlSurveyQuestionShowConditionTypeAsync(
        SqlByte surveyQuestionShowConditionTypeId,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionTypeCommand(
            surveyQuestionShowConditionTypeId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyQuestionShowConditionTypeId: reader.GetSqlByte(0),
            SurveyQuestionShowConditionTypeName: reader.GetSqlString(1));
    }

    private SqlCommand InsertSqlSurveyQuestionShowConditionTypeCommand(
        SqlByte surveyQuestionShowConditionTypeId,
        SqlString surveyQuestionShowConditionTypeName)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_show_condition_types] ([survey_question_show_condition_type_id], [survey_question_show_condition_type_name]) VALUES (@survey_question_show_condition_type_id, @survey_question_show_condition_type_name)",
            source);

        command.Parameters.Add("survey_question_show_condition_type_id", SqlDbType.TinyInt).SqlValue = surveyQuestionShowConditionTypeId;
        command.Parameters.Add("survey_question_show_condition_type_name", SqlDbType.VarChar, 255).SqlValue = surveyQuestionShowConditionTypeName;

        return command;
    }

    public void InsertSqlSurveyQuestionShowConditionType(SqlSurveyQuestionShowConditionType surveyQuestionShowConditionType)
    {
        var command = InsertSqlSurveyQuestionShowConditionTypeCommand(
            surveyQuestionShowConditionType.SurveyQuestionShowConditionTypeId,
            surveyQuestionShowConditionType.SurveyQuestionShowConditionTypeName);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionShowConditionTypeAsync(SqlSurveyQuestionShowConditionType surveyQuestionShowConditionType)
        => InsertSqlSurveyQuestionShowConditionTypeAsync(surveyQuestionShowConditionType, CancellationToken.None);

    public Task InsertSqlSurveyQuestionShowConditionTypeAsync(
        SqlSurveyQuestionShowConditionType surveyQuestionShowConditionType,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionShowConditionTypeCommand(
            surveyQuestionShowConditionType.SurveyQuestionShowConditionTypeId,
            surveyQuestionShowConditionType.SurveyQuestionShowConditionTypeName);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionShowConditionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator] FROM [survey_question_show_conditions] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_show_condition_index,[object Object]] = @survey_question_show_condition_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;

        return command;
    }

    public SqlSurveyQuestionShowCondition? SelectUniqueSqlSurveyQuestionShowCondition(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionType: reader.GetSqlByte(4),
            SurveyQuestionShowConditionOperator: reader.GetSqlBoolean(5));
    }

    public Task<SqlSurveyQuestionShowCondition?> SelectUniqueSqlSurveyQuestionShowConditionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex)
    {
        return SelectUniqueSqlSurveyQuestionShowConditionAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionShowCondition?> SelectUniqueSqlSurveyQuestionShowConditionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionType: reader.GetSqlByte(4),
            SurveyQuestionShowConditionOperator: reader.GetSqlBoolean(5));
    }

    private SqlCommand InsertSqlSurveyQuestionShowConditionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlByte surveyQuestionShowConditionType,
        SqlBoolean surveyQuestionShowConditionOperator)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_show_condition_index, @survey_question_show_condition_type, @survey_question_show_condition_operator)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;
        command.Parameters.Add("survey_question_show_condition_type", SqlDbType.TinyInt).SqlValue = surveyQuestionShowConditionType;
        command.Parameters.Add("survey_question_show_condition_operator", SqlDbType.Bit).SqlValue = surveyQuestionShowConditionOperator;

        return command;
    }

    public void InsertSqlSurveyQuestionShowCondition(SqlSurveyQuestionShowCondition surveyQuestionShowCondition)
    {
        var command = InsertSqlSurveyQuestionShowConditionCommand(
            surveyQuestionShowCondition.SurveyId,
            surveyQuestionShowCondition.SurveyPageIndex,
            surveyQuestionShowCondition.SurveyQuestionIndex,
            surveyQuestionShowCondition.SurveyQuestionShowConditionIndex,
            surveyQuestionShowCondition.SurveyQuestionShowConditionType,
            surveyQuestionShowCondition.SurveyQuestionShowConditionOperator);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionShowConditionAsync(SqlSurveyQuestionShowCondition surveyQuestionShowCondition)
        => InsertSqlSurveyQuestionShowConditionAsync(surveyQuestionShowCondition, CancellationToken.None);

    public Task InsertSqlSurveyQuestionShowConditionAsync(
        SqlSurveyQuestionShowCondition surveyQuestionShowCondition,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionShowConditionCommand(
            surveyQuestionShowCondition.SurveyId,
            surveyQuestionShowCondition.SurveyPageIndex,
            surveyQuestionShowCondition.SurveyQuestionIndex,
            surveyQuestionShowCondition.SurveyQuestionShowConditionIndex,
            surveyQuestionShowCondition.SurveyQuestionShowConditionType,
            surveyQuestionShowCondition.SurveyQuestionShowConditionOperator);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionShowConditionsRefArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index] FROM [survey_question_show_conditions_ref_args] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_show_condition_index,[object Object]] = @survey_question_show_condition_index,[object Object] AND [survey_question_show_condition_arg_index,[object Object]] = @survey_question_show_condition_arg_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;
        command.Parameters.Add("survey_question_show_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionArgIndex;

        return command;
    }

    public SqlSurveyQuestionShowConditionsRefArg? SelectUniqueSqlSurveyQuestionShowConditionsRefArg(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionsRefArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionArgIndex: reader.GetSqlInt32(4),
            ReferencedSurveyPageIndex: reader.GetSqlInt32(5),
            ReferencedSurveyQuestionIndex: reader.GetSqlInt32(6));
    }

    public Task<SqlSurveyQuestionShowConditionsRefArg?> SelectUniqueSqlSurveyQuestionShowConditionsRefArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        return SelectUniqueSqlSurveyQuestionShowConditionsRefArgAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionShowConditionsRefArg?> SelectUniqueSqlSurveyQuestionShowConditionsRefArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionsRefArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionArgIndex: reader.GetSqlInt32(4),
            ReferencedSurveyPageIndex: reader.GetSqlInt32(5),
            ReferencedSurveyQuestionIndex: reader.GetSqlInt32(6));
    }

    private SqlCommand InsertSqlSurveyQuestionShowConditionsRefArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex,
        SqlInt32 referencedSurveyPageIndex,
        SqlInt32 referencedSurveyQuestionIndex)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_show_conditions_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_show_condition_index, @survey_question_show_condition_arg_index, @referenced_survey_page_index, @referenced_survey_question_index)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;
        command.Parameters.Add("survey_question_show_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionArgIndex;
        command.Parameters.Add("referenced_survey_page_index", SqlDbType.Int).SqlValue = referencedSurveyPageIndex;
        command.Parameters.Add("referenced_survey_question_index", SqlDbType.Int).SqlValue = referencedSurveyQuestionIndex;

        return command;
    }

    public void InsertSqlSurveyQuestionShowConditionsRefArg(SqlSurveyQuestionShowConditionsRefArg surveyQuestionShowConditionsRefArg)
    {
        var command = InsertSqlSurveyQuestionShowConditionsRefArgCommand(
            surveyQuestionShowConditionsRefArg.SurveyId,
            surveyQuestionShowConditionsRefArg.SurveyPageIndex,
            surveyQuestionShowConditionsRefArg.SurveyQuestionIndex,
            surveyQuestionShowConditionsRefArg.SurveyQuestionShowConditionIndex,
            surveyQuestionShowConditionsRefArg.SurveyQuestionShowConditionArgIndex,
            surveyQuestionShowConditionsRefArg.ReferencedSurveyPageIndex,
            surveyQuestionShowConditionsRefArg.ReferencedSurveyQuestionIndex);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionShowConditionsRefArgAsync(SqlSurveyQuestionShowConditionsRefArg surveyQuestionShowConditionsRefArg)
        => InsertSqlSurveyQuestionShowConditionsRefArgAsync(surveyQuestionShowConditionsRefArg, CancellationToken.None);

    public Task InsertSqlSurveyQuestionShowConditionsRefArgAsync(
        SqlSurveyQuestionShowConditionsRefArg surveyQuestionShowConditionsRefArg,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionShowConditionsRefArgCommand(
            surveyQuestionShowConditionsRefArg.SurveyId,
            surveyQuestionShowConditionsRefArg.SurveyPageIndex,
            surveyQuestionShowConditionsRefArg.SurveyQuestionIndex,
            surveyQuestionShowConditionsRefArg.SurveyQuestionShowConditionIndex,
            surveyQuestionShowConditionsRefArg.SurveyQuestionShowConditionArgIndex,
            surveyQuestionShowConditionsRefArg.ReferencedSurveyPageIndex,
            surveyQuestionShowConditionsRefArg.ReferencedSurveyQuestionIndex);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionShowConditionsIntegerArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [survey_question_show_condition_arg_integer] FROM [survey_question_show_conditions_integer_args] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_show_condition_index,[object Object]] = @survey_question_show_condition_index,[object Object] AND [survey_question_show_condition_arg_index,[object Object]] = @survey_question_show_condition_arg_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;
        command.Parameters.Add("survey_question_show_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionArgIndex;

        return command;
    }

    public SqlSurveyQuestionShowConditionsIntegerArg? SelectUniqueSqlSurveyQuestionShowConditionsIntegerArg(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionsIntegerArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionShowConditionArgInteger: reader.GetSqlInt32(5));
    }

    public Task<SqlSurveyQuestionShowConditionsIntegerArg?> SelectUniqueSqlSurveyQuestionShowConditionsIntegerArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        return SelectUniqueSqlSurveyQuestionShowConditionsIntegerArgAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionShowConditionsIntegerArg?> SelectUniqueSqlSurveyQuestionShowConditionsIntegerArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionsIntegerArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionShowConditionArgInteger: reader.GetSqlInt32(5));
    }

    private SqlCommand InsertSqlSurveyQuestionShowConditionsIntegerArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex,
        SqlInt32 surveyQuestionShowConditionArgInteger)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_show_conditions_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [survey_question_show_condition_arg_integer]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_show_condition_index, @survey_question_show_condition_arg_index, @survey_question_show_condition_arg_integer)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;
        command.Parameters.Add("survey_question_show_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionArgIndex;
        command.Parameters.Add("survey_question_show_condition_arg_integer", SqlDbType.Int).SqlValue = surveyQuestionShowConditionArgInteger;

        return command;
    }

    public void InsertSqlSurveyQuestionShowConditionsIntegerArg(SqlSurveyQuestionShowConditionsIntegerArg surveyQuestionShowConditionsIntegerArg)
    {
        var command = InsertSqlSurveyQuestionShowConditionsIntegerArgCommand(
            surveyQuestionShowConditionsIntegerArg.SurveyId,
            surveyQuestionShowConditionsIntegerArg.SurveyPageIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionShowConditionIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionShowConditionArgIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionShowConditionArgInteger);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionShowConditionsIntegerArgAsync(SqlSurveyQuestionShowConditionsIntegerArg surveyQuestionShowConditionsIntegerArg)
        => InsertSqlSurveyQuestionShowConditionsIntegerArgAsync(surveyQuestionShowConditionsIntegerArg, CancellationToken.None);

    public Task InsertSqlSurveyQuestionShowConditionsIntegerArgAsync(
        SqlSurveyQuestionShowConditionsIntegerArg surveyQuestionShowConditionsIntegerArg,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionShowConditionsIntegerArgCommand(
            surveyQuestionShowConditionsIntegerArg.SurveyId,
            surveyQuestionShowConditionsIntegerArg.SurveyPageIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionShowConditionIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionShowConditionArgIndex,
            surveyQuestionShowConditionsIntegerArg.SurveyQuestionShowConditionArgInteger);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionShowConditionsTextArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [survey_question_show_condition_arg_text] FROM [survey_question_show_conditions_text_args] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_show_condition_index,[object Object]] = @survey_question_show_condition_index,[object Object] AND [survey_question_show_condition_arg_index,[object Object]] = @survey_question_show_condition_arg_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;
        command.Parameters.Add("survey_question_show_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionArgIndex;

        return command;
    }

    public SqlSurveyQuestionShowConditionsTextArg? SelectUniqueSqlSurveyQuestionShowConditionsTextArg(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionsTextArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionShowConditionArgText: reader.GetSqlString(5));
    }

    public Task<SqlSurveyQuestionShowConditionsTextArg?> SelectUniqueSqlSurveyQuestionShowConditionsTextArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex)
    {
        return SelectUniqueSqlSurveyQuestionShowConditionsTextArgAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionShowConditionsTextArg?> SelectUniqueSqlSurveyQuestionShowConditionsTextArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionShowConditionsTextArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionShowConditionIndex,
            surveyQuestionShowConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionShowConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionShowConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionShowConditionArgText: reader.GetSqlString(5));
    }

    private SqlCommand InsertSqlSurveyQuestionShowConditionsTextArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionShowConditionIndex,
        SqlInt32 surveyQuestionShowConditionArgIndex,
        SqlString surveyQuestionShowConditionArgText)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_show_conditions_text_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [survey_question_show_condition_arg_text]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_show_condition_index, @survey_question_show_condition_arg_index, @survey_question_show_condition_arg_text)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_show_condition_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionIndex;
        command.Parameters.Add("survey_question_show_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionShowConditionArgIndex;
        command.Parameters.Add("survey_question_show_condition_arg_text", SqlDbType.VarChar, VARCHAR_MAX_LENGTH).SqlValue = surveyQuestionShowConditionArgText;

        return command;
    }

    public void InsertSqlSurveyQuestionShowConditionsTextArg(SqlSurveyQuestionShowConditionsTextArg surveyQuestionShowConditionsTextArg)
    {
        var command = InsertSqlSurveyQuestionShowConditionsTextArgCommand(
            surveyQuestionShowConditionsTextArg.SurveyId,
            surveyQuestionShowConditionsTextArg.SurveyPageIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionShowConditionIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionShowConditionArgIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionShowConditionArgText);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionShowConditionsTextArgAsync(SqlSurveyQuestionShowConditionsTextArg surveyQuestionShowConditionsTextArg)
        => InsertSqlSurveyQuestionShowConditionsTextArgAsync(surveyQuestionShowConditionsTextArg, CancellationToken.None);

    public Task InsertSqlSurveyQuestionShowConditionsTextArgAsync(
        SqlSurveyQuestionShowConditionsTextArg surveyQuestionShowConditionsTextArg,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionShowConditionsTextArgCommand(
            surveyQuestionShowConditionsTextArg.SurveyId,
            surveyQuestionShowConditionsTextArg.SurveyPageIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionShowConditionIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionShowConditionArgIndex,
            surveyQuestionShowConditionsTextArg.SurveyQuestionShowConditionArgText);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionValidationConditionTypeCommand(
        SqlByte surveyQuestionValidationConditionTypeId)
    {
        var command = new SqlCommand(
            "SELECT [survey_question_validation_condition_type_id], [survey_question_validation_condition_type_name] FROM [survey_question_validation_condition_types] WHERE [survey_question_validation_condition_type_id,[object Object]] = @survey_question_validation_condition_type_id,[object Object]",
            source);

        command.Parameters.Add("survey_question_validation_condition_type_id", SqlDbType.TinyInt).SqlValue = surveyQuestionValidationConditionTypeId;

        return command;
    }

    public SqlSurveyQuestionValidationConditionType? SelectUniqueSqlSurveyQuestionValidationConditionType(
        SqlByte surveyQuestionValidationConditionTypeId)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionTypeCommand(
            surveyQuestionValidationConditionTypeId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyQuestionValidationConditionTypeId: reader.GetSqlByte(0),
            SurveyQuestionValidationConditionTypeName: reader.GetSqlString(1));
    }

    public Task<SqlSurveyQuestionValidationConditionType?> SelectUniqueSqlSurveyQuestionValidationConditionTypeAsync(
        SqlByte surveyQuestionValidationConditionTypeId)
    {
        return SelectUniqueSqlSurveyQuestionValidationConditionTypeAsync(
            surveyQuestionValidationConditionTypeId,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionValidationConditionType?> SelectUniqueSqlSurveyQuestionValidationConditionTypeAsync(
        SqlByte surveyQuestionValidationConditionTypeId,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionTypeCommand(
            surveyQuestionValidationConditionTypeId);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyQuestionValidationConditionTypeId: reader.GetSqlByte(0),
            SurveyQuestionValidationConditionTypeName: reader.GetSqlString(1));
    }

    private SqlCommand InsertSqlSurveyQuestionValidationConditionTypeCommand(
        SqlByte surveyQuestionValidationConditionTypeId,
        SqlString surveyQuestionValidationConditionTypeName)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_validation_condition_types] ([survey_question_validation_condition_type_id], [survey_question_validation_condition_type_name]) VALUES (@survey_question_validation_condition_type_id, @survey_question_validation_condition_type_name)",
            source);

        command.Parameters.Add("survey_question_validation_condition_type_id", SqlDbType.TinyInt).SqlValue = surveyQuestionValidationConditionTypeId;
        command.Parameters.Add("survey_question_validation_condition_type_name", SqlDbType.VarChar, 255).SqlValue = surveyQuestionValidationConditionTypeName;

        return command;
    }

    public void InsertSqlSurveyQuestionValidationConditionType(SqlSurveyQuestionValidationConditionType surveyQuestionValidationConditionType)
    {
        var command = InsertSqlSurveyQuestionValidationConditionTypeCommand(
            surveyQuestionValidationConditionType.SurveyQuestionValidationConditionTypeId,
            surveyQuestionValidationConditionType.SurveyQuestionValidationConditionTypeName);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionValidationConditionTypeAsync(SqlSurveyQuestionValidationConditionType surveyQuestionValidationConditionType)
        => InsertSqlSurveyQuestionValidationConditionTypeAsync(surveyQuestionValidationConditionType, CancellationToken.None);

    public Task InsertSqlSurveyQuestionValidationConditionTypeAsync(
        SqlSurveyQuestionValidationConditionType surveyQuestionValidationConditionType,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionValidationConditionTypeCommand(
            surveyQuestionValidationConditionType.SurveyQuestionValidationConditionTypeId,
            surveyQuestionValidationConditionType.SurveyQuestionValidationConditionTypeName);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionValidationConditionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator] FROM [survey_question_validation_conditions] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_validation_condition_index,[object Object]] = @survey_question_validation_condition_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;

        return command;
    }

    public SqlSurveyQuestionValidationCondition? SelectUniqueSqlSurveyQuestionValidationCondition(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionType: reader.GetSqlByte(4),
            SurveyQuestionValidationConditionOperator: reader.GetSqlBoolean(5));
    }

    public Task<SqlSurveyQuestionValidationCondition?> SelectUniqueSqlSurveyQuestionValidationConditionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex)
    {
        return SelectUniqueSqlSurveyQuestionValidationConditionAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionValidationCondition?> SelectUniqueSqlSurveyQuestionValidationConditionAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionType: reader.GetSqlByte(4),
            SurveyQuestionValidationConditionOperator: reader.GetSqlBoolean(5));
    }

    private SqlCommand InsertSqlSurveyQuestionValidationConditionCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlByte surveyQuestionValidationConditionType,
        SqlBoolean surveyQuestionValidationConditionOperator)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_validation_condition_index, @survey_question_validation_condition_type, @survey_question_validation_condition_operator)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;
        command.Parameters.Add("survey_question_validation_condition_type", SqlDbType.TinyInt).SqlValue = surveyQuestionValidationConditionType;
        command.Parameters.Add("survey_question_validation_condition_operator", SqlDbType.Bit).SqlValue = surveyQuestionValidationConditionOperator;

        return command;
    }

    public void InsertSqlSurveyQuestionValidationCondition(SqlSurveyQuestionValidationCondition surveyQuestionValidationCondition)
    {
        var command = InsertSqlSurveyQuestionValidationConditionCommand(
            surveyQuestionValidationCondition.SurveyId,
            surveyQuestionValidationCondition.SurveyPageIndex,
            surveyQuestionValidationCondition.SurveyQuestionIndex,
            surveyQuestionValidationCondition.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationCondition.SurveyQuestionValidationConditionType,
            surveyQuestionValidationCondition.SurveyQuestionValidationConditionOperator);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionValidationConditionAsync(SqlSurveyQuestionValidationCondition surveyQuestionValidationCondition)
        => InsertSqlSurveyQuestionValidationConditionAsync(surveyQuestionValidationCondition, CancellationToken.None);

    public Task InsertSqlSurveyQuestionValidationConditionAsync(
        SqlSurveyQuestionValidationCondition surveyQuestionValidationCondition,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionValidationConditionCommand(
            surveyQuestionValidationCondition.SurveyId,
            surveyQuestionValidationCondition.SurveyPageIndex,
            surveyQuestionValidationCondition.SurveyQuestionIndex,
            surveyQuestionValidationCondition.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationCondition.SurveyQuestionValidationConditionType,
            surveyQuestionValidationCondition.SurveyQuestionValidationConditionOperator);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionValidationConditionsRefArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index] FROM [survey_question_validation_conditions_ref_args] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_validation_condition_index,[object Object]] = @survey_question_validation_condition_index,[object Object] AND [survey_question_validation_condition_arg_index,[object Object]] = @survey_question_validation_condition_arg_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionArgIndex;

        return command;
    }

    public SqlSurveyQuestionValidationConditionsRefArg? SelectUniqueSqlSurveyQuestionValidationConditionsRefArg(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionsRefArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionArgIndex: reader.GetSqlInt32(4),
            ReferencedSurveyPageIndex: reader.GetSqlInt32(5),
            ReferencedSurveyQuestionIndex: reader.GetSqlInt32(6));
    }

    public Task<SqlSurveyQuestionValidationConditionsRefArg?> SelectUniqueSqlSurveyQuestionValidationConditionsRefArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        return SelectUniqueSqlSurveyQuestionValidationConditionsRefArgAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionValidationConditionsRefArg?> SelectUniqueSqlSurveyQuestionValidationConditionsRefArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionsRefArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionArgIndex: reader.GetSqlInt32(4),
            ReferencedSurveyPageIndex: reader.GetSqlInt32(5),
            ReferencedSurveyQuestionIndex: reader.GetSqlInt32(6));
    }

    private SqlCommand InsertSqlSurveyQuestionValidationConditionsRefArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex,
        SqlInt32 referencedSurveyPageIndex,
        SqlInt32 referencedSurveyQuestionIndex)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_validation_conditions_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_validation_condition_index, @survey_question_validation_condition_arg_index, @referenced_survey_page_index, @referenced_survey_question_index)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionArgIndex;
        command.Parameters.Add("referenced_survey_page_index", SqlDbType.Int).SqlValue = referencedSurveyPageIndex;
        command.Parameters.Add("referenced_survey_question_index", SqlDbType.Int).SqlValue = referencedSurveyQuestionIndex;

        return command;
    }

    public void InsertSqlSurveyQuestionValidationConditionsRefArg(SqlSurveyQuestionValidationConditionsRefArg surveyQuestionValidationConditionsRefArg)
    {
        var command = InsertSqlSurveyQuestionValidationConditionsRefArgCommand(
            surveyQuestionValidationConditionsRefArg.SurveyId,
            surveyQuestionValidationConditionsRefArg.SurveyPageIndex,
            surveyQuestionValidationConditionsRefArg.SurveyQuestionIndex,
            surveyQuestionValidationConditionsRefArg.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionsRefArg.SurveyQuestionValidationConditionArgIndex,
            surveyQuestionValidationConditionsRefArg.ReferencedSurveyPageIndex,
            surveyQuestionValidationConditionsRefArg.ReferencedSurveyQuestionIndex);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionValidationConditionsRefArgAsync(SqlSurveyQuestionValidationConditionsRefArg surveyQuestionValidationConditionsRefArg)
        => InsertSqlSurveyQuestionValidationConditionsRefArgAsync(surveyQuestionValidationConditionsRefArg, CancellationToken.None);

    public Task InsertSqlSurveyQuestionValidationConditionsRefArgAsync(
        SqlSurveyQuestionValidationConditionsRefArg surveyQuestionValidationConditionsRefArg,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionValidationConditionsRefArgCommand(
            surveyQuestionValidationConditionsRefArg.SurveyId,
            surveyQuestionValidationConditionsRefArg.SurveyPageIndex,
            surveyQuestionValidationConditionsRefArg.SurveyQuestionIndex,
            surveyQuestionValidationConditionsRefArg.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionsRefArg.SurveyQuestionValidationConditionArgIndex,
            surveyQuestionValidationConditionsRefArg.ReferencedSurveyPageIndex,
            surveyQuestionValidationConditionsRefArg.ReferencedSurveyQuestionIndex);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionValidationConditionsIntegerArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer] FROM [survey_question_validation_conditions_integer_args] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_validation_condition_index,[object Object]] = @survey_question_validation_condition_index,[object Object] AND [survey_question_validation_condition_arg_index,[object Object]] = @survey_question_validation_condition_arg_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionArgIndex;

        return command;
    }

    public SqlSurveyQuestionValidationConditionsIntegerArg? SelectUniqueSqlSurveyQuestionValidationConditionsIntegerArg(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionsIntegerArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionValidationConditionArgInteger: reader.GetSqlInt32(5));
    }

    public Task<SqlSurveyQuestionValidationConditionsIntegerArg?> SelectUniqueSqlSurveyQuestionValidationConditionsIntegerArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        return SelectUniqueSqlSurveyQuestionValidationConditionsIntegerArgAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionValidationConditionsIntegerArg?> SelectUniqueSqlSurveyQuestionValidationConditionsIntegerArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionsIntegerArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionValidationConditionArgInteger: reader.GetSqlInt32(5));
    }

    private SqlCommand InsertSqlSurveyQuestionValidationConditionsIntegerArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex,
        SqlInt32 surveyQuestionValidationConditionArgInteger)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_validation_conditions_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_validation_condition_index, @survey_question_validation_condition_arg_index, @survey_question_validation_condition_arg_integer)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionArgIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_integer", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionArgInteger;

        return command;
    }

    public void InsertSqlSurveyQuestionValidationConditionsIntegerArg(SqlSurveyQuestionValidationConditionsIntegerArg surveyQuestionValidationConditionsIntegerArg)
    {
        var command = InsertSqlSurveyQuestionValidationConditionsIntegerArgCommand(
            surveyQuestionValidationConditionsIntegerArg.SurveyId,
            surveyQuestionValidationConditionsIntegerArg.SurveyPageIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionValidationConditionArgIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionValidationConditionArgInteger);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionValidationConditionsIntegerArgAsync(SqlSurveyQuestionValidationConditionsIntegerArg surveyQuestionValidationConditionsIntegerArg)
        => InsertSqlSurveyQuestionValidationConditionsIntegerArgAsync(surveyQuestionValidationConditionsIntegerArg, CancellationToken.None);

    public Task InsertSqlSurveyQuestionValidationConditionsIntegerArgAsync(
        SqlSurveyQuestionValidationConditionsIntegerArg surveyQuestionValidationConditionsIntegerArg,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionValidationConditionsIntegerArgCommand(
            surveyQuestionValidationConditionsIntegerArg.SurveyId,
            surveyQuestionValidationConditionsIntegerArg.SurveyPageIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionValidationConditionArgIndex,
            surveyQuestionValidationConditionsIntegerArg.SurveyQuestionValidationConditionArgInteger);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }

    private SqlCommand SelectUniqueSqlSurveyQuestionValidationConditionsTextArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        var command = new SqlCommand(
            "SELECT [survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_text] FROM [survey_question_validation_conditions_text_args] WHERE [survey_id,[object Object]] = @survey_id,[object Object] AND [survey_page_index,[object Object]] = @survey_page_index,[object Object] AND [survey_question_index,[object Object]] = @survey_question_index,[object Object] AND [survey_question_validation_condition_index,[object Object]] = @survey_question_validation_condition_index,[object Object] AND [survey_question_validation_condition_arg_index,[object Object]] = @survey_question_validation_condition_arg_index,[object Object]",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionArgIndex;

        return command;
    }

    public SqlSurveyQuestionValidationConditionsTextArg? SelectUniqueSqlSurveyQuestionValidationConditionsTextArg(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionsTextArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionValidationConditionArgText: reader.GetSqlString(5));
    }

    public Task<SqlSurveyQuestionValidationConditionsTextArg?> SelectUniqueSqlSurveyQuestionValidationConditionsTextArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex)
    {
        return SelectUniqueSqlSurveyQuestionValidationConditionsTextArgAsync(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex,
            CancellationToken.None);
    }

    public async Task<SqlSurveyQuestionValidationConditionsTextArg?> SelectUniqueSqlSurveyQuestionValidationConditionsTextArgAsync(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex,
        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSqlSurveyQuestionValidationConditionsTextArgCommand(
            surveyId,
            surveyPageIndex,
            surveyQuestionIndex,
            surveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionArgIndex);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
            SurveyId: reader.GetSqlInt32(0),
            SurveyPageIndex: reader.GetSqlInt32(1),
            SurveyQuestionIndex: reader.GetSqlInt32(2),
            SurveyQuestionValidationConditionIndex: reader.GetSqlInt32(3),
            SurveyQuestionValidationConditionArgIndex: reader.GetSqlInt32(4),
            SurveyQuestionValidationConditionArgText: reader.GetSqlString(5));
    }

    private SqlCommand InsertSqlSurveyQuestionValidationConditionsTextArgCommand(
        SqlInt32 surveyId,
        SqlInt32 surveyPageIndex,
        SqlInt32 surveyQuestionIndex,
        SqlInt32 surveyQuestionValidationConditionIndex,
        SqlInt32 surveyQuestionValidationConditionArgIndex,
        SqlString surveyQuestionValidationConditionArgText)
    {
        var command = new SqlCommand(
            "INSERT INTO [survey_question_validation_conditions_text_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_text]) VALUES (@survey_id, @survey_page_index, @survey_question_index, @survey_question_validation_condition_index, @survey_question_validation_condition_arg_index, @survey_question_validation_condition_arg_text)",
            source);

        command.Parameters.Add("survey_id", SqlDbType.Int).SqlValue = surveyId;
        command.Parameters.Add("survey_page_index", SqlDbType.Int).SqlValue = surveyPageIndex;
        command.Parameters.Add("survey_question_index", SqlDbType.Int).SqlValue = surveyQuestionIndex;
        command.Parameters.Add("survey_question_validation_condition_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_index", SqlDbType.Int).SqlValue = surveyQuestionValidationConditionArgIndex;
        command.Parameters.Add("survey_question_validation_condition_arg_text", SqlDbType.VarChar, VARCHAR_MAX_LENGTH).SqlValue = surveyQuestionValidationConditionArgText;

        return command;
    }

    public void InsertSqlSurveyQuestionValidationConditionsTextArg(SqlSurveyQuestionValidationConditionsTextArg surveyQuestionValidationConditionsTextArg)
    {
        var command = InsertSqlSurveyQuestionValidationConditionsTextArgCommand(
            surveyQuestionValidationConditionsTextArg.SurveyId,
            surveyQuestionValidationConditionsTextArg.SurveyPageIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionValidationConditionArgIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionValidationConditionArgText);

        command.ExecuteNonQuery();
    }

    public Task InsertSqlSurveyQuestionValidationConditionsTextArgAsync(SqlSurveyQuestionValidationConditionsTextArg surveyQuestionValidationConditionsTextArg)
        => InsertSqlSurveyQuestionValidationConditionsTextArgAsync(surveyQuestionValidationConditionsTextArg, CancellationToken.None);

    public Task InsertSqlSurveyQuestionValidationConditionsTextArgAsync(
        SqlSurveyQuestionValidationConditionsTextArg surveyQuestionValidationConditionsTextArg,
        CancellationToken cancellationToken)
    {
        var command = InsertSqlSurveyQuestionValidationConditionsTextArgCommand(
            surveyQuestionValidationConditionsTextArg.SurveyId,
            surveyQuestionValidationConditionsTextArg.SurveyPageIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionValidationConditionIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionValidationConditionArgIndex,
            surveyQuestionValidationConditionsTextArg.SurveyQuestionValidationConditionArgText);

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
    int surveyTitleColumnIndex,
    int surveyAuthorColumnIndex,
    int surveyDescriptionColumnIndex,
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
            SurveyTitle: source.GetSqlString(surveyTitleColumnIndex),
            SurveyAuthor: source.GetSqlString(surveyAuthorColumnIndex),
            SurveyDescription: source.GetSqlString(surveyDescriptionColumnIndex));
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
    int surveyPageTitleColumnIndex,
    int surveyPageDescriptionColumnIndex,
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
            SurveyPageTitle: source.GetSqlString(surveyPageTitleColumnIndex),
            SurveyPageDescription: source.GetSqlString(surveyPageDescriptionColumnIndex));
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

public class SqlAnswerTypeReader(
    SqlDataReader source,
    int answerTypeIdColumnIndex,
    int answerTypeNameColumnIndex,
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
            AnswerTypeName: source.GetSqlString(answerTypeNameColumnIndex));
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

public class SqlSurveyQuestionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionPromptColumnIndex,
    int surveyQuestionAnswerTypeColumnIndex,
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
            SurveyQuestionPrompt: source.GetSqlString(surveyQuestionPromptColumnIndex),
            SurveyQuestionAnswerType: source.GetSqlByte(surveyQuestionAnswerTypeColumnIndex));
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

public class SqlRegisteredMemberReader(
    SqlDataReader source,
    int registeredMemberIdColumnIndex,
    int registeredMemberPasswordHashColumnIndex,
    int registeredMemberPhoneNumberColumnIndex,
    int registeredMemberBirthDateColumnIndex,
    int registeredMemberFirstNameColumnIndex,
    int registeredMemberLastNameColumnIndex,
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
            RegisteredMemberPasswordHash: source.GetSqlString(registeredMemberPasswordHashColumnIndex),
            RegisteredMemberPhoneNumber: source.GetSqlString(registeredMemberPhoneNumberColumnIndex),
            RegisteredMemberBirthDate: source.GetSqlDateTime(registeredMemberBirthDateColumnIndex),
            RegisteredMemberFirstName: source.GetSqlString(registeredMemberFirstNameColumnIndex),
            RegisteredMemberLastName: source.GetSqlString(registeredMemberLastNameColumnIndex));
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

public class SqlSubmissionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int submissionIndexColumnIndex,
    int registeredMemberIdColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSubmission>, IEnumerator<SqlSubmission>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSubmission Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SubmissionIndex: source.GetSqlInt32(submissionIndexColumnIndex),
            RegisteredMemberId: source.GetSqlInt32(registeredMemberIdColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSubmission IAsyncEnumerator<SqlSubmission>.Current => Current;

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

public class SqlSubmissionTextAnswerReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int submissionIndexColumnIndex,
    int submissionAnswerIndexColumnIndex,
    int submissionAnswerTextColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSubmissionTextAnswer>, IEnumerator<SqlSubmissionTextAnswer>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSubmissionTextAnswer Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SubmissionIndex: source.GetSqlInt32(submissionIndexColumnIndex),
            SubmissionAnswerIndex: source.GetSqlInt32(submissionAnswerIndexColumnIndex),
            SubmissionAnswerText: source.GetSqlString(submissionAnswerTextColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSubmissionTextAnswer IAsyncEnumerator<SqlSubmissionTextAnswer>.Current => Current;

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

public class SqlSubmissionIntegerAnswerReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int submissionIndexColumnIndex,
    int submissionAnswerIndexColumnIndex,
    int submissionAnswerIntegerColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSubmissionIntegerAnswer>, IEnumerator<SqlSubmissionIntegerAnswer>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSubmissionIntegerAnswer Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SubmissionIndex: source.GetSqlInt32(submissionIndexColumnIndex),
            SubmissionAnswerIndex: source.GetSqlInt32(submissionAnswerIndexColumnIndex),
            SubmissionAnswerInteger: source.GetSqlInt32(submissionAnswerIntegerColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSubmissionIntegerAnswer IAsyncEnumerator<SqlSubmissionIntegerAnswer>.Current => Current;

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

public class SqlSubmissionBoolAnswerReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int submissionIndexColumnIndex,
    int submissionAnswerIndexColumnIndex,
    int submissionAnswerBoolColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSubmissionBoolAnswer>, IEnumerator<SqlSubmissionBoolAnswer>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSubmissionBoolAnswer Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SubmissionIndex: source.GetSqlInt32(submissionIndexColumnIndex),
            SubmissionAnswerIndex: source.GetSqlInt32(submissionAnswerIndexColumnIndex),
            SubmissionAnswerBool: source.GetSqlBoolean(submissionAnswerBoolColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSubmissionBoolAnswer IAsyncEnumerator<SqlSubmissionBoolAnswer>.Current => Current;

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

public class SqlSurveyQuestionAnswerOptionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyAnswerOptionIndexColumnIndex,
    int surveyAnswerOptionTextColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionAnswerOption>, IEnumerator<SqlSurveyQuestionAnswerOption>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionAnswerOption Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyAnswerOptionIndex: source.GetSqlInt32(surveyAnswerOptionIndexColumnIndex),
            SurveyAnswerOptionText: source.GetSqlString(surveyAnswerOptionTextColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionAnswerOption IAsyncEnumerator<SqlSurveyQuestionAnswerOption>.Current => Current;

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

public class SqlSurveyQuestionShowConditionTypeReader(
    SqlDataReader source,
    int surveyQuestionShowConditionTypeIdColumnIndex,
    int surveyQuestionShowConditionTypeNameColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionShowConditionType>, IEnumerator<SqlSurveyQuestionShowConditionType>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionShowConditionType Current
    {
        get => new(
            SurveyQuestionShowConditionTypeId: source.GetSqlByte(surveyQuestionShowConditionTypeIdColumnIndex),
            SurveyQuestionShowConditionTypeName: source.GetSqlString(surveyQuestionShowConditionTypeNameColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionShowConditionType IAsyncEnumerator<SqlSurveyQuestionShowConditionType>.Current => Current;

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

public class SqlSurveyQuestionShowConditionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionShowConditionIndexColumnIndex,
    int surveyQuestionShowConditionTypeColumnIndex,
    int surveyQuestionShowConditionOperatorColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionShowCondition>, IEnumerator<SqlSurveyQuestionShowCondition>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionShowCondition Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionShowConditionIndex: source.GetSqlInt32(surveyQuestionShowConditionIndexColumnIndex),
            SurveyQuestionShowConditionType: source.GetSqlByte(surveyQuestionShowConditionTypeColumnIndex),
            SurveyQuestionShowConditionOperator: source.GetSqlBoolean(surveyQuestionShowConditionOperatorColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionShowCondition IAsyncEnumerator<SqlSurveyQuestionShowCondition>.Current => Current;

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

public class SqlSurveyQuestionShowConditionsRefArgReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionShowConditionIndexColumnIndex,
    int surveyQuestionShowConditionArgIndexColumnIndex,
    int referencedSurveyPageIndexColumnIndex,
    int referencedSurveyQuestionIndexColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionShowConditionsRefArg>, IEnumerator<SqlSurveyQuestionShowConditionsRefArg>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionShowConditionsRefArg Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionShowConditionIndex: source.GetSqlInt32(surveyQuestionShowConditionIndexColumnIndex),
            SurveyQuestionShowConditionArgIndex: source.GetSqlInt32(surveyQuestionShowConditionArgIndexColumnIndex),
            ReferencedSurveyPageIndex: source.GetSqlInt32(referencedSurveyPageIndexColumnIndex),
            ReferencedSurveyQuestionIndex: source.GetSqlInt32(referencedSurveyQuestionIndexColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionShowConditionsRefArg IAsyncEnumerator<SqlSurveyQuestionShowConditionsRefArg>.Current => Current;

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

public class SqlSurveyQuestionShowConditionsIntegerArgReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionShowConditionIndexColumnIndex,
    int surveyQuestionShowConditionArgIndexColumnIndex,
    int surveyQuestionShowConditionArgIntegerColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionShowConditionsIntegerArg>, IEnumerator<SqlSurveyQuestionShowConditionsIntegerArg>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionShowConditionsIntegerArg Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionShowConditionIndex: source.GetSqlInt32(surveyQuestionShowConditionIndexColumnIndex),
            SurveyQuestionShowConditionArgIndex: source.GetSqlInt32(surveyQuestionShowConditionArgIndexColumnIndex),
            SurveyQuestionShowConditionArgInteger: source.GetSqlInt32(surveyQuestionShowConditionArgIntegerColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionShowConditionsIntegerArg IAsyncEnumerator<SqlSurveyQuestionShowConditionsIntegerArg>.Current => Current;

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

public class SqlSurveyQuestionShowConditionsTextArgReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionShowConditionIndexColumnIndex,
    int surveyQuestionShowConditionArgIndexColumnIndex,
    int surveyQuestionShowConditionArgTextColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionShowConditionsTextArg>, IEnumerator<SqlSurveyQuestionShowConditionsTextArg>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionShowConditionsTextArg Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionShowConditionIndex: source.GetSqlInt32(surveyQuestionShowConditionIndexColumnIndex),
            SurveyQuestionShowConditionArgIndex: source.GetSqlInt32(surveyQuestionShowConditionArgIndexColumnIndex),
            SurveyQuestionShowConditionArgText: source.GetSqlString(surveyQuestionShowConditionArgTextColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionShowConditionsTextArg IAsyncEnumerator<SqlSurveyQuestionShowConditionsTextArg>.Current => Current;

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

public class SqlSurveyQuestionValidationConditionTypeReader(
    SqlDataReader source,
    int surveyQuestionValidationConditionTypeIdColumnIndex,
    int surveyQuestionValidationConditionTypeNameColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionValidationConditionType>, IEnumerator<SqlSurveyQuestionValidationConditionType>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionValidationConditionType Current
    {
        get => new(
            SurveyQuestionValidationConditionTypeId: source.GetSqlByte(surveyQuestionValidationConditionTypeIdColumnIndex),
            SurveyQuestionValidationConditionTypeName: source.GetSqlString(surveyQuestionValidationConditionTypeNameColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionValidationConditionType IAsyncEnumerator<SqlSurveyQuestionValidationConditionType>.Current => Current;

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

public class SqlSurveyQuestionValidationConditionReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionValidationConditionIndexColumnIndex,
    int surveyQuestionValidationConditionTypeColumnIndex,
    int surveyQuestionValidationConditionOperatorColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionValidationCondition>, IEnumerator<SqlSurveyQuestionValidationCondition>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionValidationCondition Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionValidationConditionIndex: source.GetSqlInt32(surveyQuestionValidationConditionIndexColumnIndex),
            SurveyQuestionValidationConditionType: source.GetSqlByte(surveyQuestionValidationConditionTypeColumnIndex),
            SurveyQuestionValidationConditionOperator: source.GetSqlBoolean(surveyQuestionValidationConditionOperatorColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionValidationCondition IAsyncEnumerator<SqlSurveyQuestionValidationCondition>.Current => Current;

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

public class SqlSurveyQuestionValidationConditionsRefArgReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionValidationConditionIndexColumnIndex,
    int surveyQuestionValidationConditionArgIndexColumnIndex,
    int referencedSurveyPageIndexColumnIndex,
    int referencedSurveyQuestionIndexColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionValidationConditionsRefArg>, IEnumerator<SqlSurveyQuestionValidationConditionsRefArg>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionValidationConditionsRefArg Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionValidationConditionIndex: source.GetSqlInt32(surveyQuestionValidationConditionIndexColumnIndex),
            SurveyQuestionValidationConditionArgIndex: source.GetSqlInt32(surveyQuestionValidationConditionArgIndexColumnIndex),
            ReferencedSurveyPageIndex: source.GetSqlInt32(referencedSurveyPageIndexColumnIndex),
            ReferencedSurveyQuestionIndex: source.GetSqlInt32(referencedSurveyQuestionIndexColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionValidationConditionsRefArg IAsyncEnumerator<SqlSurveyQuestionValidationConditionsRefArg>.Current => Current;

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

public class SqlSurveyQuestionValidationConditionsIntegerArgReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionValidationConditionIndexColumnIndex,
    int surveyQuestionValidationConditionArgIndexColumnIndex,
    int surveyQuestionValidationConditionArgIntegerColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionValidationConditionsIntegerArg>, IEnumerator<SqlSurveyQuestionValidationConditionsIntegerArg>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionValidationConditionsIntegerArg Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionValidationConditionIndex: source.GetSqlInt32(surveyQuestionValidationConditionIndexColumnIndex),
            SurveyQuestionValidationConditionArgIndex: source.GetSqlInt32(surveyQuestionValidationConditionArgIndexColumnIndex),
            SurveyQuestionValidationConditionArgInteger: source.GetSqlInt32(surveyQuestionValidationConditionArgIntegerColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionValidationConditionsIntegerArg IAsyncEnumerator<SqlSurveyQuestionValidationConditionsIntegerArg>.Current => Current;

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

public class SqlSurveyQuestionValidationConditionsTextArgReader(
    SqlDataReader source,
    int surveyIdColumnIndex,
    int surveyPageIndexColumnIndex,
    int surveyQuestionIndexColumnIndex,
    int surveyQuestionValidationConditionIndexColumnIndex,
    int surveyQuestionValidationConditionArgIndexColumnIndex,
    int surveyQuestionValidationConditionArgTextColumnIndex,
    bool sourceConsumed = true) : IAsyncEnumerator<SqlSurveyQuestionValidationConditionsTextArg>, IEnumerator<SqlSurveyQuestionValidationConditionsTextArg>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public SqlSurveyQuestionValidationConditionsTextArg Current
    {
        get => new(
            SurveyId: source.GetSqlInt32(surveyIdColumnIndex),
            SurveyPageIndex: source.GetSqlInt32(surveyPageIndexColumnIndex),
            SurveyQuestionIndex: source.GetSqlInt32(surveyQuestionIndexColumnIndex),
            SurveyQuestionValidationConditionIndex: source.GetSqlInt32(surveyQuestionValidationConditionIndexColumnIndex),
            SurveyQuestionValidationConditionArgIndex: source.GetSqlInt32(surveyQuestionValidationConditionArgIndexColumnIndex),
            SurveyQuestionValidationConditionArgText: source.GetSqlString(surveyQuestionValidationConditionArgTextColumnIndex));
    }

    object IEnumerator.Current => Current;

    SqlSurveyQuestionValidationConditionsTextArg IAsyncEnumerator<SqlSurveyQuestionValidationConditionsTextArg>.Current => Current;

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

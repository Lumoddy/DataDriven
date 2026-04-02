// This file was auto-generated based on ./Build/database/database_structure.yaml

using System.Data.SqlTypes;

namespace DataDriven.Data;

public record SqlSurveyQuestionAnswerType(
    SqlByte Id,
    SqlString Name)
{
    public const string TABLE = "[survey_question_answer_types]";

    public const string ID = $"[survey_question_answer_types].[survey_question_answer_type_id]";

    public const string NAME = $"[survey_question_answer_types].[survey_question_answer_type_name]";
}

public record SqlSurveyQuestionShowConditionType(
    SqlByte Id,
    SqlString Name)
{
    public const string TABLE = "[survey_question_show_condition_types]";

    public const string ID = $"[survey_question_show_condition_types].[survey_question_show_condition_type_id]";

    public const string NAME = $"[survey_question_show_condition_types].[survey_question_show_condition_type_name]";
}

public record SqlSurveyQuestionValidationConditionType(
    SqlByte Id,
    SqlString Name)
{
    public const string TABLE = "[survey_question_validation_condition_types]";

    public const string ID = $"[survey_question_validation_condition_types].[survey_question_validation_condition_type_id]";

    public const string NAME = $"[survey_question_validation_condition_types].[survey_question_validation_condition_type_name]";
}

public record SqlSurvey(
    SqlInt32 Id,
    SqlString Title,
    SqlString Author,
    SqlString Description)
{
    public const string TABLE = "[surveys]";

    public const string ID = $"[surveys].[survey_id]";

    public const string TITLE = $"[surveys].[survey_title]";

    public const string AUTHOR = $"[surveys].[survey_author]";

    public const string DESCRIPTION = $"[surveys].[survey_description]";
}

public record SqlSurveyPage(
    SqlInt32 SurveyId,
    SqlInt32 Index,
    SqlString Title,
    SqlString Description)
{
    public const string TABLE = "[survey_pages]";

    public const string SURVEY_ID = $"[survey_pages].[survey_id]";

    public const string INDEX = $"[survey_pages].[survey_page_index]";

    public const string TITLE = $"[survey_pages].[survey_page_title]";

    public const string DESCRIPTION = $"[survey_pages].[survey_page_description]";
}

public record SqlSurveyQuestion(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 Index,
    SqlString Title,
    SqlByte Type)
{
    public const string TABLE = "[survey_questions]";

    public const string SURVEY_ID = $"[survey_questions].[survey_id]";

    public const string PAGE_INDEX = $"[survey_questions].[survey_page_index]";

    public const string INDEX = $"[survey_questions].[survey_question_index]";

    public const string TITLE = $"[survey_questions].[survey_question_prompt]";

    public const string TYPE = $"[survey_questions].[survey_question_survey_question_answer_type]";
}

public record SqlRegisteredMember(
    SqlInt32 Id,
    SqlString PasswordHash,
    SqlString PhoneNumber,
    SqlDateTime BirthDate,
    SqlString FirstName,
    SqlString LastName)
{
    public const string TABLE = "[registered_members]";

    public const string ID = $"[registered_members].[registered_member_id]";

    public const string PASSWORD_HASH = $"[registered_members].[registered_member_password_hash]";

    public const string PHONE_NUMBER = $"[registered_members].[registered_member_phone_number]";

    public const string BIRTH_DATE = $"[registered_members].[registered_member_birth_date]";

    public const string FIRST_NAME = $"[registered_members].[registered_member_first_name]";

    public const string LAST_NAME = $"[registered_members].[registered_member_last_name]";
}

public record SqlSubmission(
    SqlInt32 SurveyId,
    SqlInt32 Index,
    SqlInt32 RegisteredMemberId)
{
    public const string TABLE = "[submissions]";

    public const string SURVEY_ID = $"[submissions].[survey_id]";

    public const string INDEX = $"[submissions].[submission_index]";

    public const string REGISTERED_MEMBER_ID = $"[submissions].[registered_member_id]";
}

public record SqlSubmissionTextAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 AnswerIndex,
    SqlString Value)
{
    public const string TABLE = "[submission_text_answers]";

    public const string SURVEY_ID = $"[submission_text_answers].[survey_id]";

    public const string PAGE_INDEX = $"[submission_text_answers].[survey_page_index]";

    public const string QUESTION_INDEX = $"[submission_text_answers].[survey_question_index]";

    public const string SUBMISSION_INDEX = $"[submission_text_answers].[submission_index]";

    public const string ANSWER_INDEX = $"[submission_text_answers].[submission_answer_index]";

    public const string VALUE = $"[submission_text_answers].[submission_answer_text]";
}

public record SqlSubmissionIntegerAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 AnswerIndex,
    SqlInt32 Value)
{
    public const string TABLE = "[submission_integer_answers]";

    public const string SURVEY_ID = $"[submission_integer_answers].[survey_id]";

    public const string PAGE_INDEX = $"[submission_integer_answers].[survey_page_index]";

    public const string QUESTION_INDEX = $"[submission_integer_answers].[survey_question_index]";

    public const string SUBMISSION_INDEX = $"[submission_integer_answers].[submission_index]";

    public const string ANSWER_INDEX = $"[submission_integer_answers].[submission_answer_index]";

    public const string VALUE = $"[submission_integer_answers].[submission_answer_integer]";
}

public record SqlSubmissionBoolAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 Index,
    SqlBoolean Value)
{
    public const string TABLE = "[submission_bool_answers]";

    public const string SURVEY_ID = $"[submission_bool_answers].[survey_id]";

    public const string PAGE_INDEX = $"[submission_bool_answers].[survey_page_index]";

    public const string QUESTION_INDEX = $"[submission_bool_answers].[survey_question_index]";

    public const string SUBMISSION_INDEX = $"[submission_bool_answers].[submission_index]";

    public const string INDEX = $"[submission_bool_answers].[submission_answer_index]";

    public const string VALUE = $"[submission_bool_answers].[submission_answer_bool]";
}

public record SqlSurveyQuestionAnswerOption(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlString Text)
{
    public const string TABLE = "[survey_question_answer_options]";

    public const string SURVEY_ID = $"[survey_question_answer_options].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_answer_options].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_answer_options].[survey_question_index]";

    public const string INDEX = $"[survey_question_answer_options].[survey_answer_option_index]";

    public const string TEXT = $"[survey_question_answer_options].[survey_answer_option_text]";
}

public record SqlSurveyQuestionShowCondition(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlByte Type,
    SqlBoolean IsOrOperator)
{
    public const string TABLE = "[survey_question_show_conditions]";

    public const string SURVEY_ID = $"[survey_question_show_conditions].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_show_conditions].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_show_conditions].[survey_question_index]";

    public const string INDEX = $"[survey_question_show_conditions].[survey_question_show_condition_index]";

    public const string TYPE = $"[survey_question_show_conditions].[survey_question_show_condition_type]";

    public const string IS_OR_OPERATOR = $"[survey_question_show_conditions].[survey_question_show_condition_operator]";
}

public record SqlSurveyQuestionShowConditionsRefArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlInt32 ArgIndex,
    SqlInt32 ReferencedPageIndex,
    SqlInt32 ReferencedQuestionIndex)
{
    public const string TABLE = "[survey_question_show_conditions_ref_args]";

    public const string SURVEY_ID = $"[survey_question_show_conditions_ref_args].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_show_conditions_ref_args].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_show_conditions_ref_args].[survey_question_index]";

    public const string INDEX = $"[survey_question_show_conditions_ref_args].[survey_question_show_condition_index]";

    public const string ARG_INDEX = $"[survey_question_show_conditions_ref_args].[survey_question_show_condition_arg_index]";

    public const string REFERENCED_PAGE_INDEX = $"[survey_question_show_conditions_ref_args].[referenced_survey_page_index]";

    public const string REFERENCED_QUESTION_INDEX = $"[survey_question_show_conditions_ref_args].[referenced_survey_question_index]";
}

public record SqlSurveyQuestionShowConditionsIntegerArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlInt32 ArgIndex,
    SqlInt32 ArgValue)
{
    public const string TABLE = "[survey_question_show_conditions_integer_args]";

    public const string SURVEY_ID = $"[survey_question_show_conditions_integer_args].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_show_conditions_integer_args].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_show_conditions_integer_args].[survey_question_index]";

    public const string INDEX = $"[survey_question_show_conditions_integer_args].[survey_question_show_condition_index]";

    public const string ARG_INDEX = $"[survey_question_show_conditions_integer_args].[survey_question_show_condition_arg_index]";

    public const string ARG_VALUE = $"[survey_question_show_conditions_integer_args].[survey_question_show_condition_arg_integer]";
}

public record SqlSurveyQuestionShowConditionsTextArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlInt32 ArgIndex,
    SqlString ArgValue)
{
    public const string TABLE = "[survey_question_show_conditions_text_args]";

    public const string SURVEY_ID = $"[survey_question_show_conditions_text_args].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_show_conditions_text_args].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_show_conditions_text_args].[survey_question_index]";

    public const string INDEX = $"[survey_question_show_conditions_text_args].[survey_question_show_condition_index]";

    public const string ARG_INDEX = $"[survey_question_show_conditions_text_args].[survey_question_show_condition_arg_index]";

    public const string ARG_VALUE = $"[survey_question_show_conditions_text_args].[survey_question_show_condition_arg_text]";
}

public record SqlSurveyQuestionValidationCondition(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlByte Type,
    SqlBoolean IsOrOperator)
{
    public const string TABLE = "[survey_question_validation_conditions]";

    public const string SURVEY_ID = $"[survey_question_validation_conditions].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_validation_conditions].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_validation_conditions].[survey_question_index]";

    public const string INDEX = $"[survey_question_validation_conditions].[survey_question_validation_condition_index]";

    public const string TYPE = $"[survey_question_validation_conditions].[survey_question_validation_condition_type]";

    public const string IS_OR_OPERATOR = $"[survey_question_validation_conditions].[survey_question_validation_condition_operator]";
}

public record SqlSurveyQuestionValidationConditionsRefArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlInt32 ArgIndex,
    SqlInt32 ReferencedPageIndex,
    SqlInt32 ReferencedQuestionIndex)
{
    public const string TABLE = "[survey_question_validation_conditions_ref_args]";

    public const string SURVEY_ID = $"[survey_question_validation_conditions_ref_args].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_validation_conditions_ref_args].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_validation_conditions_ref_args].[survey_question_index]";

    public const string INDEX = $"[survey_question_validation_conditions_ref_args].[survey_question_validation_condition_index]";

    public const string ARG_INDEX = $"[survey_question_validation_conditions_ref_args].[survey_question_validation_condition_arg_index]";

    public const string REFERENCED_PAGE_INDEX = $"[survey_question_validation_conditions_ref_args].[referenced_survey_page_index]";

    public const string REFERENCED_QUESTION_INDEX = $"[survey_question_validation_conditions_ref_args].[referenced_survey_question_index]";
}

public record SqlSurveyQuestionValidationConditionsIntegerArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlInt32 ArgIndex,
    SqlInt32 ArgValue)
{
    public const string TABLE = "[survey_question_validation_conditions_integer_args]";

    public const string SURVEY_ID = $"[survey_question_validation_conditions_integer_args].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_validation_conditions_integer_args].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_validation_conditions_integer_args].[survey_question_index]";

    public const string INDEX = $"[survey_question_validation_conditions_integer_args].[survey_question_validation_condition_index]";

    public const string ARG_INDEX = $"[survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_index]";

    public const string ARG_VALUE = $"[survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_integer]";
}

public record SqlSurveyQuestionValidationConditionsTextArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlInt32 ArgIndex,
    SqlString ArgValue)
{
    public const string TABLE = "[survey_question_validation_conditions_text_args]";

    public const string SURVEY_ID = $"[survey_question_validation_conditions_text_args].[survey_id]";

    public const string PAGE_INDEX = $"[survey_question_validation_conditions_text_args].[survey_page_index]";

    public const string QUESTION_INDEX = $"[survey_question_validation_conditions_text_args].[survey_question_index]";

    public const string INDEX = $"[survey_question_validation_conditions_text_args].[survey_question_validation_condition_index]";

    public const string ARG_INDEX = $"[survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_index]";

    public const string ARG_VALUE = $"[survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_text]";
}

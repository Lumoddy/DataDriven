// This file was auto-generated based on ./Build/database/database_structure.yaml

using System.Data.SqlTypes;

namespace DataDriven.Data;

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_answer_types] (
///     [survey_question_answer_type_id] TINYINT NOT NULL,
///     [survey_question_answer_type_name] VARCHAR(255) NOT NULL);
/// </code>
/// </summary>
/// <param name="Id">
/// Stored in the database as:
/// <code>
/// [survey_question_answer_type_id] TINYINT NOT NULL
/// </code>
/// </param>
/// <param name="Name">
/// Stored in the database as:
/// <code>
/// [survey_question_answer_type_name] VARCHAR(255) NOT NULL
/// </code>
/// </param>
public partial record SqlAnswerType(
    SqlByte Id,
    SqlString Name)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_answer_types] (
    ///     [survey_question_answer_type_id] TINYINT NOT NULL,
    ///     [survey_question_answer_type_name] VARCHAR(255) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_answer_types]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_answer_type_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ID = "[survey_question_answer_types].[survey_question_answer_type_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_answer_type_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_NAME = "[survey_question_answer_types].[survey_question_answer_type_name]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_answer_type_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string ID = "[survey_question_answer_type_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_answer_type_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string NAME = "[survey_question_answer_type_name]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_condition_operator] (
///     [survey_question_condition_operator_id] TINYINT NOT NULL,
///     [survey_question_condition_operator_name] VARCHAR(255) NOT NULL);
/// </code>
/// </summary>
/// <param name="Id">
/// Stored in the database as:
/// <code>
/// [survey_question_condition_operator_id] TINYINT NOT NULL
/// </code>
/// </param>
/// <param name="Name">
/// Stored in the database as:
/// <code>
/// [survey_question_condition_operator_name] VARCHAR(255) NOT NULL
/// </code>
/// </param>
public partial record SqlConditionOperator(
    SqlByte Id,
    SqlString Name)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_condition_operator] (
    ///     [survey_question_condition_operator_id] TINYINT NOT NULL,
    ///     [survey_question_condition_operator_name] VARCHAR(255) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_condition_operator]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_condition_operator_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ID = "[survey_question_condition_operator].[survey_question_condition_operator_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_condition_operator_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_NAME = "[survey_question_condition_operator].[survey_question_condition_operator_name]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_condition_operator_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string ID = "[survey_question_condition_operator_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_condition_operator_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string NAME = "[survey_question_condition_operator_name]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_show_condition_types] (
///     [survey_question_show_condition_type_id] TINYINT NOT NULL,
///     [survey_question_show_condition_type_name] VARCHAR(255) NOT NULL);
/// </code>
/// </summary>
/// <param name="Id">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_type_id] TINYINT NOT NULL
/// </code>
/// </param>
/// <param name="Name">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_type_name] VARCHAR(255) NOT NULL
/// </code>
/// </param>
public partial record SqlShowConditionType(
    SqlByte Id,
    SqlString Name)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_show_condition_types] (
    ///     [survey_question_show_condition_type_id] TINYINT NOT NULL,
    ///     [survey_question_show_condition_type_name] VARCHAR(255) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_show_condition_types]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_type_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ID = "[survey_question_show_condition_types].[survey_question_show_condition_type_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_type_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_NAME = "[survey_question_show_condition_types].[survey_question_show_condition_type_name]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_type_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string ID = "[survey_question_show_condition_type_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_type_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string NAME = "[survey_question_show_condition_type_name]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_validation_condition_types] (
///     [survey_question_validation_condition_type_id] TINYINT NOT NULL,
///     [survey_question_validation_condition_type_name] VARCHAR(255) NOT NULL);
/// </code>
/// </summary>
/// <param name="Id">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_type_id] TINYINT NOT NULL
/// </code>
/// </param>
/// <param name="Name">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_type_name] VARCHAR(255) NOT NULL
/// </code>
/// </param>
public partial record SqlValidationConditionType(
    SqlByte Id,
    SqlString Name)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_validation_condition_types] (
    ///     [survey_question_validation_condition_type_id] TINYINT NOT NULL,
    ///     [survey_question_validation_condition_type_name] VARCHAR(255) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_validation_condition_types]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_type_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ID = "[survey_question_validation_condition_types].[survey_question_validation_condition_type_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_type_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_NAME = "[survey_question_validation_condition_types].[survey_question_validation_condition_type_name]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_type_id] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string ID = "[survey_question_validation_condition_type_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_type_name] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string NAME = "[survey_question_validation_condition_type_name]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [surveys] (
///     [survey_id] INT NOT NULL,
///     [survey_title] NVARCHAR(255) NOT NULL,
///     [survey_author] NVARCHAR(255) NOT NULL,
///     [survey_description] NVARCHAR(MAX) NOT NULL);
/// </code>
/// </summary>
/// <param name="Id">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="Title">
/// Stored in the database as:
/// <code>
/// [survey_title] NVARCHAR(255) NOT NULL
/// </code>
/// </param>
/// <param name="Author">
/// Stored in the database as:
/// <code>
/// [survey_author] NVARCHAR(255) NOT NULL
/// </code>
/// </param>
/// <param name="Description">
/// Stored in the database as:
/// <code>
/// [survey_description] NVARCHAR(MAX) NOT NULL
/// </code>
/// </param>
public partial record SqlSurvey(
    SqlInt32 Id,
    SqlString Title,
    SqlString Author,
    SqlString Description)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [surveys] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_title] NVARCHAR(255) NOT NULL,
    ///     [survey_author] NVARCHAR(255) NOT NULL,
    ///     [survey_description] NVARCHAR(MAX) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[surveys]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ID = "[surveys].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_title] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_TITLE = "[surveys].[survey_title]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_author] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_AUTHOR = "[surveys].[survey_author]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_description] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_DESCRIPTION = "[surveys].[survey_description]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_title] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TITLE = "[survey_title]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_author] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string AUTHOR = "[survey_author]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_description] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string DESCRIPTION = "[survey_description]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_pages] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_page_title] NVARCHAR(1023) NOT NULL,
///     [survey_page_description] NVARCHAR(MAX) NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Title">
/// Stored in the database as:
/// <code>
/// [survey_page_title] NVARCHAR(1023) NOT NULL
/// </code>
/// </param>
/// <param name="Description">
/// Stored in the database as:
/// <code>
/// [survey_page_description] NVARCHAR(MAX) NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyPage(
    SqlInt32 SurveyId,
    SqlInt32 Index,
    SqlString Title,
    SqlString Description)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_pages] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_page_title] NVARCHAR(1023) NOT NULL,
    ///     [survey_page_description] NVARCHAR(MAX) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_pages]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_pages].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_pages].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_title] NVARCHAR(1023) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_TITLE = "[survey_pages].[survey_page_title]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_description] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_DESCRIPTION = "[survey_pages].[survey_page_description]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_title] NVARCHAR(1023) NOT NULL
    /// </code>
    /// </summary>
    public const string TITLE = "[survey_page_title]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_description] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string DESCRIPTION = "[survey_page_description]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_questions] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_prompt] NVARCHAR(1023) NOT NULL,
///     [survey_question_answer_type] TINYINT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Title">
/// Stored in the database as:
/// <code>
/// [survey_question_prompt] NVARCHAR(1023) NOT NULL
/// </code>
/// </param>
/// <param name="Type">
/// Stored in the database as:
/// <code>
/// [survey_question_answer_type] TINYINT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestion(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 Index,
    SqlString Title,
    SqlByte Type)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_questions] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_prompt] NVARCHAR(1023) NOT NULL,
    ///     [survey_question_answer_type] TINYINT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_questions]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_questions].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_questions].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_questions].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_prompt] NVARCHAR(1023) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_TITLE = "[survey_questions].[survey_question_prompt]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_answer_type] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_TYPE = "[survey_questions].[survey_question_answer_type]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_prompt] NVARCHAR(1023) NOT NULL
    /// </code>
    /// </summary>
    public const string TITLE = "[survey_question_prompt]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_answer_type] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TYPE = "[survey_question_answer_type]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [registered_members] (
///     [registered_member_id] INT NOT NULL,
///     [registered_member_password_hash] VARCHAR(255) NOT NULL,
///     [registered_member_phone_number] VARCHAR(13) NOT NULL,
///     [registered_member_birth_date] DATETIME NOT NULL,
///     [registered_member_first_name] NVARCHAR(255) NOT NULL,
///     [registered_member_last_name] NVARCHAR(255) NOT NULL);
/// </code>
/// </summary>
/// <param name="Id">
/// Stored in the database as:
/// <code>
/// [registered_member_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PasswordHash">
/// Stored in the database as:
/// <code>
/// [registered_member_password_hash] VARCHAR(255) NOT NULL
/// </code>
/// </param>
/// <param name="PhoneNumber">
/// Stored in the database as:
/// <code>
/// [registered_member_phone_number] VARCHAR(13) NOT NULL
/// </code>
/// </param>
/// <param name="BirthDate">
/// Stored in the database as:
/// <code>
/// [registered_member_birth_date] DATETIME NOT NULL
/// </code>
/// </param>
/// <param name="FirstName">
/// Stored in the database as:
/// <code>
/// [registered_member_first_name] NVARCHAR(255) NOT NULL
/// </code>
/// </param>
/// <param name="LastName">
/// Stored in the database as:
/// <code>
/// [registered_member_last_name] NVARCHAR(255) NOT NULL
/// </code>
/// </param>
public partial record SqlRegisteredMember(
    SqlInt32 Id,
    SqlString PasswordHash,
    SqlString PhoneNumber,
    SqlDateTime BirthDate,
    SqlString FirstName,
    SqlString LastName)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [registered_members] (
    ///     [registered_member_id] INT NOT NULL,
    ///     [registered_member_password_hash] VARCHAR(255) NOT NULL,
    ///     [registered_member_phone_number] VARCHAR(13) NOT NULL,
    ///     [registered_member_birth_date] DATETIME NOT NULL,
    ///     [registered_member_first_name] NVARCHAR(255) NOT NULL,
    ///     [registered_member_last_name] NVARCHAR(255) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[registered_members]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ID = "[registered_members].[registered_member_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_password_hash] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PASSWORD_HASH = "[registered_members].[registered_member_password_hash]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_phone_number] VARCHAR(13) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PHONE_NUMBER = "[registered_members].[registered_member_phone_number]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_birth_date] DATETIME NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_BIRTH_DATE = "[registered_members].[registered_member_birth_date]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_first_name] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_FIRST_NAME = "[registered_members].[registered_member_first_name]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_last_name] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_LAST_NAME = "[registered_members].[registered_member_last_name]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ID = "[registered_member_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_password_hash] VARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string PASSWORD_HASH = "[registered_member_password_hash]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_phone_number] VARCHAR(13) NOT NULL
    /// </code>
    /// </summary>
    public const string PHONE_NUMBER = "[registered_member_phone_number]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_birth_date] DATETIME NOT NULL
    /// </code>
    /// </summary>
    public const string BIRTH_DATE = "[registered_member_birth_date]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_first_name] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string FIRST_NAME = "[registered_member_first_name]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_last_name] NVARCHAR(255) NOT NULL
    /// </code>
    /// </summary>
    public const string LAST_NAME = "[registered_member_last_name]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [submissions] (
///     [survey_id] INT NOT NULL,
///     [submission_index] INT NOT NULL,
///     [registered_member_id] INT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [submission_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="RegisteredMemberId">
/// Stored in the database as:
/// <code>
/// [registered_member_id] INT NULL
/// </code>
/// </param>
public partial record SqlSubmission(
    SqlInt32 SurveyId,
    SqlInt32 Index,
    SqlInt32 RegisteredMemberId)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [submissions] (
    ///     [survey_id] INT NOT NULL,
    ///     [submission_index] INT NOT NULL,
    ///     [registered_member_id] INT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[submissions]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[submissions].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[submissions].[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_id] INT NULL
    /// </code>
    /// </summary>
    public const string TABLE_REGISTERED_MEMBER_ID = "[submissions].[registered_member_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_id] INT NULL
    /// </code>
    /// </summary>
    public const string REGISTERED_MEMBER_ID = "[registered_member_id]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [submission_answers] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [submission_index] INT NOT NULL,
///     [submission_answer_index] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="SubmissionIndex">
/// Stored in the database as:
/// <code>
/// [submission_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="AnswerIndex">
/// Stored in the database as:
/// <code>
/// [submission_answer_index] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSubmissionAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 AnswerIndex)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [submission_answers] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [submission_index] INT NOT NULL,
    ///     [submission_answer_index] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[submission_answers]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[submission_answers].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[submission_answers].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[submission_answers].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SUBMISSION_INDEX = "[submission_answers].[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ANSWER_INDEX = "[submission_answers].[submission_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SUBMISSION_INDEX = "[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ANSWER_INDEX = "[submission_answer_index]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [submission_integer_answers] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [submission_index] INT NOT NULL,
///     [submission_answer_index] INT NOT NULL,
///     [submission_answer_integer] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="SubmissionIndex">
/// Stored in the database as:
/// <code>
/// [submission_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="AnswerIndex">
/// Stored in the database as:
/// <code>
/// [submission_answer_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Value">
/// Stored in the database as:
/// <code>
/// [submission_answer_integer] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSubmissionIntegerAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 AnswerIndex,
    SqlInt32 Value)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [submission_integer_answers] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [submission_index] INT NOT NULL,
    ///     [submission_answer_index] INT NOT NULL,
    ///     [submission_answer_integer] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[submission_integer_answers]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[submission_integer_answers].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[submission_integer_answers].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[submission_integer_answers].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SUBMISSION_INDEX = "[submission_integer_answers].[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ANSWER_INDEX = "[submission_integer_answers].[submission_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_VALUE = "[submission_integer_answers].[submission_answer_integer]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SUBMISSION_INDEX = "[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ANSWER_INDEX = "[submission_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string VALUE = "[submission_answer_integer]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [submission_text_answers] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [submission_index] INT NOT NULL,
///     [submission_answer_index] INT NOT NULL,
///     [submission_answer_text] NVARCHAR(MAX) NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="SubmissionIndex">
/// Stored in the database as:
/// <code>
/// [submission_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="AnswerIndex">
/// Stored in the database as:
/// <code>
/// [submission_answer_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Value">
/// Stored in the database as:
/// <code>
/// [submission_answer_text] NVARCHAR(MAX) NOT NULL
/// </code>
/// </param>
public partial record SqlSubmissionTextAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 SubmissionIndex,
    SqlInt32 AnswerIndex,
    SqlString Value)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [submission_text_answers] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [submission_index] INT NOT NULL,
    ///     [submission_answer_index] INT NOT NULL,
    ///     [submission_answer_text] NVARCHAR(MAX) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[submission_text_answers]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[submission_text_answers].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[submission_text_answers].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[submission_text_answers].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SUBMISSION_INDEX = "[submission_text_answers].[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ANSWER_INDEX = "[submission_text_answers].[submission_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_VALUE = "[submission_text_answers].[submission_answer_text]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SUBMISSION_INDEX = "[submission_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ANSWER_INDEX = "[submission_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [submission_answer_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string VALUE = "[submission_answer_text]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_answer_options] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_answer_option_index] INT NOT NULL,
///     [survey_answer_option_text] NVARCHAR(1023) NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_answer_option_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Text">
/// Stored in the database as:
/// <code>
/// [survey_answer_option_text] NVARCHAR(1023) NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionAnswerOption(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlString Text)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_answer_options] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_answer_option_index] INT NOT NULL,
    ///     [survey_answer_option_text] NVARCHAR(1023) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_answer_options]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_answer_options].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_answer_options].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_answer_options].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_answer_option_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_answer_options].[survey_answer_option_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_answer_option_text] NVARCHAR(1023) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_TEXT = "[survey_question_answer_options].[survey_answer_option_text]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_answer_option_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_answer_option_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_answer_option_text] NVARCHAR(1023) NOT NULL
    /// </code>
    /// </summary>
    public const string TEXT = "[survey_answer_option_text]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_show_conditions] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_show_condition_index] INT NOT NULL,
///     [survey_question_show_condition_type] TINYINT NOT NULL,
///     [survey_question_show_condition_operator] TINYINT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Type">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_type] TINYINT NOT NULL
/// </code>
/// </param>
/// <param name="Operator">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_operator] TINYINT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionShowCondition(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlByte Type,
    SqlByte Operator)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_show_conditions] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_show_condition_index] INT NOT NULL,
    ///     [survey_question_show_condition_type] TINYINT NOT NULL,
    ///     [survey_question_show_condition_operator] TINYINT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_show_conditions]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_show_conditions].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_show_conditions].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_show_conditions].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_show_conditions].[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_type] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_TYPE = "[survey_question_show_conditions].[survey_question_show_condition_type]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_operator] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_OPERATOR = "[survey_question_show_conditions].[survey_question_show_condition_operator]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_type] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TYPE = "[survey_question_show_condition_type]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_operator] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string OPERATOR = "[survey_question_show_condition_operator]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_show_condition_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_show_condition_index] INT NOT NULL,
///     [survey_question_show_condition_arg_index] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionShowConditionArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_show_condition_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_show_condition_index] INT NOT NULL,
    ///     [survey_question_show_condition_arg_index] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_show_condition_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_show_condition_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_show_condition_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_show_condition_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_show_condition_args].[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_show_condition_args].[survey_question_show_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_show_condition_arg_index]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_show_condition_ref_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_show_condition_index] INT NOT NULL,
///     [survey_question_show_condition_arg_index] INT NOT NULL,
///     [referenced_survey_page_index] INT NOT NULL,
///     [referenced_survey_question_index] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ReferencedPageIndex">
/// Stored in the database as:
/// <code>
/// [referenced_survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ReferencedQuestionIndex">
/// Stored in the database as:
/// <code>
/// [referenced_survey_question_index] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionShowConditionRefArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index,
    SqlInt32 ReferencedPageIndex,
    SqlInt32 ReferencedQuestionIndex)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_show_condition_ref_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_show_condition_index] INT NOT NULL,
    ///     [survey_question_show_condition_arg_index] INT NOT NULL,
    ///     [referenced_survey_page_index] INT NOT NULL,
    ///     [referenced_survey_question_index] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_show_condition_ref_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_show_condition_ref_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_show_condition_ref_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_show_condition_ref_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_show_condition_ref_args].[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_show_condition_ref_args].[survey_question_show_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_REFERENCED_PAGE_INDEX = "[survey_question_show_condition_ref_args].[referenced_survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_REFERENCED_QUESTION_INDEX = "[survey_question_show_condition_ref_args].[referenced_survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_show_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string REFERENCED_PAGE_INDEX = "[referenced_survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string REFERENCED_QUESTION_INDEX = "[referenced_survey_question_index]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_show_condition_integer_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_show_condition_index] INT NOT NULL,
///     [survey_question_show_condition_arg_index] INT NOT NULL,
///     [survey_question_show_condition_arg_integer] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ArgValue">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_arg_integer] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionShowConditionIntegerArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index,
    SqlInt32 ArgValue)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_show_condition_integer_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_show_condition_index] INT NOT NULL,
    ///     [survey_question_show_condition_arg_index] INT NOT NULL,
    ///     [survey_question_show_condition_arg_integer] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_show_condition_integer_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_show_condition_integer_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_show_condition_integer_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_show_condition_integer_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_show_condition_integer_args].[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_show_condition_integer_args].[survey_question_show_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ARG_VALUE = "[survey_question_show_condition_integer_args].[survey_question_show_condition_arg_integer]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_show_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ARG_VALUE = "[survey_question_show_condition_arg_integer]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_show_condition_text_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_show_condition_index] INT NOT NULL,
///     [survey_question_show_condition_arg_index] INT NOT NULL,
///     [survey_question_show_condition_arg_text] NVARCHAR(MAX) NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ArgValue">
/// Stored in the database as:
/// <code>
/// [survey_question_show_condition_arg_text] NVARCHAR(MAX) NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionShowConditionTextArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index,
    SqlString ArgValue)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_show_condition_text_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_show_condition_index] INT NOT NULL,
    ///     [survey_question_show_condition_arg_index] INT NOT NULL,
    ///     [survey_question_show_condition_arg_text] NVARCHAR(MAX) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_show_condition_text_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_show_condition_text_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_show_condition_text_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_show_condition_text_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_show_condition_text_args].[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_show_condition_text_args].[survey_question_show_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ARG_VALUE = "[survey_question_show_condition_text_args].[survey_question_show_condition_arg_text]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_show_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_show_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_show_condition_arg_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string ARG_VALUE = "[survey_question_show_condition_arg_text]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_validation_conditions] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_validation_condition_index] INT NOT NULL,
///     [survey_question_validation_condition_type] TINYINT NOT NULL,
///     [survey_question_validation_condition_operator] TINYINT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Type">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_type] TINYINT NOT NULL
/// </code>
/// </param>
/// <param name="Operator">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_operator] TINYINT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionValidationCondition(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 Index,
    SqlByte Type,
    SqlByte Operator)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_validation_conditions] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_validation_condition_index] INT NOT NULL,
    ///     [survey_question_validation_condition_type] TINYINT NOT NULL,
    ///     [survey_question_validation_condition_operator] TINYINT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_validation_conditions]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_validation_conditions].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_validation_conditions].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_validation_conditions].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_validation_conditions].[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_type] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_TYPE = "[survey_question_validation_conditions].[survey_question_validation_condition_type]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_operator] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_OPERATOR = "[survey_question_validation_conditions].[survey_question_validation_condition_operator]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_type] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string TYPE = "[survey_question_validation_condition_type]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_operator] TINYINT NOT NULL
    /// </code>
    /// </summary>
    public const string OPERATOR = "[survey_question_validation_condition_operator]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_validation_condition_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_validation_condition_index] INT NOT NULL,
///     [survey_question_validation_condition_arg_index] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionValidationConditionArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_validation_condition_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_validation_condition_index] INT NOT NULL,
    ///     [survey_question_validation_condition_arg_index] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_validation_condition_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_validation_condition_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_validation_condition_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_validation_condition_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_validation_condition_args].[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_validation_condition_args].[survey_question_validation_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_validation_condition_arg_index]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_validation_condition_ref_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_validation_condition_index] INT NOT NULL,
///     [survey_question_validation_condition_arg_index] INT NOT NULL,
///     [referenced_survey_page_index] INT NOT NULL,
///     [referenced_survey_question_index] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ReferencedPageIndex">
/// Stored in the database as:
/// <code>
/// [referenced_survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ReferencedQuestionIndex">
/// Stored in the database as:
/// <code>
/// [referenced_survey_question_index] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionValidationConditionRefArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index,
    SqlInt32 ReferencedPageIndex,
    SqlInt32 ReferencedQuestionIndex)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_validation_condition_ref_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_validation_condition_index] INT NOT NULL,
    ///     [survey_question_validation_condition_arg_index] INT NOT NULL,
    ///     [referenced_survey_page_index] INT NOT NULL,
    ///     [referenced_survey_question_index] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_validation_condition_ref_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_validation_condition_ref_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_validation_condition_ref_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_validation_condition_ref_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_validation_condition_ref_args].[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_validation_condition_ref_args].[survey_question_validation_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_REFERENCED_PAGE_INDEX = "[survey_question_validation_condition_ref_args].[referenced_survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_REFERENCED_QUESTION_INDEX = "[survey_question_validation_condition_ref_args].[referenced_survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_validation_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string REFERENCED_PAGE_INDEX = "[referenced_survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [referenced_survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string REFERENCED_QUESTION_INDEX = "[referenced_survey_question_index]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_validation_condition_integer_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_validation_condition_index] INT NOT NULL,
///     [survey_question_validation_condition_arg_index] INT NOT NULL,
///     [survey_question_validation_condition_arg_integer] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ArgValue">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_arg_integer] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionValidationConditionIntegerArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index,
    SqlInt32 ArgValue)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_validation_condition_integer_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_validation_condition_index] INT NOT NULL,
    ///     [survey_question_validation_condition_arg_index] INT NOT NULL,
    ///     [survey_question_validation_condition_arg_integer] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_validation_condition_integer_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_validation_condition_integer_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_validation_condition_integer_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_validation_condition_integer_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_validation_condition_integer_args].[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_validation_condition_integer_args].[survey_question_validation_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ARG_VALUE = "[survey_question_validation_condition_integer_args].[survey_question_validation_condition_arg_integer]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_validation_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ARG_VALUE = "[survey_question_validation_condition_arg_integer]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_question_validation_condition_text_args] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_question_validation_condition_index] INT NOT NULL,
///     [survey_question_validation_condition_arg_index] INT NOT NULL,
///     [survey_question_validation_condition_arg_text] NVARCHAR(MAX) NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ConditionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Index">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_arg_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="ArgValue">
/// Stored in the database as:
/// <code>
/// [survey_question_validation_condition_arg_text] NVARCHAR(MAX) NOT NULL
/// </code>
/// </param>
public partial record SqlSurveyQuestionValidationConditionTextArg(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlInt32 ConditionIndex,
    SqlInt32 Index,
    SqlString ArgValue)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_question_validation_condition_text_args] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_question_validation_condition_index] INT NOT NULL,
    ///     [survey_question_validation_condition_arg_index] INT NOT NULL,
    ///     [survey_question_validation_condition_arg_text] NVARCHAR(MAX) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_question_validation_condition_text_args]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_question_validation_condition_text_args].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_question_validation_condition_text_args].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_question_validation_condition_text_args].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_CONDITION_INDEX = "[survey_question_validation_condition_text_args].[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_INDEX = "[survey_question_validation_condition_text_args].[survey_question_validation_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ARG_VALUE = "[survey_question_validation_condition_text_args].[survey_question_validation_condition_arg_text]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string CONDITION_INDEX = "[survey_question_validation_condition_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string INDEX = "[survey_question_validation_condition_arg_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_validation_condition_arg_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string ARG_VALUE = "[survey_question_validation_condition_arg_text]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [registered_member_sessions] (
///     [registered_member_session_token] BINARY(32) NOT NULL CONSTRAINT [default_registered_member_sessions_1] DEFAULT CRYPT_GEN_RANDOM(32),
///     [registered_member_session_expiry] DATETIME NOT NULL CONSTRAINT [default_registered_member_sessions_2] DEFAULT DATEADD(HOUR, 2, GETUTCDATE()),
///     [registered_member_id] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="Token">
/// Stored in the database as:
/// <code>
/// [registered_member_session_token] BINARY(32) NOT NULL CONSTRAINT [default_registered_member_sessions_3] DEFAULT CRYPT_GEN_RANDOM(32)
/// </code>
/// </param>
/// <param name="Expiry">
/// Stored in the database as:
/// <code>
/// [registered_member_session_expiry] DATETIME NOT NULL CONSTRAINT [default_registered_member_sessions_4] DEFAULT DATEADD(HOUR, 2, GETUTCDATE())
/// </code>
/// </param>
/// <param name="RegisteredMemberId">
/// Stored in the database as:
/// <code>
/// [registered_member_id] INT NOT NULL
/// </code>
/// </param>
public partial record SqlRegisteredMemberSession(
    SqlBinary Token,
    SqlDateTime Expiry,
    SqlInt32 RegisteredMemberId)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [registered_member_sessions] (
    ///     [registered_member_session_token] BINARY(32) NOT NULL CONSTRAINT [default_registered_member_sessions_1] DEFAULT CRYPT_GEN_RANDOM(32),
    ///     [registered_member_session_expiry] DATETIME NOT NULL CONSTRAINT [default_registered_member_sessions_2] DEFAULT DATEADD(HOUR, 2, GETUTCDATE()),
    ///     [registered_member_id] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[registered_member_sessions]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_session_token] BINARY(32) NOT NULL CONSTRAINT [default_registered_member_sessions_3] DEFAULT CRYPT_GEN_RANDOM(32)
    /// </code>
    /// </summary>
    public const string TABLE_TOKEN = "[registered_member_sessions].[registered_member_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_session_expiry] DATETIME NOT NULL CONSTRAINT [default_registered_member_sessions_4] DEFAULT DATEADD(HOUR, 2, GETUTCDATE())
    /// </code>
    /// </summary>
    public const string TABLE_EXPIRY = "[registered_member_sessions].[registered_member_session_expiry]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_REGISTERED_MEMBER_ID = "[registered_member_sessions].[registered_member_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_session_token] BINARY(32) NOT NULL CONSTRAINT [default_registered_member_sessions_5] DEFAULT CRYPT_GEN_RANDOM(32)
    /// </code>
    /// </summary>
    public const string TOKEN = "[registered_member_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_session_expiry] DATETIME NOT NULL CONSTRAINT [default_registered_member_sessions_6] DEFAULT DATEADD(HOUR, 2, GETUTCDATE())
    /// </code>
    /// </summary>
    public const string EXPIRY = "[registered_member_session_expiry]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [registered_member_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string REGISTERED_MEMBER_ID = "[registered_member_id]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_sessions] (
///     [survey_session_token] BINARY(32) NOT NULL CONSTRAINT [default_survey_sessions_1] DEFAULT CRYPT_GEN_RANDOM(32),
///     [survey_session_expiry] DATETIME NOT NULL CONSTRAINT [default_survey_sessions_2] DEFAULT DATEADD(HOUR, 2, GETUTCDATE()),
///     [survey_id] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="Token">
/// Stored in the database as:
/// <code>
/// [survey_session_token] BINARY(32) NOT NULL CONSTRAINT [default_survey_sessions_3] DEFAULT CRYPT_GEN_RANDOM(32)
/// </code>
/// </param>
/// <param name="Expiry">
/// Stored in the database as:
/// <code>
/// [survey_session_expiry] DATETIME NOT NULL CONSTRAINT [default_survey_sessions_4] DEFAULT DATEADD(HOUR, 2, GETUTCDATE())
/// </code>
/// </param>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveySession(
    SqlBinary Token,
    SqlDateTime Expiry,
    SqlInt32 SurveyId)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_sessions] (
    ///     [survey_session_token] BINARY(32) NOT NULL CONSTRAINT [default_survey_sessions_1] DEFAULT CRYPT_GEN_RANDOM(32),
    ///     [survey_session_expiry] DATETIME NOT NULL CONSTRAINT [default_survey_sessions_2] DEFAULT DATEADD(HOUR, 2, GETUTCDATE()),
    ///     [survey_id] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_sessions]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL CONSTRAINT [default_survey_sessions_3] DEFAULT CRYPT_GEN_RANDOM(32)
    /// </code>
    /// </summary>
    public const string TABLE_TOKEN = "[survey_sessions].[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_expiry] DATETIME NOT NULL CONSTRAINT [default_survey_sessions_4] DEFAULT DATEADD(HOUR, 2, GETUTCDATE())
    /// </code>
    /// </summary>
    public const string TABLE_EXPIRY = "[survey_sessions].[survey_session_expiry]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_sessions].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL CONSTRAINT [default_survey_sessions_5] DEFAULT CRYPT_GEN_RANDOM(32)
    /// </code>
    /// </summary>
    public const string TOKEN = "[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_expiry] DATETIME NOT NULL CONSTRAINT [default_survey_sessions_6] DEFAULT DATEADD(HOUR, 2, GETUTCDATE())
    /// </code>
    /// </summary>
    public const string EXPIRY = "[survey_session_expiry]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_session_answers] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_session_token] BINARY(32) NOT NULL,
///     [survey_session_answer_index] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="SessionToken">
/// Stored in the database as:
/// <code>
/// [survey_session_token] BINARY(32) NOT NULL
/// </code>
/// </param>
/// <param name="AnswerIndex">
/// Stored in the database as:
/// <code>
/// [survey_session_answer_index] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveySessionAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlBinary SessionToken,
    SqlInt32 AnswerIndex)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_session_answers] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_session_token] BINARY(32) NOT NULL,
    ///     [survey_session_answer_index] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_session_answers]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_session_answers].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_session_answers].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_session_answers].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SESSION_TOKEN = "[survey_session_answers].[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ANSWER_INDEX = "[survey_session_answers].[survey_session_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL
    /// </code>
    /// </summary>
    public const string SESSION_TOKEN = "[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ANSWER_INDEX = "[survey_session_answer_index]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_session_integer_answers] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_session_token] BINARY(32) NOT NULL,
///     [survey_session_answer_index] INT NOT NULL,
///     [survey_session_answer_integer] INT NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="SessionToken">
/// Stored in the database as:
/// <code>
/// [survey_session_token] BINARY(32) NOT NULL
/// </code>
/// </param>
/// <param name="AnswerIndex">
/// Stored in the database as:
/// <code>
/// [survey_session_answer_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Value">
/// Stored in the database as:
/// <code>
/// [survey_session_answer_integer] INT NOT NULL
/// </code>
/// </param>
public partial record SqlSurveySessionIntegerAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlBinary SessionToken,
    SqlInt32 AnswerIndex,
    SqlInt32 Value)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_session_integer_answers] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_session_token] BINARY(32) NOT NULL,
    ///     [survey_session_answer_index] INT NOT NULL,
    ///     [survey_session_answer_integer] INT NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_session_integer_answers]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_session_integer_answers].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_session_integer_answers].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_session_integer_answers].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SESSION_TOKEN = "[survey_session_integer_answers].[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ANSWER_INDEX = "[survey_session_integer_answers].[survey_session_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_VALUE = "[survey_session_integer_answers].[survey_session_answer_integer]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL
    /// </code>
    /// </summary>
    public const string SESSION_TOKEN = "[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ANSWER_INDEX = "[survey_session_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_integer] INT NOT NULL
    /// </code>
    /// </summary>
    public const string VALUE = "[survey_session_answer_integer]";
}

/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [survey_session_text_answers] (
///     [survey_id] INT NOT NULL,
///     [survey_page_index] INT NOT NULL,
///     [survey_question_index] INT NOT NULL,
///     [survey_session_token] BINARY(32) NOT NULL,
///     [survey_session_answer_index] INT NOT NULL,
///     [survey_session_answer_text] NVARCHAR(MAX) NOT NULL);
/// </code>
/// </summary>
/// <param name="SurveyId">
/// Stored in the database as:
/// <code>
/// [survey_id] INT NOT NULL
/// </code>
/// </param>
/// <param name="PageIndex">
/// Stored in the database as:
/// <code>
/// [survey_page_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="QuestionIndex">
/// Stored in the database as:
/// <code>
/// [survey_question_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="SessionToken">
/// Stored in the database as:
/// <code>
/// [survey_session_token] BINARY(32) NOT NULL
/// </code>
/// </param>
/// <param name="AnswerIndex">
/// Stored in the database as:
/// <code>
/// [survey_session_answer_index] INT NOT NULL
/// </code>
/// </param>
/// <param name="Value">
/// Stored in the database as:
/// <code>
/// [survey_session_answer_text] NVARCHAR(MAX) NOT NULL
/// </code>
/// </param>
public partial record SqlSurveySessionTextAnswer(
    SqlInt32 SurveyId,
    SqlInt32 PageIndex,
    SqlInt32 QuestionIndex,
    SqlBinary SessionToken,
    SqlInt32 AnswerIndex,
    SqlString Value)
{
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [survey_session_text_answers] (
    ///     [survey_id] INT NOT NULL,
    ///     [survey_page_index] INT NOT NULL,
    ///     [survey_question_index] INT NOT NULL,
    ///     [survey_session_token] BINARY(32) NOT NULL,
    ///     [survey_session_answer_index] INT NOT NULL,
    ///     [survey_session_answer_text] NVARCHAR(MAX) NOT NULL);
    /// </code>
    /// </summary>
    public const string TABLE = "[survey_session_text_answers]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SURVEY_ID = "[survey_session_text_answers].[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_PAGE_INDEX = "[survey_session_text_answers].[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_QUESTION_INDEX = "[survey_session_text_answers].[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_SESSION_TOKEN = "[survey_session_text_answers].[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_ANSWER_INDEX = "[survey_session_text_answers].[survey_session_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string TABLE_VALUE = "[survey_session_text_answers].[survey_session_answer_text]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_id] INT NOT NULL
    /// </code>
    /// </summary>
    public const string SURVEY_ID = "[survey_id]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_page_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string PAGE_INDEX = "[survey_page_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_question_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string QUESTION_INDEX = "[survey_question_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_token] BINARY(32) NOT NULL
    /// </code>
    /// </summary>
    public const string SESSION_TOKEN = "[survey_session_token]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_index] INT NOT NULL
    /// </code>
    /// </summary>
    public const string ANSWER_INDEX = "[survey_session_answer_index]";

    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// [survey_session_answer_text] NVARCHAR(MAX) NOT NULL
    /// </code>
    /// </summary>
    public const string VALUE = "[survey_session_answer_text]";
}

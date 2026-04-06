--- This file was auto-generated based on ./Build/database/database_structure.yaml

CREATE OR ALTER PROCEDURE [survey_question_show_condition_type_fields] (
    @has_answered TINYINT OUTPUT,
    @has_not_answered TINYINT OUTPUT
) AS
BEGIN

    SET @has_answered = (
        SELECT [survey_question_show_condition_types].[survey_question_show_condition_type_id]
        FROM [survey_question_show_condition_types]
        WHERE [survey_question_show_condition_types].[survey_question_show_condition_type_name] = 'has_answered');

    IF (@has_answered IS NULL)
        THROW 50000, 'survey_question_show_condition_types "has_answered" not found.', 1;

    SET @has_not_answered = (
        SELECT [survey_question_show_condition_types].[survey_question_show_condition_type_id]
        FROM [survey_question_show_condition_types]
        WHERE [survey_question_show_condition_types].[survey_question_show_condition_type_name] = 'has_not_answered');

    IF (@has_not_answered IS NULL)
        THROW 50000, 'survey_question_show_condition_types "has_not_answered" not found.', 1;

END

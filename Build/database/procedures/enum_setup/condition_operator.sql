--- This file was auto-generated based on ./Build/database/database_structure.yaml

CREATE OR ALTER PROCEDURE [survey_question_condition_operator_fields] (
    @and TINYINT OUTPUT,
    @or TINYINT OUTPUT
) AS
BEGIN

    SET @and = (
        SELECT [survey_question_condition_operator].[survey_question_condition_operator_id]
        FROM [survey_question_condition_operator]
        WHERE [survey_question_condition_operator].[survey_question_condition_operator_name] = 'and');

    IF (@and IS NULL)
        THROW 50000, 'survey_question_condition_operator "and" not found.', 1;

    SET @or = (
        SELECT [survey_question_condition_operator].[survey_question_condition_operator_id]
        FROM [survey_question_condition_operator]
        WHERE [survey_question_condition_operator].[survey_question_condition_operator_name] = 'or');

    IF (@or IS NULL)
        THROW 50000, 'survey_question_condition_operator "or" not found.', 1;

END

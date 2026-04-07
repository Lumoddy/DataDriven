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
        THROW 50000, 'Database does not contain an entry for ''and'' in the ''survey_question_condition_operator'' enum.', 1;

    SET @or = (
        SELECT [survey_question_condition_operator].[survey_question_condition_operator_id]
        FROM [survey_question_condition_operator]
        WHERE [survey_question_condition_operator].[survey_question_condition_operator_name] = 'or');

    IF (@or IS NULL)
        THROW 50000, 'Database does not contain an entry for ''or'' in the ''survey_question_condition_operator'' enum.', 1;

END

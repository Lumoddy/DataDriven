--- This file was auto-generated based on ./Build/database/database_structure.yaml

CREATE OR ALTER PROCEDURE [survey_question_condition_passing_fields] (
    @failed TINYINT OUTPUT,
    @passed TINYINT OUTPUT,
    @undecided TINYINT OUTPUT
) AS
BEGIN

    SET @failed = (
        SELECT [survey_question_condition_passing].[survey_question_condition_passing_id]
        FROM [survey_question_condition_passing]
        WHERE [survey_question_condition_passing].[survey_question_condition_passing_name] = 'failed');

    IF (@failed IS NULL)
        THROW 50000, 'survey_question_condition_passing "failed" not found.', 1;

    SET @passed = (
        SELECT [survey_question_condition_passing].[survey_question_condition_passing_id]
        FROM [survey_question_condition_passing]
        WHERE [survey_question_condition_passing].[survey_question_condition_passing_name] = 'passed');

    IF (@passed IS NULL)
        THROW 50000, 'survey_question_condition_passing "passed" not found.', 1;

    SET @undecided = (
        SELECT [survey_question_condition_passing].[survey_question_condition_passing_id]
        FROM [survey_question_condition_passing]
        WHERE [survey_question_condition_passing].[survey_question_condition_passing_name] = 'undecided');

    IF (@undecided IS NULL)
        THROW 50000, 'survey_question_condition_passing "undecided" not found.', 1;

END

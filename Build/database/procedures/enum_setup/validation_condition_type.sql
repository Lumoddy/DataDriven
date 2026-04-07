--- This file was auto-generated based on ./Build/database/database_structure.yaml

CREATE OR ALTER PROCEDURE [survey_question_validation_condition_type_fields] (
    @min TINYINT OUTPUT,
    @max TINYINT OUTPUT
) AS
BEGIN

    SET @min = (
        SELECT [survey_question_validation_condition_types].[survey_question_validation_condition_type_id]
        FROM [survey_question_validation_condition_types]
        WHERE [survey_question_validation_condition_types].[survey_question_validation_condition_type_name] = 'min');

    IF (@min IS NULL)
        THROW 50000, 'Database does not contain an entry for ''min'' in the ''survey_question_validation_condition_types'' enum.', 1;

    SET @max = (
        SELECT [survey_question_validation_condition_types].[survey_question_validation_condition_type_id]
        FROM [survey_question_validation_condition_types]
        WHERE [survey_question_validation_condition_types].[survey_question_validation_condition_type_name] = 'max');

    IF (@max IS NULL)
        THROW 50000, 'Database does not contain an entry for ''max'' in the ''survey_question_validation_condition_types'' enum.', 1;

END

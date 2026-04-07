--- This file was auto-generated based on ./Build/database/database_structure.yaml

CREATE OR ALTER PROCEDURE [survey_question_answer_type_fields] (
    @small_text TINYINT OUTPUT,
    @checkbox TINYINT OUTPUT,
    @radio TINYINT OUTPUT,
    @radio_or_other TINYINT OUTPUT,
    @multi_select TINYINT OUTPUT,
    @multi_select_and_other TINYINT OUTPUT
) AS
BEGIN

    SET @small_text = (
        SELECT [survey_question_answer_types].[survey_question_answer_type_id]
        FROM [survey_question_answer_types]
        WHERE [survey_question_answer_types].[survey_question_answer_type_name] = 'small_text');

    IF (@small_text IS NULL)
        THROW 50000, 'Database does not contain an entry for ''small_text'' in the ''survey_question_answer_types'' enum.', 1;

    SET @checkbox = (
        SELECT [survey_question_answer_types].[survey_question_answer_type_id]
        FROM [survey_question_answer_types]
        WHERE [survey_question_answer_types].[survey_question_answer_type_name] = 'checkbox');

    IF (@checkbox IS NULL)
        THROW 50000, 'Database does not contain an entry for ''checkbox'' in the ''survey_question_answer_types'' enum.', 1;

    SET @radio = (
        SELECT [survey_question_answer_types].[survey_question_answer_type_id]
        FROM [survey_question_answer_types]
        WHERE [survey_question_answer_types].[survey_question_answer_type_name] = 'radio');

    IF (@radio IS NULL)
        THROW 50000, 'Database does not contain an entry for ''radio'' in the ''survey_question_answer_types'' enum.', 1;

    SET @radio_or_other = (
        SELECT [survey_question_answer_types].[survey_question_answer_type_id]
        FROM [survey_question_answer_types]
        WHERE [survey_question_answer_types].[survey_question_answer_type_name] = 'radio_or_other');

    IF (@radio_or_other IS NULL)
        THROW 50000, 'Database does not contain an entry for ''radio_or_other'' in the ''survey_question_answer_types'' enum.', 1;

    SET @multi_select = (
        SELECT [survey_question_answer_types].[survey_question_answer_type_id]
        FROM [survey_question_answer_types]
        WHERE [survey_question_answer_types].[survey_question_answer_type_name] = 'multi_select');

    IF (@multi_select IS NULL)
        THROW 50000, 'Database does not contain an entry for ''multi_select'' in the ''survey_question_answer_types'' enum.', 1;

    SET @multi_select_and_other = (
        SELECT [survey_question_answer_types].[survey_question_answer_type_id]
        FROM [survey_question_answer_types]
        WHERE [survey_question_answer_types].[survey_question_answer_type_name] = 'multi_select_and_other');

    IF (@multi_select_and_other IS NULL)
        THROW 50000, 'Database does not contain an entry for ''multi_select_and_other'' in the ''survey_question_answer_types'' enum.', 1;

END

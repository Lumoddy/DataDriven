
CREATE OR ALTER VIEW [survey_question_validation_conditions_args_view] AS
SELECT
    [survey_question_validation_conditions_args].*,
    [survey_question_validation_conditions_ref_args].[referenced_survey_page_index],
    [survey_question_validation_conditions_ref_args].[referenced_survey_question_index],
    [referenced_survey_questions].[survey_question_answer_type] AS [referenced_survey_question_answer_type],
    [referenced_survey_questions].[survey_question_prompt] AS [referenced_survey_question_prompt],
    [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_integer],
    [survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_text]
FROM
    [survey_question_validation_conditions_args]
LEFT JOIN
    [survey_question_validation_conditions_ref_args]
    ON [survey_question_validation_conditions_ref_args].[survey_id]
        = [survey_question_validation_conditions_args].[survey_id]
    AND [survey_question_validation_conditions_ref_args].[survey_page_index]
        = [survey_question_validation_conditions_args].[survey_page_index]
    AND [survey_question_validation_conditions_ref_args].[survey_question_index]
        = [survey_question_validation_conditions_args].[survey_question_index]
    AND [survey_question_validation_conditions_ref_args].[survey_question_validation_condition_index]
        = [survey_question_validation_conditions_args].[survey_question_validation_condition_index]
    AND [survey_question_validation_conditions_ref_args].[survey_question_validation_condition_arg_index]
        = [survey_question_validation_conditions_args].[survey_question_validation_condition_arg_index]
LEFT JOIN
    [survey_questions] AS [referenced_survey_questions]
    ON [survey_question_validation_conditions_ref_args].[referenced_survey_page_index]
        IS NOT NULL
    AND [referenced_survey_questions].[survey_id]
        = [survey_question_validation_conditions_ref_args].[survey_id]
    AND [referenced_survey_questions].[survey_page_index]
        = [survey_question_validation_conditions_ref_args].[referenced_survey_page_index]
    AND [referenced_survey_questions].[survey_question_index]
        = [survey_question_validation_conditions_ref_args].[referenced_survey_question_index]
LEFT JOIN
    [survey_question_validation_conditions_integer_args]
    ON [survey_question_validation_conditions_integer_args].[survey_id]
        = [survey_question_validation_conditions_args].[survey_id]
    AND [survey_question_validation_conditions_integer_args].[survey_page_index]
        = [survey_question_validation_conditions_args].[survey_page_index]
    AND [survey_question_validation_conditions_integer_args].[survey_question_index]
        = [survey_question_validation_conditions_args].[survey_question_index]
    AND [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_index]
        = [survey_question_validation_conditions_args].[survey_question_validation_condition_index]
    AND [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_index]
        = [survey_question_validation_conditions_args].[survey_question_validation_condition_arg_index]
LEFT JOIN
    [survey_question_validation_conditions_text_args]
    ON [survey_question_validation_conditions_text_args].[survey_id]
        = [survey_question_validation_conditions_args].[survey_id]
    AND [survey_question_validation_conditions_text_args].[survey_page_index]
        = [survey_question_validation_conditions_args].[survey_page_index]
    AND [survey_question_validation_conditions_text_args].[survey_question_index]
        = [survey_question_validation_conditions_args].[survey_question_index]
    AND [survey_question_validation_conditions_text_args].[survey_question_validation_condition_index]
        = [survey_question_validation_conditions_args].[survey_question_validation_condition_index]
    AND [survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_index]
        = [survey_question_validation_conditions_args].[survey_question_validation_condition_arg_index]
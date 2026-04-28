
CREATE OR ALTER PROCEDURE [query_survey_model] (
    @survey_id INT) AS
BEGIN

    SELECT
        [surveys].[survey_title],
        [surveys].[survey_author],
        [surveys].[survey_description]
    FROM
        [surveys]
    WHERE
        [surveys].[survey_id]
            = @survey_id;

    IF @@ROWCOUNT = 0
        RETURN;

    SELECT
        [survey_pages].[survey_page_index],
        [survey_pages].[survey_page_title],
        [survey_pages].[survey_page_description]
    FROM
        [survey_pages]
    WHERE
        [survey_pages].[survey_id]
            = @survey_id;

    SELECT
        [survey_questions].[survey_page_index],
        [survey_questions].[survey_question_index],
        [survey_questions].[survey_question_answer_type],
        [survey_questions].[survey_question_prompt]
    FROM
        [survey_questions]
    WHERE
        [survey_questions].[survey_id]
            = @survey_id
    ORDER BY
        [survey_questions].[survey_question_index] ASC;

    SELECT
        [survey_question_answer_options].[survey_page_index],
        [survey_question_answer_options].[survey_question_index],
        [survey_question_answer_options].[survey_answer_option_index],
        [survey_question_answer_options].[survey_answer_option_text]
    FROM
        [survey_question_answer_options]
    WHERE
        [survey_question_answer_options].[survey_id]
            = @survey_id
    ORDER BY
        [survey_question_answer_options].[survey_question_index] ASC,
        [survey_question_answer_options].[survey_answer_option_index] ASC;

    SELECT
        [survey_question_show_conditions].[survey_page_index],
        [survey_question_show_conditions].[survey_question_index],
        [survey_question_show_conditions].[survey_question_show_condition_index],
        [survey_question_show_conditions].[survey_question_show_condition_operator],
        [survey_question_show_conditions].[survey_question_show_condition_type]
    FROM
        [survey_question_show_conditions]
    WHERE
        [survey_question_show_conditions].[survey_id]
            = @survey_id
    ORDER BY
        [survey_question_show_conditions].[survey_question_index] ASC,
        [survey_question_show_conditions].[survey_question_show_condition_index] ASC;

    SELECT
        [survey_question_show_condition_args_view].[survey_page_index],
        [survey_question_show_condition_args_view].[survey_question_index],
        [survey_question_show_condition_args_view].[survey_question_show_condition_index],
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_index],
        [survey_question_show_condition_args_view].[referenced_survey_page_index],
        [survey_question_show_condition_args_view].[referenced_survey_question_index],
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_integer],
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_text]
    FROM
        [survey_question_show_condition_args_view]
    WHERE
        [survey_question_show_condition_args_view].[survey_id]
            = @survey_id
    ORDER BY
        [survey_question_show_condition_args_view].[survey_question_index] ASC,
        [survey_question_show_condition_args_view].[survey_question_show_condition_index] ASC,
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_index] ASC;

    SELECT
        [survey_question_validation_conditions].[survey_page_index],
        [survey_question_validation_conditions].[survey_question_index],
        [survey_question_validation_conditions].[survey_question_validation_condition_index],
        [survey_question_validation_conditions].[survey_question_validation_condition_operator],
        [survey_question_validation_conditions].[survey_question_validation_condition_type]
    FROM
        [survey_question_validation_conditions]
    WHERE
        [survey_question_validation_conditions].[survey_id]
            = @survey_id
    ORDER BY
        [survey_question_validation_conditions].[survey_question_index] ASC,
        [survey_question_validation_conditions].[survey_question_validation_condition_index] ASC;

    SELECT
        [survey_question_validation_condition_args_view].[survey_page_index],
        [survey_question_validation_condition_args_view].[survey_question_index],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_index],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_index],
        [survey_question_validation_condition_args_view].[referenced_survey_page_index],
        [survey_question_validation_condition_args_view].[referenced_survey_question_index],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_integer],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_text]
    FROM
        [survey_question_validation_condition_args_view]
    WHERE
        [survey_question_validation_condition_args_view].[survey_id]
            = @survey_id
    ORDER BY
        [survey_question_validation_condition_args_view].[survey_question_index] ASC,
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_index] ASC,
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_index] ASC;

END
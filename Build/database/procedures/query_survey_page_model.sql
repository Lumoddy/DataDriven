
CREATE OR ALTER PROCEDURE [query_survey_page_model] (
    @survey_id INT,
    @survey_page_index INT,
    @survey_session_token BINARY(32)) AS
BEGIN

    EXEC [delete_old_survey_sessions];

    SELECT
        [surveys].[survey_title],
        [surveys].[survey_author],
        [surveys].[survey_description],
        (SELECT
            COUNT(*)
        FROM
            [survey_pages]
        WHERE
            [survey_pages].[survey_id]
                = [surveys].[survey_id]) AS [survey_page_count],
        [survey_pages].[survey_page_title],
        [survey_pages].[survey_page_description]
    FROM
        [survey_pages]
    LEFT JOIN
        [surveys]
        ON [surveys].[survey_id]
            = [survey_pages].[survey_id]
    LEFT JOIN
        [survey_sessions]
        ON [survey_sessions].[survey_id]
            = [survey_pages].[survey_id]
    WHERE
        [surveys].[survey_id]
            = @survey_id
        AND [survey_pages].[survey_page_index]
            = @survey_page_index
        AND [survey_sessions].[survey_session_token]
            = @survey_session_token;

    IF @@ROWCOUNT = 0
        RETURN;

    SELECT * INTO
        [#visible_questions]
    FROM
        [survey_visible_questions]
    WHERE
        [survey_visible_questions].[survey_id]
            = @survey_id
        AND [survey_visible_questions].[survey_page_index]
            = @survey_page_index
        AND [survey_visible_questions].[survey_session_token]
            = @survey_session_token
        AND [survey_visible_questions].[survey_question_is_visible]
            = 1;

    SELECT
        [#visible_questions].[survey_question_index],
        [#visible_questions].[survey_question_answer_type],
        [#visible_questions].[survey_question_prompt]
    FROM
        [#visible_questions]
    ORDER BY
        [#visible_questions].[survey_question_index] ASC;

    SELECT
        [survey_question_answer_options].[survey_question_index],
        [survey_question_answer_options].[survey_answer_option_index],
        [survey_question_answer_options].[survey_answer_option_text]
    FROM
        [#visible_questions]
    JOIN
        [survey_question_answer_options]
        ON [survey_question_answer_options].[survey_id]
            = @survey_id
        AND [survey_question_answer_options].[survey_page_index]
            = @survey_page_index
        AND [survey_question_answer_options].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_answer_options].[survey_question_index] ASC,
        [survey_question_answer_options].[survey_answer_option_index] ASC;

    SELECT
        [survey_question_show_conditions].[survey_question_index],
        [survey_question_show_conditions].[survey_question_show_condition_index],
        [survey_question_show_conditions].[survey_question_show_condition_operator],
        [survey_question_show_conditions].[survey_question_show_condition_type]
    FROM
        [#visible_questions]
    JOIN
        [survey_question_show_conditions]
        ON [survey_question_show_conditions].[survey_id]
            = @survey_id
        AND [survey_question_show_conditions].[survey_page_index]
            = @survey_page_index
        AND [survey_question_show_conditions].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_show_conditions].[survey_question_index] ASC,
        [survey_question_show_conditions].[survey_question_show_condition_index] ASC;

    SELECT
        [survey_question_show_condition_args_view].[survey_question_index],
        [survey_question_show_condition_args_view].[survey_question_show_condition_index],
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_index],
        [survey_question_show_condition_args_view].[referenced_survey_page_index],
        [survey_question_show_condition_args_view].[referenced_survey_question_index],
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_integer],
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_text]
    FROM
        [#visible_questions]
    JOIN
        [survey_question_show_condition_args_view]
        ON [survey_question_show_condition_args_view].[survey_id]
            = @survey_id
        AND [survey_question_show_condition_args_view].[survey_page_index]
            = @survey_page_index
        AND [survey_question_show_condition_args_view].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_show_condition_args_view].[survey_question_index] ASC,
        [survey_question_show_condition_args_view].[survey_question_show_condition_index] ASC,
        [survey_question_show_condition_args_view].[survey_question_show_condition_arg_index] ASC;

    SELECT
        [survey_question_validation_conditions].[survey_question_index],
        [survey_question_validation_conditions].[survey_question_validation_condition_index],
        [survey_question_validation_conditions].[survey_question_validation_condition_operator],
        [survey_question_validation_conditions].[survey_question_validation_condition_type]
    FROM
        [#visible_questions]
    JOIN
        [survey_question_validation_conditions]
        ON [survey_question_validation_conditions].[survey_id]
            = @survey_id
        AND [survey_question_validation_conditions].[survey_page_index]
            = @survey_page_index
        AND [survey_question_validation_conditions].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_validation_conditions].[survey_question_index] ASC,
        [survey_question_validation_conditions].[survey_question_validation_condition_index] ASC;

    SELECT
        [survey_question_validation_condition_args_view].[survey_question_index],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_index],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_index],
        [survey_question_validation_condition_args_view].[referenced_survey_page_index],
        [survey_question_validation_condition_args_view].[referenced_survey_question_index],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_integer],
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_text]
    FROM
        [#visible_questions]
    JOIN
        [survey_question_validation_condition_args_view]
        ON [survey_question_validation_condition_args_view].[survey_id]
            = @survey_id
        AND [survey_question_validation_condition_args_view].[survey_page_index]
            = @survey_page_index
        AND [survey_question_validation_condition_args_view].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_validation_condition_args_view].[survey_question_index] ASC,
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_index] ASC,
        [survey_question_validation_condition_args_view].[survey_question_validation_condition_arg_index] ASC;

END
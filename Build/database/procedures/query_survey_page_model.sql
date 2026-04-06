
CREATE OR ALTER PROCEDURE [query_survey_page_model] (
    @survey_id INT,
    @survey_page_index INT,
    @survey_session_token BINARY(32)
) AS
BEGIN

    -- MARK: Get page data if params match.

    SELECT
        [surveys].[survey_title],
        [surveys].[survey_author],
        [surveys].[survey_description],
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
        [surveys].[survey_id] = @survey_id
        AND [survey_pages].[survey_page_index]
            = @survey_page_index
        AND [survey_sessions].[survey_session_token]
            = @survey_session_token;

    IF (@@ROWCOUNT = 0)
        RETURN;

    -- MARK: Cache enum ids.

    DECLARE @answer_type_small_text TINYINT;
    DECLARE @answer_type_checkbox TINYINT;
    DECLARE @answer_type_radio TINYINT;
    DECLARE @answer_type_radio_or_other TINYINT;
    DECLARE @answer_type_multi_select TINYINT;
    DECLARE @answer_type_multi_select_and_other TINYINT;

    EXEC [survey_question_answer_type_fields]
        @small_text = @answer_type_small_text OUTPUT,
        @checkbox = @answer_type_checkbox OUTPUT,
        @radio = @answer_type_radio OUTPUT,
        @radio_or_other = @answer_type_radio_or_other OUTPUT,
        @multi_select = @answer_type_multi_select OUTPUT,
        @multi_select_and_other = @answer_type_multi_select_and_other OUTPUT;

    DECLARE @show_condition_has_answered TINYINT;
    DECLARE @show_condition_has_not_answered TINYINT;

    EXEC [survey_question_show_condition_type_fields]
        @has_answered = @show_condition_has_answered OUTPUT,
        @has_not_answered = @show_condition_has_not_answered OUTPUT;

    DECLARE @operator_and TINYINT;
    DECLARE @operator_or TINYINT;

    EXEC [survey_question_condition_operator_fields]
        @and = @operator_and OUTPUT,
        @or = @operator_or OUTPUT;

    DECLARE @condition_failed TINYINT = 0;
    DECLARE @condition_passed TINYINT = 1;
    DECLARE @condition_undecided TINYINT = 1;

    EXEC [survey_question_condition_passing_fields]
        @failed = @condition_failed OUTPUT,
        @passed = @condition_passed OUTPUT,
        @undecided = @condition_undecided OUTPUT;

    -- MARK: Compute question show constrains on the provided session and cache
    -- all questions that should be visible on this page.

    CREATE TABLE [#visible_questions] (
        [survey_question_index] INT NOT NULL);

    WITH
        [show_conditions_args] AS (
            SELECT
                [args].*,
                [ref_args].[referenced_survey_page_index],
                [ref_args].[referenced_survey_question_index],
                [ref_args].[survey_question_answer_type] AS [referenced_survey_question_answer_type],
                [integer_args].[survey_question_show_condition_arg_integer],
                [text_args].[survey_question_show_condition_arg_text]
            FROM
                [survey_question_show_conditions_args] AS [args]
            LEFT JOIN (
                SELECT
                    [ref_args].*,
                    [ref].[survey_question_answer_type]
                FROM
                    [survey_question_show_conditions_ref_args] AS [ref_args]
                INNER JOIN
                    [survey_questions] AS [ref]
                    ON [ref].[survey_id]
                        = [ref_args].[survey_id]
                    AND [ref].[survey_page_index]
                        = [ref_args].[referenced_survey_page_index]
                    AND [ref].[survey_question_index]
                        = [ref_args].[referenced_survey_question_index]) AS [ref_args]
                ON [ref_args].[survey_id]
                    = [args].[survey_id]
                AND [ref_args].[survey_page_index]
                    = [args].[survey_page_index]
                AND [ref_args].[survey_question_index]
                    = [args].[survey_question_index]
                AND [ref_args].[survey_question_show_condition_index]
                    = [args].[survey_question_show_condition_index]
                AND [ref_args].[survey_question_show_condition_arg_index]
                    = [args].[survey_question_show_condition_arg_index]
            LEFT JOIN
                [survey_question_show_conditions_integer_args] AS [integer_args]
                ON [integer_args].[survey_id]
                    = [args].[survey_id]
                AND [integer_args].[survey_page_index]
                    = [args].[survey_page_index]
                AND [integer_args].[survey_question_index]
                    = [args].[survey_question_index]
                AND [integer_args].[survey_question_show_condition_index]
                    = [args].[survey_question_show_condition_index]
                AND [integer_args].[survey_question_show_condition_arg_index]
                    = [args].[survey_question_show_condition_arg_index]
            LEFT JOIN
                [survey_question_show_conditions_text_args] AS [text_args]
                ON [text_args].[survey_id]
                    = [args].[survey_id]
                AND [text_args].[survey_page_index]
                    = [args].[survey_page_index]
                AND [text_args].[survey_question_index]
                    = [args].[survey_question_index]
                AND [text_args].[survey_question_show_condition_index]
                    = [args].[survey_question_show_condition_index]
                AND [text_args].[survey_question_show_condition_arg_index]
                    = [args].[survey_question_show_condition_arg_index]
            WHERE
                [args].[survey_id]
                    = @survey_id
        ),
        [session_answers] AS (
            SELECT
                [answers].*,
                [integer_answers].[survey_session_answer_integer],
                [text_answers].[survey_session_answer_text]
            FROM
                [survey_session_answers] AS [answers]
            LEFT JOIN
                [survey_session_integer_answers] AS [integer_answers]
                ON [integer_answers].[survey_id]
                    = [answers].[survey_id]
                AND [integer_answers].[survey_page_index]
                    = [answers].[survey_page_index]
                AND [integer_answers].[survey_question_index]
                    = [answers].[survey_question_index]
                AND [integer_answers].[survey_session_answer_index]
                    = [answers].[survey_session_answer_index]
                AND [integer_answers].[survey_session_token]
                    = [answers].[survey_session_token]
            LEFT JOIN
                [survey_session_text_answers] AS [text_answers]
                ON [text_answers].[survey_id]
                    = [answers].[survey_id]
                AND [text_answers].[survey_page_index]
                    = [answers].[survey_page_index]
                AND [text_answers].[survey_question_index]
                    = [answers].[survey_question_index]
                AND [text_answers].[survey_session_answer_index]
                    = [answers].[survey_session_answer_index]
                AND [text_answers].[survey_session_token]
                    = [answers].[survey_session_token]
            WHERE
                [answers].[survey_id]
                    = @survey_id
                AND [answers].[survey_session_token]
                    = @survey_session_token
        )
    INSERT INTO [#visible_questions]
    SELECT
        [questions].[survey_question_index]
    FROM
        [survey_questions] AS [questions]
    WHERE
        [questions].[survey_id] = @survey_id
        AND [questions].[survey_page_index] = @survey_page_index
        AND EXISTS(
            SELECT NULL FROM (
                SELECT
                    SUM(CASE -- The index of the groups of consecutive `and`s.
                        WHEN
                            [conditions].[survey_question_show_condition_operator]
                                = @operator_or
                        THEN 1
                        ELSE 0
                    END) OVER (
                        ORDER BY [conditions].[survey_question_index]
                        ROWS UNBOUNDED PRECEDING)
                        AS [condition_group_index],
                    (
                    SELECT CASE -- The pass condition
                        WHEN
                            [conditions].[survey_question_show_condition_type]
                                = @show_condition_has_answered
                        THEN CASE
                            WHEN EXISTS(
                                SELECT NULL FROM
                                    [show_conditions_args]
                                WHERE
                                    [show_conditions_args].[survey_id]
                                        = @survey_id
                                    AND [show_conditions_args].[survey_page_index]
                                        = @survey_page_index
                                    AND [show_conditions_args].[survey_question_index]
                                        = [conditions].[survey_question_index]
                                    AND [show_conditions_args].[survey_question_show_condition_index]
                                        = [conditions].[survey_question_show_condition_index]
                                    AND CASE
                                        WHEN
                                            [show_conditions_args].[survey_question_show_condition_arg_index]
                                                = 0
                                        THEN CASE
                                            WHEN
                                                [show_conditions_args].[referenced_survey_page_index]
                                                    >= [conditions].[survey_page_index]
                                            THEN 1
                                            ELSE 0
                                        END
                                        ELSE 0
                                    END != 0)
                            THEN @condition_undecided
                            WHEN EXISTS(
                                SELECT NULL FROM
                                    [show_conditions_args]
                                WHERE
                                    [show_conditions_args].[survey_id]
                                        = @survey_id
                                    AND [show_conditions_args].[survey_page_index]
                                        = @survey_page_index
                                    AND [show_conditions_args].[survey_question_index]
                                        = [conditions].[survey_question_index]
                                    AND [show_conditions_args].[survey_question_show_condition_index]
                                        = [conditions].[survey_question_show_condition_index]
                                    AND [show_conditions_args].[survey_question_show_condition_arg_index]
                                        = 0
                                    AND [show_conditions_args].[referenced_survey_page_index]
                                        < [show_conditions_args].[survey_page_index]
                                    AND CASE
                                        WHEN
                                            [show_conditions_args].[referenced_survey_question_answer_type]
                                                IN (@answer_type_small_text)
                                        THEN CASE
                                            WHEN EXISTS(
                                                SELECT NULL FROM
                                                    [session_answers]
                                                WHERE
                                                    [session_answers].[survey_id]
                                                        = @survey_id
                                                    AND [session_answers].[survey_page_index]
                                                        = [show_conditions_args].[referenced_survey_page_index]
                                                    AND [session_answers].[survey_question_index]
                                                        = [show_conditions_args].[referenced_survey_question_index]
                                                    AND [session_answers].[survey_session_answer_index]
                                                        = 0
                                                    AND REGEXP_LIKE(
                                                        [session_answers].[survey_session_answer_text],
                                                        COALESCE(
                                                            CAST((SELECT
                                                                [show_conditions_args].[survey_question_show_condition_arg_text]
                                                            FROM
                                                                [show_conditions_args]
                                                            WHERE
                                                                [show_conditions_args].[survey_id]
                                                                    = @survey_id
                                                                AND [show_conditions_args].[survey_page_index]
                                                                    = @survey_page_index
                                                                AND [show_conditions_args].[survey_question_index]
                                                                    = [conditions].[survey_question_index]
                                                                AND [show_conditions_args].[survey_question_show_condition_index]
                                                                    = [conditions].[survey_question_show_condition_index]
                                                                AND [show_conditions_args].[survey_question_show_condition_arg_index]
                                                                    = 1) AS VARCHAR(8000)),
                                                            '^[^]')))
                                            THEN 1
                                            ELSE 0
                                        END
                                        WHEN
                                            [show_conditions_args].[referenced_survey_question_answer_type]
                                                IN (@answer_type_checkbox, @answer_type_radio, @answer_type_radio_or_other)
                                        THEN CASE
                                            WHEN EXISTS(
                                                SELECT NULL FROM
                                                    [session_answers]
                                                WHERE
                                                    [session_answers].[survey_id]
                                                        = @survey_id
                                                    AND [session_answers].[survey_page_index]
                                                        = [show_conditions_args].[referenced_survey_page_index]
                                                    AND [session_answers].[survey_question_index]
                                                        = [show_conditions_args].[referenced_survey_question_index]
                                                    AND [session_answers].[survey_session_answer_index]
                                                        = 0)
                                            THEN 1
                                            ELSE 0
                                        END
                                        WHEN
                                            [show_conditions_args].[referenced_survey_question_answer_type]
                                                IN (@answer_type_multi_select, @answer_type_multi_select_and_other)
                                        THEN CASE
                                            WHEN EXISTS(
                                                SELECT NULL FROM
                                                    [session_answers]
                                                WHERE
                                                    [session_answers].[survey_id]
                                                        = @survey_id
                                                    AND [session_answers].[survey_page_index]
                                                        = [show_conditions_args].[referenced_survey_page_index]
                                                    AND [session_answers].[survey_question_index]
                                                        = [show_conditions_args].[referenced_survey_question_index])
                                            THEN 1
                                            ELSE 0
                                        END
                                    END != 0)
                            THEN @condition_passed
                            ELSE @condition_failed
                        END
                        WHEN
                            [conditions].[survey_question_show_condition_type]
                                = @show_condition_has_not_answered
                        THEN CASE
                            WHEN EXISTS(
                                SELECT NULL FROM
                                    [show_conditions_args]
                                WHERE
                                    [show_conditions_args].[survey_id]
                                        = @survey_id
                                    AND [show_conditions_args].[survey_page_index]
                                        = @survey_page_index
                                    AND [show_conditions_args].[survey_question_index]
                                        = [conditions].[survey_question_index]
                                    AND [show_conditions_args].[survey_question_show_condition_index]
                                        = [conditions].[survey_question_show_condition_index]
                                    AND CASE
                                        WHEN
                                            [show_conditions_args].[survey_question_show_condition_arg_index]
                                                = 0
                                        THEN CASE
                                            WHEN
                                                [show_conditions_args].[referenced_survey_page_index]
                                                    >= [conditions].[survey_page_index]
                                            THEN 1
                                            ELSE 0
                                        END
                                        ELSE 0
                                    END != 0)
                            THEN @condition_undecided
                            WHEN EXISTS(
                                SELECT NULL FROM
                                    [show_conditions_args]
                                WHERE
                                    [show_conditions_args].[survey_id]
                                        = @survey_id
                                    AND [show_conditions_args].[survey_page_index]
                                        = @survey_page_index
                                    AND [show_conditions_args].[survey_question_index]
                                        = [conditions].[survey_question_index]
                                    AND [show_conditions_args].[survey_question_show_condition_index]
                                        = [conditions].[survey_question_show_condition_index]
                                    AND [show_conditions_args].[survey_question_show_condition_arg_index]
                                        = 0
                                    AND [show_conditions_args].[referenced_survey_page_index]
                                        < [show_conditions_args].[survey_page_index]
                                    AND CASE
                                        WHEN
                                            [show_conditions_args].[referenced_survey_question_answer_type]
                                                IN (@answer_type_small_text)
                                        THEN CASE
                                            WHEN EXISTS(
                                                SELECT NULL FROM
                                                    [session_answers]
                                                WHERE
                                                    [session_answers].[survey_id]
                                                        = @survey_id
                                                    AND [session_answers].[survey_page_index]
                                                        = [show_conditions_args].[referenced_survey_page_index]
                                                    AND [session_answers].[survey_question_index]
                                                        = [show_conditions_args].[referenced_survey_question_index]
                                                    AND [session_answers].[survey_session_answer_index]
                                                        = 0
                                                    AND REGEXP_LIKE(
                                                        [session_answers].[survey_session_answer_text],
                                                        COALESCE(
                                                            CAST((SELECT
                                                                [show_conditions_args].[survey_question_show_condition_arg_text]
                                                            FROM
                                                                [show_conditions_args]
                                                            WHERE
                                                                [show_conditions_args].[survey_id]
                                                                    = @survey_id
                                                                AND [show_conditions_args].[survey_page_index]
                                                                    = @survey_page_index
                                                                AND [show_conditions_args].[survey_question_index]
                                                                    = [conditions].[survey_question_index]
                                                                AND [show_conditions_args].[survey_question_show_condition_index]
                                                                    = [conditions].[survey_question_show_condition_index]
                                                                AND [show_conditions_args].[survey_question_show_condition_arg_index]
                                                                    = 1) AS VARCHAR(8000)),
                                                            '^[^]')))
                                            THEN 1
                                            ELSE 0
                                        END
                                        WHEN
                                            [show_conditions_args].[referenced_survey_question_answer_type]
                                                IN (@answer_type_checkbox, @answer_type_radio, @answer_type_radio_or_other)
                                        THEN CASE
                                            WHEN EXISTS(
                                                SELECT NULL FROM
                                                    [session_answers]
                                                WHERE
                                                    [session_answers].[survey_id]
                                                        = @survey_id
                                                    AND [session_answers].[survey_page_index]
                                                        = [show_conditions_args].[referenced_survey_page_index]
                                                    AND [session_answers].[survey_question_index]
                                                        = [show_conditions_args].[referenced_survey_question_index]
                                                    AND [session_answers].[survey_session_answer_index]
                                                        = 0)
                                            THEN 1
                                            ELSE 0
                                        END
                                        WHEN
                                            [show_conditions_args].[referenced_survey_question_answer_type]
                                                IN (@answer_type_multi_select, @answer_type_multi_select_and_other)
                                        THEN CASE
                                            WHEN EXISTS(
                                                SELECT NULL FROM
                                                    [session_answers]
                                                WHERE
                                                    [session_answers].[survey_id]
                                                        = @survey_id
                                                    AND [session_answers].[survey_page_index]
                                                        = [show_conditions_args].[referenced_survey_page_index]
                                                    AND [session_answers].[survey_question_index]
                                                        = [show_conditions_args].[referenced_survey_question_index])
                                            THEN 1
                                            ELSE 0
                                        END
                                    END != 0)
                            THEN @condition_failed
                            ELSE @condition_passed
                        END
                    END) AS [condition_passed]
                FROM
                    [survey_question_show_conditions] AS [conditions]
                WHERE
                    [conditions].[survey_id]
                        = @survey_id
                    AND [conditions].[survey_page_index]
                        = @survey_page_index
                    AND [conditions].[survey_question_index]
                        = [questions].[survey_question_index]
            )
                AS [conditions]
            GROUP BY
                [conditions].[condition_group_index]
            HAVING MIN([conditions].[condition_passed]) != 0);

    -- MARK: Return information about the chosen visible questions.

    SELECT
        [survey_questions].[survey_question_index],
        [survey_questions].[survey_question_answer_type],
        [survey_questions].[survey_question_prompt]
    FROM
        [#visible_questions]
    LEFT JOIN
        [survey_questions]
        ON [survey_questions].[survey_id]
            = @survey_id
        AND [survey_questions].[survey_page_index]
            = @survey_page_index
        AND [survey_questions].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_questions].[survey_question_index] ASC;

    SELECT
        [survey_question_answer_options].[survey_question_index],
        [survey_question_answer_options].[survey_answer_option_index],
        [survey_question_answer_options].[survey_answer_option_text]
    FROM
        [#visible_questions]
    LEFT JOIN
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
    LEFT JOIN
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
        [survey_question_show_conditions_ref_args].[survey_question_index],
        [survey_question_show_conditions_ref_args].[survey_question_show_condition_index],
        [survey_question_show_conditions_ref_args].[survey_question_show_condition_arg_index],
        [survey_question_show_conditions_ref_args].[referenced_survey_page_index],
        [survey_question_show_conditions_ref_args].[referenced_survey_question_index]
    FROM
        [#visible_questions]
    LEFT JOIN
        [survey_question_show_conditions_ref_args]
        ON [survey_question_show_conditions_ref_args].[survey_id]
            = @survey_id
        AND [survey_question_show_conditions_ref_args].[survey_page_index]
            = @survey_page_index
        AND [survey_question_show_conditions_ref_args].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_show_conditions_ref_args].[survey_question_index] ASC,
        [survey_question_show_conditions_ref_args].[survey_question_show_condition_index] ASC,
        [survey_question_show_conditions_ref_args].[survey_question_show_condition_arg_index] ASC;

    SELECT
        [survey_question_show_conditions_integer_args].[survey_question_index],
        [survey_question_show_conditions_integer_args].[survey_question_show_condition_index],
        [survey_question_show_conditions_integer_args].[survey_question_show_condition_arg_index],
        [survey_question_show_conditions_integer_args].[survey_question_show_condition_arg_integer]
    FROM
        [#visible_questions]
    LEFT JOIN
        [survey_question_show_conditions_integer_args]
        ON [survey_question_show_conditions_integer_args].[survey_id]
            = @survey_id
        AND [survey_question_show_conditions_integer_args].[survey_page_index]
            = @survey_page_index
        AND [survey_question_show_conditions_integer_args].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_show_conditions_integer_args].[survey_question_index] ASC,
        [survey_question_show_conditions_integer_args].[survey_question_show_condition_index] ASC,
        [survey_question_show_conditions_integer_args].[survey_question_show_condition_arg_index] ASC;

    SELECT
        [survey_question_show_conditions_text_args].[survey_question_index],
        [survey_question_show_conditions_text_args].[survey_question_show_condition_index],
        [survey_question_show_conditions_text_args].[survey_question_show_condition_arg_index],
        [survey_question_show_conditions_text_args].[survey_question_show_condition_arg_text]
    FROM
        [#visible_questions]
    LEFT JOIN
        [survey_question_show_conditions_text_args]
        ON [survey_question_show_conditions_text_args].[survey_id]
            = @survey_id
        AND [survey_question_show_conditions_text_args].[survey_page_index]
            = @survey_page_index
        AND [survey_question_show_conditions_text_args].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_show_conditions_text_args].[survey_question_index] ASC,
        [survey_question_show_conditions_text_args].[survey_question_show_condition_index] ASC,
        [survey_question_show_conditions_text_args].[survey_question_show_condition_arg_index] ASC;

    SELECT
        [survey_question_validation_conditions].[survey_question_index],
        [survey_question_validation_conditions].[survey_question_validation_condition_index],
        [survey_question_validation_conditions].[survey_question_validation_condition_operator],
        [survey_question_validation_conditions].[survey_question_validation_condition_type]
    FROM
        [#visible_questions]
    LEFT JOIN
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
        [survey_question_validation_conditions_ref_args].[survey_question_index],
        [survey_question_validation_conditions_ref_args].[survey_question_validation_condition_index],
        [survey_question_validation_conditions_ref_args].[survey_question_validation_condition_arg_index],
        [survey_question_validation_conditions_ref_args].[referenced_survey_page_index],
        [survey_question_validation_conditions_ref_args].[referenced_survey_question_index]
    FROM
        [#visible_questions]
    LEFT JOIN
        [survey_question_validation_conditions_ref_args]
        ON [survey_question_validation_conditions_ref_args].[survey_id]
            = @survey_id
        AND [survey_question_validation_conditions_ref_args].[survey_page_index]
            = @survey_page_index
        AND [survey_question_validation_conditions_ref_args].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_validation_conditions_ref_args].[survey_question_index] ASC,
        [survey_question_validation_conditions_ref_args].[survey_question_validation_condition_index] ASC,
        [survey_question_validation_conditions_ref_args].[survey_question_validation_condition_arg_index] ASC;

    SELECT
        [survey_question_validation_conditions_integer_args].[survey_question_index],
        [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_index],
        [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_index],
        [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_integer]
    FROM
        [#visible_questions]
    LEFT JOIN
        [survey_question_validation_conditions_integer_args]
        ON [survey_question_validation_conditions_integer_args].[survey_id]
            = @survey_id
        AND [survey_question_validation_conditions_integer_args].[survey_page_index]
            = @survey_page_index
        AND [survey_question_validation_conditions_integer_args].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_validation_conditions_integer_args].[survey_question_index] ASC,
        [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_index] ASC,
        [survey_question_validation_conditions_integer_args].[survey_question_validation_condition_arg_index] ASC;

    SELECT
        [survey_question_validation_conditions_text_args].[survey_question_index],
        [survey_question_validation_conditions_text_args].[survey_question_validation_condition_index],
        [survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_index],
        [survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_text]
    FROM
        [#visible_questions]
    LEFT JOIN
        [survey_question_validation_conditions_text_args]
        ON [survey_question_validation_conditions_text_args].[survey_id]
            = @survey_id
        AND [survey_question_validation_conditions_text_args].[survey_page_index]
            = @survey_page_index
        AND [survey_question_validation_conditions_text_args].[survey_question_index]
            = [#visible_questions].[survey_question_index]
    ORDER BY
        [survey_question_validation_conditions_text_args].[survey_question_index] ASC,
        [survey_question_validation_conditions_text_args].[survey_question_validation_condition_index] ASC,
        [survey_question_validation_conditions_text_args].[survey_question_validation_condition_arg_index] ASC;

END
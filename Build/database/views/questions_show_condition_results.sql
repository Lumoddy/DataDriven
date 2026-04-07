
CREATE OR ALTER VIEW [survey_question_show_condition_results] AS
WITH
    [operator] AS (
        SELECT
            (SELECT [survey_question_condition_operator_id]
            FROM [survey_question_condition_operator]
            WHERE [survey_question_condition_operator_name] = 'or') AS [or],
            (SELECT [survey_question_condition_operator_id]
            FROM [survey_question_condition_operator]
            WHERE [survey_question_condition_operator_name] = 'and') AS [and]
    ),
    [answer_type] AS (
        SELECT
            (SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'small_text') AS [small_text],
            (SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'checkbox') AS [checkbox],
            (SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'radio') AS [radio],
            (SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'radio_or_other') AS [radio_or_other],
            (SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'multi_select') AS [multi_select],
            (SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'multi_select_and_other') AS [multi_select_and_other]
    ),
    [show_condition_type] AS (
        SELECT
            (SELECT [survey_question_show_condition_type_id]
            FROM [survey_question_show_condition_types]
            WHERE [survey_question_show_condition_type_name] = 'has_answered') AS [has_answered],
            (SELECT [survey_question_show_condition_type_id]
            FROM [survey_question_show_condition_types]
            WHERE [survey_question_show_condition_type_name] = 'has_not_answered') AS [has_not_answered]
    )
SELECT
    [survey_questions].*,
    [survey_sessions].[survey_session_expiry],
    [survey_sessions].[survey_session_token],
    CASE
        WHEN NOT EXISTS(
            SELECT NULL FROM
                [survey_question_show_conditions]
            WHERE
                [survey_question_show_conditions].[survey_id]
                    = [survey_questions].[survey_id]
                AND [survey_question_show_conditions].[survey_page_index]
                    = [survey_questions].[survey_page_index]
                AND [survey_question_show_conditions].[survey_question_index]
                    = [survey_questions].[survey_question_index])
        OR EXISTS(
            SELECT NULL FROM (
                SELECT
                    SUM(CASE
                        WHEN
                            [survey_question_show_conditions].[survey_question_show_condition_operator]
                                = [operator].[or]
                        THEN 1
                        ELSE 0
                    END)
                        OVER (ORDER BY [survey_question_show_conditions].[survey_question_index])
                        AS [condition_group_index],
                    CASE
                        WHEN (
                                [survey_question_show_conditions].[survey_question_show_condition_type]
                                    IN (
                                        [show_condition_type].[has_answered],
                                        [show_condition_type].[has_not_answered])
                                AND (
                                    (
                                        EXISTS(
                                            SELECT NULL FROM
                                                [survey_question_show_conditions_args_view] AS [ref_args]
                                            WHERE
                                                [ref_args].[survey_id]
                                                    = [survey_question_show_conditions].[survey_id]
                                                AND [ref_args].[survey_page_index]
                                                    = [survey_question_show_conditions].[survey_page_index]
                                                AND [ref_args].[survey_question_index]
                                                    = [survey_question_show_conditions].[survey_question_index]
                                                AND [ref_args].[survey_question_show_condition_index]
                                                    = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                AND [ref_args].[survey_question_show_condition_arg_index]
                                                    = 0
                                                AND [ref_args].[referenced_survey_question_answer_type]
                                                    IS NOT NULL
                                                AND [ref_args].[referenced_survey_page_index]
                                                    >= [survey_questions].[survey_page_index]))
                                    OR CASE
                                        WHEN EXISTS(
                                            SELECT NULL FROM
                                                [survey_question_show_conditions_args_view] AS [ref_args]
                                            WHERE
                                                [ref_args].[survey_id]
                                                    = [survey_question_show_conditions].[survey_id]
                                                AND [ref_args].[survey_page_index]
                                                    = [survey_question_show_conditions].[survey_page_index]
                                                AND [ref_args].[survey_question_index]
                                                    = [survey_question_show_conditions].[survey_question_index]
                                                AND [ref_args].[survey_question_show_condition_index]
                                                    = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                AND [ref_args].[survey_question_show_condition_arg_index]
                                                    = 0
                                                AND [ref_args].[referenced_survey_question_answer_type]
                                                    IS NOT NULL
                                                AND (
                                                    (
                                                        [ref_args].[referenced_survey_question_answer_type]
                                                            = [answer_type].[small_text]
                                                        AND EXISTS(
                                                            SELECT NULL FROM
                                                                [survey_session_answers_view] AS [answers]
                                                            WHERE [answers].[survey_id]
                                                                = [survey_question_show_conditions].[survey_id]
                                                            AND [answers].[survey_page_index]
                                                                = [ref_args].[referenced_survey_page_index]
                                                            AND [answers].[survey_question_index]
                                                                = [ref_args].[referenced_survey_question_index]
                                                            AND [answers].[survey_session_answer_index]
                                                                = 0
                                                            AND REGEXP_LIKE(
                                                                COALESCE([answers].[survey_session_answer_text], ''),
                                                                COALESCE(
                                                                    (
                                                                        SELECT
                                                                            CAST([text_args].[survey_question_show_condition_arg_text] AS VARCHAR(8000))
                                                                        FROM
                                                                            [survey_question_show_conditions_text_args] AS [text_args]
                                                                        WHERE
                                                                            [text_args].[survey_id]
                                                                                = [survey_question_show_conditions].[survey_id]
                                                                            AND [text_args].[survey_page_index]
                                                                                = [survey_question_show_conditions].[survey_page_index]
                                                                            AND [text_args].[survey_question_index]
                                                                                = [survey_question_show_conditions].[survey_question_index]
                                                                            AND [text_args].[survey_question_show_condition_index]
                                                                                = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                            AND [text_args].[survey_question_show_condition_arg_index]
                                                                                = 1),
                                                                    '^[^]'))))
                                                    OR (
                                                        [ref_args].[referenced_survey_question_answer_type]
                                                            = [answer_type].[checkbox]
                                                        AND EXISTS(
                                                            SELECT NULL FROM
                                                                [survey_session_answers] AS [answers]
                                                            WHERE [answers].[survey_id]
                                                                = [survey_question_show_conditions].[survey_id]
                                                            AND [answers].[survey_page_index]
                                                                = [ref_args].[referenced_survey_page_index]
                                                            AND [answers].[survey_question_index]
                                                                = [ref_args].[referenced_survey_question_index]
                                                            AND [answers].[survey_session_answer_index]
                                                                = 0))
                                                    OR (
                                                        [ref_args].[referenced_survey_question_answer_type]
                                                            = [answer_type].[radio]
                                                        AND EXISTS(
                                                            SELECT NULL FROM
                                                                [survey_session_answers_view] AS [answers]
                                                            WHERE [answers].[survey_id]
                                                                = [survey_question_show_conditions].[survey_id]
                                                            AND [answers].[survey_page_index]
                                                                = [ref_args].[referenced_survey_page_index]
                                                            AND [answers].[survey_question_index]
                                                                = [ref_args].[referenced_survey_question_index]
                                                            AND [answers].[survey_session_answer_index]
                                                                = 0
                                                            AND [answers].[survey_session_answer_integer]
                                                                IS NOT NULL
                                                            AND (
                                                                NOT EXISTS(
                                                                    SELECT NULL FROM
                                                                        [survey_question_show_conditions_args] AS [mask_args]
                                                                    WHERE
                                                                        [mask_args].[survey_id]
                                                                            = [survey_question_show_conditions].[survey_id]
                                                                        AND [mask_args].[survey_page_index]
                                                                            = [survey_question_show_conditions].[survey_page_index]
                                                                        AND [mask_args].[survey_question_index]
                                                                            = [survey_question_show_conditions].[survey_question_index]
                                                                        AND [mask_args].[survey_question_show_condition_index]
                                                                            = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                        AND [mask_args].[survey_question_show_condition_arg_index]
                                                                            > 0)
                                                                OR EXISTS(
                                                                    SELECT NULL FROM
                                                                        [survey_question_show_conditions_args] AS [mask_args]
                                                                    WHERE
                                                                        [mask_args].[survey_id]
                                                                            = [survey_question_show_conditions].[survey_id]
                                                                        AND [mask_args].[survey_page_index]
                                                                            = [survey_question_show_conditions].[survey_page_index]
                                                                        AND [mask_args].[survey_question_index]
                                                                            = [survey_question_show_conditions].[survey_question_index]
                                                                        AND [mask_args].[survey_question_show_condition_index]
                                                                            = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                        AND [mask_args].[survey_question_show_condition_arg_index]
                                                                            = [answers].[survey_session_answer_integer] + 1))))
                                                    OR (
                                                        [ref_args].[referenced_survey_question_answer_type]
                                                            = [answer_type].[radio_or_other]
                                                        AND EXISTS(
                                                            SELECT NULL FROM
                                                                [survey_session_answers_view] AS [answers]
                                                            WHERE [answers].[survey_id]
                                                                = [survey_question_show_conditions].[survey_id]
                                                            AND [answers].[survey_page_index]
                                                                = [ref_args].[referenced_survey_page_index]
                                                            AND [answers].[survey_question_index]
                                                                = [ref_args].[referenced_survey_question_index]
                                                            AND [answers].[survey_session_answer_index]
                                                                = 0
                                                            AND (
                                                                (
                                                                    [answers].[survey_session_answer_text]
                                                                        IS NULL
                                                                    AND [answers].[survey_session_answer_integer]
                                                                        IS NOT NULL
                                                                    AND (
                                                                        NOT EXISTS(
                                                                            SELECT NULL FROM
                                                                                [survey_question_show_conditions_args] AS [mask_args]
                                                                            WHERE
                                                                                [mask_args].[survey_id]
                                                                                    = [survey_question_show_conditions].[survey_id]
                                                                                AND [mask_args].[survey_page_index]
                                                                                    = [survey_question_show_conditions].[survey_page_index]
                                                                                AND [mask_args].[survey_question_index]
                                                                                    = [survey_question_show_conditions].[survey_question_index]
                                                                                AND [mask_args].[survey_question_show_condition_index]
                                                                                    = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                                AND [mask_args].[survey_question_show_condition_arg_index]
                                                                                    > 1)
                                                                        OR EXISTS(
                                                                            SELECT NULL FROM
                                                                                [survey_question_show_conditions_args] AS [mask_args]
                                                                            WHERE
                                                                                [mask_args].[survey_id]
                                                                                    = [survey_question_show_conditions].[survey_id]
                                                                                AND [mask_args].[survey_page_index]
                                                                                    = [survey_question_show_conditions].[survey_page_index]
                                                                                AND [mask_args].[survey_question_index]
                                                                                    = [survey_question_show_conditions].[survey_question_index]
                                                                                AND [mask_args].[survey_question_show_condition_index]
                                                                                    = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                                AND [mask_args].[survey_question_show_condition_arg_index]
                                                                                    = [answers].[survey_session_answer_integer] + 2)))
                                                                OR (
                                                                    [answers].[survey_session_answer_text]
                                                                        IS NOT NULL
                                                                    AND [answers].[survey_session_answer_integer]
                                                                        IS NULL
                                                                    AND REGEXP_LIKE(
                                                                        COALESCE([answers].[survey_session_answer_text], ''),
                                                                        COALESCE(
                                                                            (
                                                                                SELECT
                                                                                    CAST([text_args].[survey_question_show_condition_arg_text] AS VARCHAR(8000))
                                                                                FROM
                                                                                    [survey_question_show_conditions_text_args] AS [text_args]
                                                                                WHERE
                                                                                    [text_args].[survey_id]
                                                                                        = [survey_question_show_conditions].[survey_id]
                                                                                    AND [text_args].[survey_page_index]
                                                                                        = [survey_question_show_conditions].[survey_page_index]
                                                                                    AND [text_args].[survey_question_index]
                                                                                        = [survey_question_show_conditions].[survey_question_index]
                                                                                    AND [text_args].[survey_question_show_condition_index]
                                                                                        = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                                    AND [text_args].[survey_question_show_condition_arg_index]
                                                                                        = 1),
                                                                            '^[^]'))))))
                                                    OR (
                                                        [ref_args].[referenced_survey_question_answer_type]
                                                            = [answer_type].[multi_select]
                                                        AND EXISTS(
                                                            SELECT NULL FROM
                                                                [survey_session_answers] AS [answers]
                                                            WHERE [answers].[survey_id]
                                                                = [survey_question_show_conditions].[survey_id]
                                                            AND [answers].[survey_page_index]
                                                                = [ref_args].[referenced_survey_page_index]
                                                            AND [answers].[survey_question_index]
                                                                = [ref_args].[referenced_survey_question_index]
                                                            AND (
                                                                NOT EXISTS(
                                                                    SELECT NULL FROM
                                                                        [survey_question_show_conditions_args] AS [mask_args]
                                                                    WHERE
                                                                        [mask_args].[survey_id]
                                                                            = [survey_question_show_conditions].[survey_id]
                                                                        AND [mask_args].[survey_page_index]
                                                                            = [survey_question_show_conditions].[survey_page_index]
                                                                        AND [mask_args].[survey_question_index]
                                                                            = [survey_question_show_conditions].[survey_question_index]
                                                                        AND [mask_args].[survey_question_show_condition_index]
                                                                            = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                        AND [mask_args].[survey_question_show_condition_arg_index]
                                                                            > 0)
                                                                OR EXISTS(
                                                                    SELECT NULL FROM
                                                                        [survey_question_show_conditions_args] AS [mask_args]
                                                                    WHERE
                                                                        [mask_args].[survey_id]
                                                                            = [survey_question_show_conditions].[survey_id]
                                                                        AND [mask_args].[survey_page_index]
                                                                            = [survey_question_show_conditions].[survey_page_index]
                                                                        AND [mask_args].[survey_question_index]
                                                                            = [survey_question_show_conditions].[survey_question_index]
                                                                        AND [mask_args].[survey_question_show_condition_index]
                                                                            = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                        AND [mask_args].[survey_question_show_condition_arg_index]
                                                                            = [answers].[survey_session_answer_index] + 1))))
                                                    OR (
                                                        [ref_args].[referenced_survey_question_answer_type]
                                                            = [answer_type].[multi_select_and_other]
                                                        AND EXISTS(
                                                            SELECT NULL FROM
                                                                [survey_session_answers_view] AS [answers]
                                                            WHERE [answers].[survey_id]
                                                                = [survey_question_show_conditions].[survey_id]
                                                            AND [answers].[survey_page_index]
                                                                = [ref_args].[referenced_survey_page_index]
                                                            AND [answers].[survey_question_index]
                                                                = [ref_args].[referenced_survey_question_index]
                                                            AND [answers].[survey_session_answer_index]
                                                                = 0
                                                            AND (
                                                                (
                                                                    [answers].[survey_session_answer_text]
                                                                        IS NULL
                                                                    AND (
                                                                        NOT EXISTS(
                                                                            SELECT NULL FROM
                                                                                [survey_question_show_conditions_args] AS [mask_args]
                                                                            WHERE
                                                                                [mask_args].[survey_id]
                                                                                    = [survey_question_show_conditions].[survey_id]
                                                                                AND [mask_args].[survey_page_index]
                                                                                    = [survey_question_show_conditions].[survey_page_index]
                                                                                AND [mask_args].[survey_question_index]
                                                                                    = [survey_question_show_conditions].[survey_question_index]
                                                                                AND [mask_args].[survey_question_show_condition_index]
                                                                                    = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                                AND [mask_args].[survey_question_show_condition_arg_index]
                                                                                    > 0)
                                                                        OR EXISTS(
                                                                            SELECT NULL FROM
                                                                                [survey_question_show_conditions_args] AS [mask_args]
                                                                            WHERE
                                                                                [mask_args].[survey_id]
                                                                                    = [survey_question_show_conditions].[survey_id]
                                                                                AND [mask_args].[survey_page_index]
                                                                                    = [survey_question_show_conditions].[survey_page_index]
                                                                                AND [mask_args].[survey_question_index]
                                                                                    = [survey_question_show_conditions].[survey_question_index]
                                                                                AND [mask_args].[survey_question_show_condition_index]
                                                                                    = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                                AND [mask_args].[survey_question_show_condition_arg_index]
                                                                                    = [answers].[survey_session_answer_integer] + 1)))
                                                                OR (
                                                                    [answers].[survey_session_answer_text]
                                                                        IS NOT NULL
                                                                    AND REGEXP_LIKE(
                                                                        COALESCE([answers].[survey_session_answer_text], ''),
                                                                        COALESCE(
                                                                            (
                                                                                SELECT
                                                                                    CAST([text_args].[survey_question_show_condition_arg_text] AS VARCHAR(8000))
                                                                                FROM
                                                                                    [survey_question_show_conditions_text_args] AS [text_args]
                                                                                WHERE
                                                                                    [text_args].[survey_id]
                                                                                        = [survey_question_show_conditions].[survey_id]
                                                                                    AND [text_args].[survey_page_index]
                                                                                        = [survey_question_show_conditions].[survey_page_index]
                                                                                    AND [text_args].[survey_question_index]
                                                                                        = [survey_question_show_conditions].[survey_question_index]
                                                                                    AND [text_args].[survey_question_show_condition_index]
                                                                                        = [survey_question_show_conditions].[survey_question_show_condition_index]
                                                                                    AND [text_args].[survey_question_show_condition_arg_index]
                                                                                        = 1),
                                                                            '^[^]'))))))))
                                        THEN CAST(1 AS BIT)
                                        ELSE CAST(0 AS BIT)
                                    END
                                    = CASE
                                        WHEN
                                            [show_condition_type].[has_answered]
                                                = [survey_question_show_conditions].[survey_question_show_condition_type]
                                        THEN CAST(1 AS BIT)
                                        ELSE CAST(0 AS BIT)
                                    END))
                        THEN CAST(1 AS BIT)
                        ELSE CAST(0 AS BIT)
                    END AS [condition_passed]
                FROM
                    [survey_question_show_conditions]
                WHERE
                    [survey_question_show_conditions].[survey_id]
                        = [survey_questions].[survey_id]
                    AND [survey_question_show_conditions].[survey_page_index]
                        = [survey_questions].[survey_page_index]
                    AND [survey_question_show_conditions].[survey_question_index]
                        = [survey_questions].[survey_question_index]
            )
                AS [conditions]
            GROUP BY
                [conditions].[condition_group_index]
            HAVING MIN(CAST([conditions].[condition_passed] AS TINYINT)) <> 0)
        THEN CAST(1 AS BIT)
        ELSE CAST(0 AS BIT)
    END AS [survey_question_is_visible]
FROM
    [survey_questions]
INNER JOIN
    [survey_sessions]
    ON [survey_sessions].[survey_id]
        = [survey_questions].[survey_id]
CROSS JOIN
    [operator]
CROSS JOIN
    [answer_type]
CROSS JOIN
    [show_condition_type]
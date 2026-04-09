
CREATE OR ALTER VIEW [survey_question_show_condition_results] AS
WITH
    [answer_type] AS (
        SELECT
            (SELECT
                [survey_question_answer_types].[survey_question_answer_type_id]
            FROM
                [survey_question_answer_types]
            WHERE
                [survey_question_answer_types].[survey_question_answer_type_name]
                    = 'small_text') AS [small_text],
            (SELECT
                [survey_question_answer_types].[survey_question_answer_type_id]
            FROM
                [survey_question_answer_types]
            WHERE
                [survey_question_answer_types].[survey_question_answer_type_name]
                    = 'checkbox') AS [checkbox],
            (SELECT
                [survey_question_answer_types].[survey_question_answer_type_id]
            FROM
                [survey_question_answer_types]
            WHERE
                [survey_question_answer_types].[survey_question_answer_type_name]
                    = 'radio') AS [radio],
            (SELECT
                [survey_question_answer_types].[survey_question_answer_type_id]
            FROM
                [survey_question_answer_types]
            WHERE
                [survey_question_answer_types].[survey_question_answer_type_name]
                    = 'radio_or_other') AS [radio_or_other],
            (SELECT
                [survey_question_answer_types].[survey_question_answer_type_id]
            FROM
                [survey_question_answer_types]
            WHERE
                [survey_question_answer_types].[survey_question_answer_type_name]
                    = 'multi_select') AS [multi_select],
            (SELECT
                [survey_question_answer_types].[survey_question_answer_type_id]
            FROM
                [survey_question_answer_types]
            WHERE
                [survey_question_answer_types].[survey_question_answer_type_name]
                    = 'multi_select_and_other') AS [multi_select_and_other]),
    [show_condition_type] AS (
        SELECT
            (SELECT
                [survey_question_show_condition_types].[survey_question_show_condition_type_id]
            FROM
                [survey_question_show_condition_types]
            WHERE
                [survey_question_show_condition_types].[survey_question_show_condition_type_name]
                    = 'has_answered') AS [has_answered],
            (SELECT
                [survey_question_show_condition_types].[survey_question_show_condition_type_id]
            FROM
                [survey_question_show_condition_types]
            WHERE
                [survey_question_show_condition_types].[survey_question_show_condition_type_name]
                    = 'has_not_answered') AS [has_not_answered])
SELECT
    [conditions].*,
    [survey_sessions].[survey_session_expiry],
    [survey_sessions].[survey_session_token],
    CASE
        WHEN (
            [conditions].[survey_question_show_condition_type]
                IN (
                    [show_condition_type].[has_answered],
                    [show_condition_type].[has_not_answered])
            AND [arg0s].[referenced_survey_page_index]
                IS NOT NULL
            AND [arg0s].[referenced_survey_page_index]
                = [conditions].[survey_page_index])
        THEN
            CAST(1 AS BIT)
        ELSE
            CAST(0 AS BIT)
    END
        AS [survey_question_show_condition_undecided],
    CASE
        WHEN (
            [conditions].[survey_question_show_condition_type]
                IN (
                    [show_condition_type].[has_answered],
                    [show_condition_type].[has_not_answered])
            AND [arg0s].[referenced_survey_question_answer_type]
                IS NOT NULL
            AND CASE
                WHEN (
                    (    -- (string? arg1) => (string? answer) =>
                         --     new Regex(arg1 ?? "^[^]").IsMatch(answer ?? "")
                        [arg0s].[referenced_survey_question_answer_type]
                            = [answer_type].[small_text]
                        AND REGEXP_LIKE(
                            COALESCE(
                                (SELECT
                                    [answer0s].[survey_session_answer_text]
                                FROM
                                    [survey_session_answers_view] AS [answer0s]
                                WHERE
                                    [answer0s].[survey_id]
                                        = [conditions].[survey_id]
                                    AND [answer0s].[survey_page_index]
                                        = [conditions].[survey_page_index]
                                    AND [answer0s].[survey_question_index]
                                        = [conditions].[survey_question_index]
                                    AND [answer0s].[survey_session_answer_index]
                                        = 0
                                    AND [answer0s].[survey_session_token]
                                        = [survey_sessions].[survey_session_token]),
                                ''),
                            COALESCE(CAST([arg1s].[survey_question_show_condition_arg_text] AS VARCHAR(8000)), '^[^]')))
                    OR ( -- () => (object? answer) =>
                         --     answer is not null
                        [arg0s].[referenced_survey_question_answer_type]
                            = [answer_type].[checkbox]
                        AND [arg1s].[survey_question_show_condition_index]
                            IS NOT NULL)
                    OR ( -- (int? arg1) => (int answer) =>
                         --     arg1 is null || answer == arg1.Value
                        [arg0s].[referenced_survey_question_answer_type]
                            = [answer_type].[radio]
                        AND (
                            (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND [answers].[survey_session_answer_integer]
                                            IS NOT NULL))
                            OR (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NOT NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND [answers].[survey_session_answer_integer]
                                            IS NOT NULL
                                        AND [answers].[survey_session_answer_integer]
                                            = [arg1s].[survey_question_show_condition_arg_integer]))))
                    OR ( -- (object? arg1) => (object? answer) =>
                         --     (arg1 is null && answer is not null) ||
                         --     (arg1 is int x && answer == x) ||
                         --     (arg1 is string x && new Regex(arg1 ?? "^[^]").IsMatch(answer as string? ?? ""))
                        [arg0s].[referenced_survey_question_answer_type]
                            = [answer_type].[radio_or_other]
                        AND (
                            (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NULL
                                AND [arg1s].[survey_question_show_condition_arg_text]
                                    IS NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND (
                                            [answers].[survey_session_answer_integer]
                                                IS NOT NULL
                                            OR [answers].[survey_session_answer_text]
                                                IS NOT NULL)))
                            OR (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NOT NULL
                                AND [arg1s].[survey_question_show_condition_arg_text]
                                    IS NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND [answers].[survey_session_answer_integer]
                                            IS NOT NULL
                                        AND [answers].[survey_session_answer_integer]
                                            = [arg1s].[survey_question_show_condition_arg_integer]))
                            OR (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NULL
                                AND [arg1s].[survey_question_show_condition_arg_text]
                                    IS NOT NULL
                                AND REGEXP_LIKE(
                                    COALESCE(
                                        (SELECT
                                            [answer0s].[survey_session_answer_text]
                                        FROM
                                            [survey_session_answers_view] AS [answer0s]
                                        WHERE
                                            [answer0s].[survey_id]
                                                = [conditions].[survey_id]
                                            AND [answer0s].[survey_page_index]
                                                = [conditions].[survey_page_index]
                                            AND [answer0s].[survey_question_index]
                                                = [conditions].[survey_question_index]
                                            AND [answer0s].[survey_session_answer_index]
                                                = 0
                                            AND [answer0s].[survey_session_token]
                                                = [survey_sessions].[survey_session_token]),
                                        ''),
                                    CAST([arg1s].[survey_question_show_condition_arg_text] AS VARCHAR(8000))))))
                    OR ( -- (int? arg1) => (params object?[] answers) =>
                         --     arg1 is null
                         --         ? answers.Where((_, i) => i < options.Count).Any((x) => x is not null)
                         --         : answers[arg1.Value] is not null
                        [arg0s].[referenced_survey_question_answer_type]
                            = [answer_type].[multi_select]
                        AND (
                            (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND [answers].[survey_session_answer_integer]
                                            IS NOT NULL
                                        AND EXISTS(
                                            SELECT NULL FROM
                                                [survey_question_answer_options] AS [options]
                                            WHERE
                                                [options].[survey_id]
                                                    = [conditions].[survey_id]
                                                AND [options].[survey_page_index]
                                                    = [arg0s].[referenced_survey_page_index]
                                                AND [options].[survey_question_index]
                                                    = [arg0s].[referenced_survey_question_index]
                                                AND [options].[survey_answer_option_index]
                                                    = [answers].[survey_session_answer_integer])))
                            OR (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NOT NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND [answers].[survey_session_answer_integer]
                                            IS NOT NULL
                                        AND [answers].[survey_session_answer_integer]
                                            = [arg1s].[survey_question_show_condition_arg_integer]
                                        AND EXISTS(
                                            SELECT NULL FROM
                                                [survey_question_answer_options] AS [options]
                                            WHERE
                                                [options].[survey_id]
                                                    = [conditions].[survey_id]
                                                AND [options].[survey_page_index]
                                                    = [arg0s].[referenced_survey_page_index]
                                                AND [options].[survey_question_index]
                                                    = [arg0s].[referenced_survey_question_index]
                                                AND [options].[survey_answer_option_index]
                                                    = [answers].[survey_session_answer_integer])))))
                    OR ( -- (object? arg1) => (params object?[] answers) =>
                         --     (arg1 is null && answers.Where((_, i) => i < options.Count).Any((x) => x is not null)) ||
                         --     (arg1 is int x && answers[arg1 + 1] is not null) ||
                         --     (arg1 is string x && new Regex(arg1 ?? "^[^]").IsMatch(answers[0] as string? ?? ""))
                        [arg0s].[referenced_survey_question_answer_type]
                            = [answer_type].[multi_select_and_other]
                        AND (
                            (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NULL
                                AND [arg1s].[survey_question_show_condition_arg_text]
                                    IS NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND [answers].[survey_session_answer_integer]
                                            IS NOT NULL
                                        AND EXISTS(
                                            SELECT NULL FROM
                                                [survey_question_answer_options] AS [options]
                                            WHERE
                                                [options].[survey_id]
                                                    = [conditions].[survey_id]
                                                AND [options].[survey_page_index]
                                                    = [arg0s].[referenced_survey_page_index]
                                                AND [options].[survey_question_index]
                                                    = [arg0s].[referenced_survey_question_index]
                                                AND [options].[survey_answer_option_index]
                                                    = [answers].[survey_session_answer_integer])))
                            OR (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NOT NULL
                                AND [arg1s].[survey_question_show_condition_arg_text]
                                    IS NULL
                                AND EXISTS(
                                    SELECT NULL FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [arg0s].[referenced_survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [arg0s].[referenced_survey_question_index]
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]
                                        AND [answers].[survey_session_answer_index]
                                            IS NOT NULL
                                        AND [answers].[survey_session_answer_index]
                                            = [arg1s].[survey_question_show_condition_arg_integer] + 1
                                        AND EXISTS(
                                            SELECT NULL FROM
                                                [survey_question_answer_options] AS [options]
                                            WHERE
                                                [options].[survey_id]
                                                    = [conditions].[survey_id]
                                                AND [options].[survey_page_index]
                                                    = [arg0s].[referenced_survey_page_index]
                                                AND [options].[survey_question_index]
                                                    = [arg0s].[referenced_survey_question_index]
                                                AND [options].[survey_answer_option_index]
                                                    = [answers].[survey_session_answer_index])))
                            OR (
                                [arg1s].[survey_question_show_condition_arg_integer]
                                    IS NULL
                                AND [arg1s].[survey_question_show_condition_arg_text]
                                    IS NOT NULL
                                AND REGEXP_LIKE(
                                    COALESCE(
                                        (SELECT
                                            [answer0s].[survey_session_answer_text]
                                        FROM
                                            [survey_session_answers_view] AS [answer0s]
                                        WHERE
                                            [answer0s].[survey_id]
                                                = [conditions].[survey_id]
                                            AND [answer0s].[survey_page_index]
                                                = [conditions].[survey_page_index]
                                            AND [answer0s].[survey_question_index]
                                                = [conditions].[survey_question_index]
                                            AND [answer0s].[survey_session_answer_index]
                                                = 0
                                            AND [answer0s].[survey_session_token]
                                                = [survey_sessions].[survey_session_token]),
                                        ''),
                                    CAST([arg1s].[survey_question_show_condition_arg_text] AS VARCHAR(8000)))))))
                THEN
                    CAST(1 AS BIT)
                ELSE
                    CAST(0 AS BIT)
            END = CASE -- ((Result of 'has_answered') == (Type is 'has_answered'))
                WHEN   --     == (Result of 'has_answered' or 'has_not_answered')
                    [conditions].[survey_question_show_condition_type]
                        = [show_condition_type].[has_answered]
                THEN
                    CAST(1 AS BIT)
                ELSE
                    CAST(0 AS BIT)
            END)
        THEN
            CAST(1 AS BIT)
        ELSE
            CAST(0 AS BIT)
    END
        AS [survey_question_show_condition_passed]
FROM
    [survey_question_show_conditions] AS [conditions]
LEFT JOIN
    [survey_question_show_condition_args_view] AS [arg0s]
    ON [arg0s].[survey_id]
        = [conditions].[survey_id]
    AND [arg0s].[survey_page_index]
        = [conditions].[survey_page_index]
    AND [arg0s].[survey_question_index]
        = [conditions].[survey_question_index]
    AND [arg0s].[survey_question_show_condition_index]
        = [conditions].[survey_question_show_condition_index]
    AND [arg0s].[survey_question_show_condition_arg_index]
        = 0
LEFT JOIN
    [survey_question_show_condition_args_view] AS [arg1s]
    ON [arg1s].[survey_id]
        = [conditions].[survey_id]
    AND [arg1s].[survey_page_index]
        = [conditions].[survey_page_index]
    AND [arg1s].[survey_question_index]
        = [conditions].[survey_question_index]
    AND [arg1s].[survey_question_show_condition_index]
        = [conditions].[survey_question_show_condition_index]
    AND [arg1s].[survey_question_show_condition_arg_index]
        = 1
INNER JOIN
    [survey_sessions]
    ON [survey_sessions].[survey_id]
        = [conditions].[survey_id]
INNER JOIN
    [answer_type]
    ON [answer_type].[small_text]
        IS NOT NULL
    AND [answer_type].[checkbox]
        IS NOT NULL
    AND [answer_type].[radio]
        IS NOT NULL
    AND [answer_type].[radio_or_other]
        IS NOT NULL
    AND [answer_type].[multi_select]
        IS NOT NULL
    AND [answer_type].[multi_select_and_other]
        IS NOT NULL
INNER JOIN
    [show_condition_type]
    ON [show_condition_type].[has_answered]
        IS NOT NULL
    AND [show_condition_type].[has_not_answered]
        IS NOT NULL
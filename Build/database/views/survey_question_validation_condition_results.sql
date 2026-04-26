
CREATE OR ALTER VIEW [survey_question_validation_condition_results] AS
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
    [validation_condition_type] AS (
        SELECT
            (SELECT
                [survey_question_validation_condition_types].[survey_question_validation_condition_type_id]
            FROM
                [survey_question_validation_condition_types]
            WHERE
                [survey_question_validation_condition_types].[survey_question_validation_condition_type_name]
                    = 'min') AS [min],
            (SELECT
                [survey_question_validation_condition_types].[survey_question_validation_condition_type_id]
            FROM
                [survey_question_validation_condition_types]
            WHERE
                [survey_question_validation_condition_types].[survey_question_validation_condition_type_name]
                    = 'max') AS [max])
SELECT
    [conditions].*,
    [survey_sessions].[survey_session_expiry],
    [survey_sessions].[survey_session_token],
    CASE
        WHEN (
            [conditions].[survey_question_validation_condition_type]
                = [validation_condition_type].[min]
            AND (
                (    -- (int arg1) => (string? answer) =>
                     --     (answer ?? "").Length >= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[small_text]
                    AND [arg1s].[survey_question_validation_condition_arg_integer]
                        IS NOT NULL
                    AND LEN(
                        COALESCE(
                            (SELECT
                                [answers].[survey_session_answer_text]
                            FROM
                                [survey_session_answers_view] AS [answers]
                            WHERE
                                [answers].[survey_id]
                                    = [conditions].[survey_id]
                                AND [answers].[survey_page_index]
                                    = [conditions].[survey_page_index]
                                AND [answers].[survey_question_index]
                                    = [conditions].[survey_question_index]
                                AND [answers].[survey_session_answer_index]
                                    = 0
                                AND [answers].[survey_session_token]
                                    = [survey_sessions].[survey_session_token]),
                            ''))
                        >= [arg1s].[survey_question_validation_condition_arg_integer])
                OR ( -- () => (object? answer) =>
                     --     answer != null
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[checkbox]
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
                                = [survey_sessions].[survey_session_token]))
                OR ( -- () => (int? answer) =>
                     --     answer != null && options.Select((_, i) => i).Contains(answer.Value)
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[radio]
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
                OR ( -- (int arg1, object? arg2) => (object? answer) =>
                     --     arg2 == null
                     --         ? answer is int x && options.Select((_, i) => i).Contains(x)
                     --         : (answers[0] as string? ?? "").Length >= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[radio_or_other]
                    AND (
                        (
                            [arg2s].[survey_question_validation_condition_arg_index]
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
                            [arg2s].[survey_question_validation_condition_arg_index]
                                IS NOT NULL
                            AND [arg1s].[survey_question_validation_condition_arg_integer]
                                IS NOT NULL
                            AND LEN(
                                COALESCE(
                                    (SELECT
                                        [answers].[survey_session_answer_text]
                                    FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [conditions].[survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [conditions].[survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]),
                                    ''))
                                >= [arg1s].[survey_question_validation_condition_arg_integer])))
                OR ( -- (int arg1) => (params object?[] answers) =>
                     --     answers.Count((x) => x != null) >= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[multi_select]
                    AND [arg1s].[survey_question_validation_condition_arg_integer]
                        IS NOT NULL
                    AND (
                        SELECT
                            COUNT(*)
                        FROM
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
                                        = [answers].[survey_session_answer_integer]))
                        >= [arg1s].[survey_question_validation_condition_arg_integer])
                OR ( -- (int arg1, object? arg2) => (params object?[] answers) =>
                     --     arg2 == null
                     --         ? answers.Count((x) => x != null) >= arg1
                     --         : (answers[0] as string? ?? "").Length >= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[multi_select]
                    AND (
                        (
                            [arg2s].[survey_question_validation_condition_arg_index]
                                IS NULL
                            AND [arg1s].[survey_question_validation_condition_arg_integer]
                                IS NOT NULL
                            AND (
                                SELECT
                                    COUNT(*)
                                FROM
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
                                                = [answers].[survey_session_answer_integer]))
                                >= [arg1s].[survey_question_validation_condition_arg_integer])
                        OR (
                            [arg2s].[survey_question_validation_condition_arg_index]
                                IS NOT NULL
                            AND [arg1s].[survey_question_validation_condition_arg_integer]
                                IS NOT NULL
                            AND LEN(
                                COALESCE(
                                    (SELECT
                                        [answers].[survey_session_answer_text]
                                    FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [conditions].[survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [conditions].[survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]),
                                    ''))
                                >= [arg1s].[survey_question_validation_condition_arg_integer])))))
        OR (
            [conditions].[survey_question_validation_condition_type]
                = [validation_condition_type].[min]
            AND (
                (    -- (int arg1) => (string? answer) =>
                     --     (answer ?? "").Length <= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[small_text]
                    AND [arg1s].[survey_question_validation_condition_arg_integer]
                        IS NOT NULL
                    AND LEN(
                        COALESCE(
                            (SELECT
                                [answers].[survey_session_answer_text]
                            FROM
                                [survey_session_answers_view] AS [answers]
                            WHERE
                                [answers].[survey_id]
                                    = [conditions].[survey_id]
                                AND [answers].[survey_page_index]
                                    = [conditions].[survey_page_index]
                                AND [answers].[survey_question_index]
                                    = [conditions].[survey_question_index]
                                AND [answers].[survey_session_answer_index]
                                    = 0
                                AND [answers].[survey_session_token]
                                    = [survey_sessions].[survey_session_token]),
                            ''))
                        <= [arg1s].[survey_question_validation_condition_arg_integer])
                OR ( -- () => (object? answer) =>
                     --     answer == null
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[checkbox]
                    AND NOT EXISTS(
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
                                = [survey_sessions].[survey_session_token]))
                OR ( -- () => (int? answer) =>
                     --     answer == null || !options.Select((_, i) => i).Contains(answer)
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[radio]
                    AND NOT EXISTS(
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
                            AND NOT EXISTS(
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
                OR ( -- (int arg1, object? arg2) => (object? answer) =>
                     --     arg2 == null
                     --         ? answer is not int x || !options.Select((_, i) => i).Contains(x)
                     --         : (answers[0] as string? ?? "").Length <= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[radio_or_other]
                    AND (
                        (
                            [arg2s].[survey_question_validation_condition_arg_index]
                                IS NULL
                            AND NOT EXISTS(
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
                            [arg2s].[survey_question_validation_condition_arg_index]
                                IS NOT NULL
                            AND [arg1s].[survey_question_validation_condition_arg_integer]
                                IS NOT NULL
                            AND LEN(
                                COALESCE(
                                    (SELECT
                                        [answers].[survey_session_answer_text]
                                    FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [conditions].[survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [conditions].[survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]),
                                    ''))
                                <= [arg1s].[survey_question_validation_condition_arg_integer])))
                OR ( -- (int arg1) => (params object?[] answers) =>
                     --     answers.Count((x) => x != null) <= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[multi_select]
                    AND [arg1s].[survey_question_validation_condition_arg_integer]
                        IS NOT NULL
                    AND (
                        SELECT
                            COUNT(*)
                        FROM
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
                                        = [answers].[survey_session_answer_integer]))
                        <= [arg1s].[survey_question_validation_condition_arg_integer])
                OR ( -- (int arg1, object? arg2) => (params object?[] answers) =>
                     --     arg2 == null
                     --         ? answers.Count((x) => x != null) <= arg1
                     --         : (answers[0] as string? ?? "").Length <= arg1
                    [arg0s].[referenced_survey_question_answer_type]
                        = [answer_type].[multi_select]
                    AND (
                        (
                            [arg2s].[survey_question_validation_condition_arg_index]
                                IS NULL
                            AND [arg1s].[survey_question_validation_condition_arg_integer]
                                IS NOT NULL
                            AND (
                                SELECT
                                    COUNT(*)
                                FROM
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
                                                = [answers].[survey_session_answer_integer]))
                                <= [arg1s].[survey_question_validation_condition_arg_integer])
                        OR (
                            [arg2s].[survey_question_validation_condition_arg_index]
                                IS NOT NULL
                            AND [arg1s].[survey_question_validation_condition_arg_integer]
                                IS NOT NULL
                            AND LEN(
                                COALESCE(
                                    (SELECT
                                        [answers].[survey_session_answer_text]
                                    FROM
                                        [survey_session_answers_view] AS [answers]
                                    WHERE
                                        [answers].[survey_id]
                                            = [conditions].[survey_id]
                                        AND [answers].[survey_page_index]
                                            = [conditions].[survey_page_index]
                                        AND [answers].[survey_question_index]
                                            = [conditions].[survey_question_index]
                                        AND [answers].[survey_session_answer_index]
                                            = 0
                                        AND [answers].[survey_session_token]
                                            = [survey_sessions].[survey_session_token]),
                                    ''))
                                <= [arg1s].[survey_question_validation_condition_arg_integer])))))
        THEN
            CAST(1 AS BIT)
        ELSE
            CAST(0 AS BIT)
    END
        AS [survey_question_validation_condition_passed]
FROM
    [survey_question_validation_conditions] AS [conditions]
LEFT JOIN
    [survey_question_validation_condition_args_view] AS [arg0s]
    ON [arg0s].[survey_id]
        = [conditions].[survey_id]
    AND [arg0s].[survey_page_index]
        = [conditions].[survey_page_index]
    AND [arg0s].[survey_question_index]
        = [conditions].[survey_question_index]
    AND [arg0s].[survey_question_validation_condition_index]
        = [conditions].[survey_question_validation_condition_index]
    AND [arg0s].[survey_question_validation_condition_arg_index]
        = 0
LEFT JOIN
    [survey_question_validation_condition_args_view] AS [arg1s]
    ON [arg1s].[survey_id]
        = [conditions].[survey_id]
    AND [arg1s].[survey_page_index]
        = [conditions].[survey_page_index]
    AND [arg1s].[survey_question_index]
        = [conditions].[survey_question_index]
    AND [arg1s].[survey_question_validation_condition_index]
        = [conditions].[survey_question_validation_condition_index]
    AND [arg1s].[survey_question_validation_condition_arg_index]
        = 1
LEFT JOIN
    [survey_question_validation_condition_args_view] AS [arg2s]
    ON [arg2s].[survey_id]
        = [conditions].[survey_id]
    AND [arg2s].[survey_page_index]
        = [conditions].[survey_page_index]
    AND [arg2s].[survey_question_index]
        = [conditions].[survey_question_index]
    AND [arg2s].[survey_question_validation_condition_index]
        = [conditions].[survey_question_validation_condition_index]
    AND [arg2s].[survey_question_validation_condition_arg_index]
        = 2
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
    [validation_condition_type]
    ON [validation_condition_type].[min]
        IS NOT NULL
    AND [validation_condition_type].[max]
        IS NOT NULL

CREATE OR ALTER VIEW [survey_visible_questions] AS
WITH
    [operator] AS (
        SELECT
            (SELECT
                [survey_question_condition_operator].[survey_question_condition_operator_id]
            FROM
                [survey_question_condition_operator]
            WHERE
                [survey_question_condition_operator].[survey_question_condition_operator_name]
                    = 'or') AS [or],
            (SELECT
                [survey_question_condition_operator].[survey_question_condition_operator_id]
            FROM
                [survey_question_condition_operator]
            WHERE
                [survey_question_condition_operator].[survey_question_condition_operator_name]
                    = 'and') AS [and])
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
                            [show_condition_results].[survey_question_show_condition_operator]
                                = [operator].[or]
                        THEN
                            1
                        ELSE
                            0
                    END)
                        OVER (ORDER BY [show_condition_results].[survey_question_index])
                        AS [condition_group_index],
                    CASE
                        WHEN
                            [show_condition_results].[survey_question_show_condition_undecided]
                                <> 0
                            OR [show_condition_results].[survey_question_show_condition_passed]
                                <> 0
                        THEN
                            CAST(1 AS BIT)
                        ELSE
                            CAST(0 AS BIT)
                    END AS [condition_passed]
                FROM
                    [survey_question_show_condition_results] AS [show_condition_results]
                WHERE
                    [show_condition_results].[survey_id]
                        = [survey_questions].[survey_id]
                    AND [show_condition_results].[survey_page_index]
                        = [survey_questions].[survey_page_index]
                    AND [show_condition_results].[survey_question_index]
                        = [survey_questions].[survey_question_index]
            )
                AS [conditions]
            GROUP BY
                [conditions].[condition_group_index]
            HAVING
                MIN(CAST([conditions].[condition_passed] AS TINYINT)) <> 0)
        THEN
            CAST(1 AS BIT)
        ELSE
            CAST(0 AS BIT)
    END AS [survey_question_is_visible]
FROM
    [survey_questions]
INNER JOIN
    [survey_sessions]
    ON [survey_sessions].[survey_id]
        = [survey_questions].[survey_id]
INNER JOIN
    [operator]
    ON [operator].[or] IS NOT NULL
    AND [operator].[and] IS NOT NULL

CREATE OR ALTER PROCEDURE [submit_survey_page_model] (
    @survey_id INT,
    @survey_page_index INT,
    @survey_session_token BINARY(32),
    @session_page_answers [submit_session_page_answers_table] READONLY) AS
BEGIN

    EXEC [delete_old_survey_sessions];

    IF NOT EXISTS(
        SELECT NULL FROM
            [survey_sessions]
        WHERE
            [survey_sessions].[survey_session_token]
                = @survey_session_token)
        RETURN;

    BEGIN TRANSACTION;

    DELETE FROM
        [survey_session_integer_answers]
    WHERE
        [survey_session_integer_answers].[survey_id]
            = @survey_id
        AND [survey_session_integer_answers].[survey_page_index]
            = @survey_page_index
        AND [survey_session_integer_answers].[survey_session_token]
            = @survey_session_token

    DELETE FROM
        [survey_session_text_answers]
    WHERE
        [survey_session_text_answers].[survey_id]
            = @survey_id
        AND [survey_session_text_answers].[survey_page_index]
            = @survey_page_index
        AND [survey_session_text_answers].[survey_session_token]
            = @survey_session_token

    DELETE FROM
        [survey_session_answers]
    WHERE
        [survey_session_answers].[survey_id]
            = @survey_id
        AND [survey_session_answers].[survey_page_index]
            = @survey_page_index
        AND [survey_session_answers].[survey_session_token]
            = @survey_session_token

    INSERT INTO
        [survey_session_answers] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_session_token],
            [survey_session_answer_index])
    SELECT
        @survey_id,
        @survey_page_index,
        [answers].[survey_question_index],
        @survey_session_token,
        [answers].[submission_answer_index]
    FROM
        @session_page_answers AS [answers]

    INSERT INTO
        [survey_session_integer_answers] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_session_token],
            [survey_session_answer_index],
            [survey_session_answer_integer])
    SELECT
        @survey_id,
        @survey_page_index,
        [answers].[survey_question_index],
        @survey_session_token,
        [answers].[submission_answer_index],
        [answers].[submission_answer_integer]
    FROM
        @session_page_answers AS [answers]
    WHERE
        [answers].[submission_answer_integer]
            IS NOT NULL

    INSERT INTO
        [survey_session_text_answers] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_session_token],
            [survey_session_answer_index],
            [survey_session_answer_text])
    SELECT
        @survey_id,
        @survey_page_index,
        [answers].[survey_question_index],
        @survey_session_token,
        [answers].[submission_answer_index],
        [answers].[submission_answer_text]
    FROM
        @session_page_answers AS [answers]
    WHERE
        [answers].[submission_answer_text]
            IS NOT NULL

    SELECT
        [validation_condition_results].[survey_question_index],
        [validation_condition_results].[survey_question_validation_condition_index]
    FROM
        [survey_visible_questions] AS [visible_questions]
    INNER JOIN
        [survey_question_validation_condition_results] AS [validation_condition_results]
        ON [validation_condition_results].[survey_id]
            = @survey_id
        AND [validation_condition_results].[survey_page_index]
            = @survey_page_index
        AND [validation_condition_results].[survey_session_token]
            = @survey_session_token
        AND [validation_condition_results].[survey_question_index]
            = [visible_questions].[survey_question_index]
    WHERE
        [validation_condition_results].[survey_id]
            = @survey_id
        AND [validation_condition_results].[survey_page_index]
            = @survey_page_index
        AND [validation_condition_results].[survey_session_token]
            = @survey_session_token
        AND [visible_questions].[survey_question_is_visible]
            = 1
        AND [validation_condition_results].[survey_question_validation_condition_passed]
            = 0

    IF @@ROWCOUNT > 0
        ROLLBACK TRANSACTION;
    ELSE
        COMMIT TRANSACTION;
END
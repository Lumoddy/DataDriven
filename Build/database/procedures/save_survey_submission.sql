
CREATE OR ALTER PROCEDURE [save_survey_submission] (
    @survey_id INT,
    @survey_session_token BINARY(32)) AS
BEGIN

    EXEC [delete_old_survey_sessions];

    IF NOT EXISTS(
        SELECT NULL FROM
            [survey_sessions]
        WHERE
            [survey_sessions].[survey_session_token]
                = @survey_session_token)
    BEGIN
        SELECT NULL;
        RETURN;
    END

    BEGIN TRANSACTION;

    DECLARE @submission_index INT = (
        SELECT
            COALESCE(MAX([submissions].[submission_index]) + 1, 0)
        FROM
            [submissions]);

    INSERT INTO [submissions] (
        [submissions].[survey_id],
        [submissions].[submission_index],
        [submissions].[registered_member_id])
    VALUES
        (@survey_id, @submission_index, NULL);

    INSERT INTO [submission_answers] (
        [submission_answers].[survey_id],
        [submission_answers].[submission_index],
        [submission_answers].[survey_page_index],
        [submission_answers].[survey_question_index],
        [submission_answers].[submission_answer_index])
    SELECT
        @survey_id,
        @submission_index,
        [survey_session_answers].[survey_page_index],
        [survey_session_answers].[survey_question_index],
        [survey_session_answers].[survey_session_answer_index]
    FROM
        [survey_session_answers];

    INSERT INTO [submission_integer_answers] (
        [submission_integer_answers].[survey_id],
        [submission_integer_answers].[submission_index],
        [submission_integer_answers].[survey_page_index],
        [submission_integer_answers].[survey_question_index],
        [submission_integer_answers].[submission_answer_index],
        [submission_integer_answers].[submission_answer_integer])
    SELECT
        @survey_id,
        @submission_index,
        [survey_session_integer_answers].[survey_page_index],
        [survey_session_integer_answers].[survey_question_index],
        [survey_session_integer_answers].[survey_session_answer_index],
        [survey_session_integer_answers].[survey_session_answer_integer]
    FROM
        [survey_session_integer_answers];

    INSERT INTO [submission_text_answers] (
        [submission_text_answers].[survey_id],
        [submission_text_answers].[submission_index],
        [submission_text_answers].[survey_page_index],
        [submission_text_answers].[survey_question_index],
        [submission_text_answers].[submission_answer_index],
        [submission_text_answers].[submission_answer_text])
    SELECT
        @survey_id,
        @submission_index,
        [survey_session_text_answers].[survey_page_index],
        [survey_session_text_answers].[survey_question_index],
        [survey_session_text_answers].[survey_session_answer_index],
        [survey_session_text_answers].[survey_session_answer_text]
    FROM
        [survey_session_text_answers];

    DELETE FROM
        [survey_session_integer_answers]
    WHERE
        [survey_session_integer_answers].[survey_session_token]
            = @survey_session_token;

    DELETE FROM
        [survey_session_text_answers]
    WHERE
        [survey_session_text_answers].[survey_session_token]
            = @survey_session_token;

    DELETE FROM
        [survey_session_answers]
    WHERE
        [survey_session_answers].[survey_session_token]
            = @survey_session_token;

    DELETE FROM
        [survey_sessions]
    WHERE
        [survey_sessions].[survey_session_token]
            = @survey_session_token;

    SELECT @submission_index;

    COMMIT TRANSACTION;
END
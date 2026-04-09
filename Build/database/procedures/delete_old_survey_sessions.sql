
CREATE OR ALTER PROCEDURE [delete_old_survey_sessions] AS
BEGIN

    SELECT
        [survey_sessions].[survey_session_token]
    INTO
        [#old_survey_sessions]
    FROM
        [survey_sessions]
    WHERE
        [survey_sessions].[survey_session_expiry]
            <= GETUTCDATE();

    DELETE FROM
        [survey_session_integer_answers]
    WHERE
        EXISTS(
            SELECT NULL FROM
                [#old_survey_sessions]
            WHERE
                [#old_survey_sessions].[survey_session_token]
                    = [survey_session_integer_answers].[survey_session_token]);

    DELETE FROM
        [survey_session_text_answers]
    WHERE
        EXISTS(
            SELECT NULL FROM
                [#old_survey_sessions]
            WHERE
                [#old_survey_sessions].[survey_session_token]
                    = [survey_session_text_answers].[survey_session_token]);

    DELETE FROM
        [survey_session_answers]
    WHERE
        EXISTS(
            SELECT NULL FROM
                [#old_survey_sessions]
            WHERE
                [#old_survey_sessions].[survey_session_token]
                    = [survey_session_answers].[survey_session_token]);

    DELETE FROM
        [survey_sessions]
    WHERE
        EXISTS(
            SELECT NULL FROM
                [#old_survey_sessions]
            WHERE
                [#old_survey_sessions].[survey_session_token]
                    = [survey_sessions].[survey_session_token]);

END
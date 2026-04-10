
CREATE OR ALTER PROCEDURE [start_survey_session] (
    @survey_id INT) AS
BEGIN

    INSERT INTO [survey_sessions] (
        [survey_sessions].[survey_id])
    OUTPUT
        INSERTED.[survey_session_token]
    VALUES
        (@survey_id);

END
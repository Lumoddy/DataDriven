
CREATE OR ALTER PROCEDURE [start_survey_session] (
    @surveyId INT) AS
BEGIN

    INSERT INTO [survey_sessions] (
        [survey_sessions].[survey_id])
    OUTPUT
        INSERTED.[survey_session_token]
    VALUES
        (@surveyId);

END
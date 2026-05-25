
CREATE OR ALTER PROCEDURE [link_submission_to_member] (
    @survey_id INT,
    @submission_index INT,
    @registered_member_id INT) AS
BEGIN

    UPDATE [submissions]
    SET [registered_member_id] = @registered_member_id
    WHERE
        [submissions].[survey_id] = @survey_id
        AND [submissions].[submission_index] = @submission_index;

    SELECT @@ROWCOUNT;

END

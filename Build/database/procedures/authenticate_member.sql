
CREATE OR ALTER PROCEDURE [authenticate_member] (
    @phone_number VARCHAR(13)) AS
BEGIN

    -- Return member ID and password hash for the given phone number
    SELECT
        [registered_members].[registered_member_id],
        [registered_members].[registered_member_password_hash]
    FROM
        [registered_members]
    WHERE
        [registered_members].[registered_member_phone_number]
            = @phone_number;

END

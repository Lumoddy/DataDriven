
CREATE OR ALTER PROCEDURE [register_member] (
    @first_name NVARCHAR(255),
    @last_name NVARCHAR(255),
    @phone_number VARCHAR(13),
    @birth_date DATETIME,
    @password_hash VARCHAR(255)) AS
BEGIN

    -- Check if member with this phone number already exists
    IF EXISTS(
        SELECT NULL FROM
            [registered_members]
        WHERE
            [registered_members].[registered_member_phone_number]
                = @phone_number)
    BEGIN
        SELECT NULL;
        RETURN;
    END

    DECLARE @registered_member_id INT = (
        SELECT COALESCE(MAX([registered_members].[registered_member_id]) + 1, 0)
        FROM [registered_members]);

    INSERT INTO [registered_members] (
        [registered_members].[registered_member_id],
        [registered_members].[registered_member_first_name],
        [registered_members].[registered_member_last_name],
        [registered_members].[registered_member_phone_number],
        [registered_members].[registered_member_birth_date],
        [registered_members].[registered_member_password_hash])
    VALUES
        (@registered_member_id, @first_name, @last_name, @phone_number, @birth_date, @password_hash);

    SELECT @registered_member_id;

END

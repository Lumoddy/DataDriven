
CREATE OR ALTER PROCEDURE [query_survey] (
    @survey_id INT) AS
BEGIN

    SELECT
        [surveys].[survey_title],
        [surveys].[survey_author],
        [surveys].[survey_description],
        (SELECT
            COUNT(*)
        FROM
            [survey_pages]
        WHERE
            [survey_pages].[survey_id]
                = [surveys].[survey_id]) AS [survey_page_count]
    FROM
        [surveys]
    WHERE
        [surveys].[survey_id]
            = @survey_id;

END

CREATE OR ALTER VIEW [survey_session_answers_view] AS
SELECT
    [survey_session_answers].*,
    [survey_session_integer_answers].[survey_session_answer_integer],
    [survey_session_text_answers].[survey_session_answer_text]
FROM
    [survey_session_answers]
LEFT JOIN
    [survey_session_integer_answers]
    ON [survey_session_integer_answers].[survey_id]
        = [survey_session_answers].[survey_id]
    AND [survey_session_integer_answers].[survey_page_index]
        = [survey_session_answers].[survey_page_index]
    AND [survey_session_integer_answers].[survey_question_index]
        = [survey_session_answers].[survey_question_index]
    AND [survey_session_integer_answers].[survey_session_answer_index]
        = [survey_session_answers].[survey_session_answer_index]
    AND [survey_session_integer_answers].[survey_session_token]
        = [survey_session_answers].[survey_session_token]
LEFT JOIN
    [survey_session_text_answers]
    ON [survey_session_text_answers].[survey_id]
        = [survey_session_answers].[survey_id]
    AND [survey_session_text_answers].[survey_page_index]
        = [survey_session_answers].[survey_page_index]
    AND [survey_session_text_answers].[survey_question_index]
        = [survey_session_answers].[survey_question_index]
    AND [survey_session_text_answers].[survey_session_answer_index]
        = [survey_session_answers].[survey_session_answer_index]
    AND [survey_session_text_answers].[survey_session_token]
        = [survey_session_answers].[survey_session_token];
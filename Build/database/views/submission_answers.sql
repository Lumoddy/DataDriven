
CREATE OR ALTER VIEW [submission_answers_view] AS
SELECT
    [submission_answers].*,
    [submission_integer_answers].[submission_answer_integer],
    [submission_text_answers].[submission_answer_text]
FROM
    [submission_answers]
LEFT JOIN
    [submission_integer_answers]
    ON [submission_integer_answers].[survey_id]
        = [submission_answers].[survey_id]
    AND [submission_integer_answers].[survey_page_index]
        = [submission_answers].[survey_page_index]
    AND [submission_integer_answers].[survey_question_index]
        = [submission_answers].[survey_question_index]
    AND [submission_integer_answers].[submission_index]
        = [submission_answers].[submission_index]
    AND [submission_integer_answers].[submission_answer_index]
        = [submission_answers].[submission_answer_index]
LEFT JOIN
    [submission_text_answers]
    ON [submission_text_answers].[survey_id]
        = [submission_answers].[survey_id]
    AND [submission_text_answers].[survey_page_index]
        = [submission_answers].[survey_page_index]
    AND [submission_text_answers].[survey_question_index]
        = [submission_answers].[survey_question_index]
    AND [submission_text_answers].[submission_index]
        = [submission_answers].[submission_index]
    AND [submission_text_answers].[submission_answer_index]
        = [submission_answers].[submission_answer_index];

CREATE TYPE [submit_session_page_answers_table] AS TABLE (
    [survey_question_index] INT NOT NULL,
    [submission_answer_index] INT NOT NULL,
    [submission_answer_integer] INT NULL,
    [submission_answer_text] VARCHAR(MAX) NULL);
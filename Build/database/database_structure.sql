--- This file was auto-generated based on ./Build/database/database_structure.yaml

BEGIN TRANSACTION;

CREATE TABLE [survey_question_answer_types] (
    [survey_question_answer_type_id] TINYINT NOT NULL,
    [survey_question_answer_type_name] VARCHAR(255) NOT NULL);

CREATE TABLE [survey_question_condition_operator] (
    [survey_question_condition_operator_id] TINYINT NOT NULL,
    [survey_question_condition_operator_name] VARCHAR(255) NOT NULL);

CREATE TABLE [survey_question_show_condition_types] (
    [survey_question_show_condition_type_id] TINYINT NOT NULL,
    [survey_question_show_condition_type_name] VARCHAR(255) NOT NULL);

CREATE TABLE [survey_question_validation_condition_types] (
    [survey_question_validation_condition_type_id] TINYINT NOT NULL,
    [survey_question_validation_condition_type_name] VARCHAR(255) NOT NULL);

CREATE TABLE [survey_question_condition_passing] (
    [survey_question_condition_passing_id] TINYINT NOT NULL,
    [survey_question_condition_passing_name] VARCHAR(255) NOT NULL);

CREATE TABLE [surveys] (
    [survey_id] INT NOT NULL,
    [survey_title] VARCHAR(255) NOT NULL,
    [survey_author] VARCHAR(255) NOT NULL,
    [survey_description] VARCHAR(MAX) NOT NULL);

CREATE TABLE [survey_pages] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_page_title] VARCHAR(1023) NOT NULL,
    [survey_page_description] VARCHAR(MAX) NOT NULL);

CREATE TABLE [survey_questions] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_prompt] VARCHAR(1023) NOT NULL,
    [survey_question_answer_type] TINYINT NOT NULL);

CREATE TABLE [registered_members] (
    [registered_member_id] INT NOT NULL,
    [registered_member_password_hash] VARCHAR(255) NOT NULL,
    [registered_member_phone_number] VARCHAR(13) NOT NULL,
    [registered_member_birth_date] DATETIME NOT NULL,
    [registered_member_first_name] VARCHAR(255) NOT NULL,
    [registered_member_last_name] VARCHAR(255) NOT NULL);

CREATE TABLE [submissions] (
    [survey_id] INT NOT NULL,
    [submission_index] INT NOT NULL,
    [registered_member_id] INT NULL);

CREATE TABLE [submission_answers] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [submission_index] INT NOT NULL,
    [submission_answer_index] INT NOT NULL);

CREATE TABLE [submission_integer_answers] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [submission_index] INT NOT NULL,
    [submission_answer_index] INT NOT NULL,
    [submission_answer_integer] INT NOT NULL);

CREATE TABLE [submission_text_answers] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [submission_index] INT NOT NULL,
    [submission_answer_index] INT NOT NULL,
    [submission_answer_text] VARCHAR(MAX) NOT NULL);

CREATE TABLE [survey_question_answer_options] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_answer_option_index] INT NOT NULL,
    [survey_answer_option_text] VARCHAR(1023) NOT NULL);

CREATE TABLE [survey_question_show_conditions] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_show_condition_index] INT NOT NULL,
    [survey_question_show_condition_type] TINYINT NOT NULL,
    [survey_question_show_condition_operator] TINYINT NOT NULL);

CREATE TABLE [survey_question_show_conditions_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_show_condition_index] INT NOT NULL,
    [survey_question_show_condition_arg_index] INT NOT NULL);

CREATE TABLE [survey_question_show_conditions_ref_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_show_condition_index] INT NOT NULL,
    [survey_question_show_condition_arg_index] INT NOT NULL,
    [referenced_survey_page_index] INT NOT NULL,
    [referenced_survey_question_index] INT NOT NULL);

CREATE TABLE [survey_question_show_conditions_integer_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_show_condition_index] INT NOT NULL,
    [survey_question_show_condition_arg_index] INT NOT NULL,
    [survey_question_show_condition_arg_integer] INT NOT NULL);

CREATE TABLE [survey_question_show_conditions_text_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_show_condition_index] INT NOT NULL,
    [survey_question_show_condition_arg_index] INT NOT NULL,
    [survey_question_show_condition_arg_text] VARCHAR(MAX) NOT NULL);

CREATE TABLE [survey_question_validation_conditions] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_validation_condition_index] INT NOT NULL,
    [survey_question_validation_condition_type] TINYINT NOT NULL,
    [survey_question_validation_condition_operator] BIT NOT NULL);

CREATE TABLE [survey_question_validation_conditions_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_validation_condition_index] INT NOT NULL,
    [survey_question_validation_condition_arg_index] INT NOT NULL);

CREATE TABLE [survey_question_validation_conditions_ref_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_validation_condition_index] INT NOT NULL,
    [survey_question_validation_condition_arg_index] INT NOT NULL,
    [referenced_survey_page_index] INT NOT NULL,
    [referenced_survey_question_index] INT NOT NULL);

CREATE TABLE [survey_question_validation_conditions_integer_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_validation_condition_index] INT NOT NULL,
    [survey_question_validation_condition_arg_index] INT NOT NULL,
    [survey_question_validation_condition_arg_integer] INT NOT NULL);

CREATE TABLE [survey_question_validation_conditions_text_args] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_question_validation_condition_index] INT NOT NULL,
    [survey_question_validation_condition_arg_index] INT NOT NULL,
    [survey_question_validation_condition_arg_text] VARCHAR(MAX) NOT NULL);

CREATE TABLE [registered_member_sessions] (
    [registered_member_session_token] BINARY(32) NOT NULL CONSTRAINT [default_registered_member_sessions_1] DEFAULT CRYPT_GEN_RANDOM(32),
    [registered_member_session_expiry] DATETIME NOT NULL CONSTRAINT [default_registered_member_sessions_2] DEFAULT DATEADD(HOUR, 2, GETDATE()),
    [registered_member_id] INT NOT NULL);

CREATE TABLE [survey_sessions] (
    [survey_session_token] BINARY(32) NOT NULL CONSTRAINT [default_survey_sessions_1] DEFAULT CRYPT_GEN_RANDOM(32),
    [survey_session_expiry] DATETIME NOT NULL CONSTRAINT [default_survey_sessions_2] DEFAULT DATEADD(HOUR, 2, GETDATE()),
    [survey_id] INT NOT NULL);

CREATE TABLE [survey_session_answers] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_session_token] BINARY(32) NOT NULL,
    [survey_session_answer_index] INT NOT NULL);

CREATE TABLE [survey_session_integer_answers] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_session_token] BINARY(32) NOT NULL,
    [survey_session_answer_index] INT NOT NULL,
    [survey_session_answer_integer] INT NOT NULL);

CREATE TABLE [survey_session_text_answers] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_session_token] BINARY(32) NOT NULL,
    [survey_session_answer_index] INT NOT NULL,
    [survey_session_answer_text] VARCHAR(MAX) NOT NULL);

ALTER TABLE [survey_question_answer_types]
    ADD CONSTRAINT [unique_survey_question_answer_types_1] PRIMARY KEY (
        [survey_question_answer_type_id]);

ALTER TABLE [survey_question_condition_operator]
    ADD CONSTRAINT [unique_survey_question_condition_operator_1] PRIMARY KEY (
        [survey_question_condition_operator_id]);

ALTER TABLE [survey_question_show_condition_types]
    ADD CONSTRAINT [unique_survey_question_show_condition_types_1] PRIMARY KEY (
        [survey_question_show_condition_type_id]);

ALTER TABLE [survey_question_validation_condition_types]
    ADD CONSTRAINT [unique_survey_question_validation_condition_types_1] PRIMARY KEY (
        [survey_question_validation_condition_type_id]);

ALTER TABLE [survey_question_condition_passing]
    ADD CONSTRAINT [unique_survey_question_condition_passing_1] PRIMARY KEY (
        [survey_question_condition_passing_id]);

ALTER TABLE [surveys]
    ADD CONSTRAINT [unique_surveys_1] PRIMARY KEY (
        [survey_id]);

ALTER TABLE [survey_pages]
    ADD CONSTRAINT [unique_survey_pages_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index]);

ALTER TABLE [survey_questions]
    ADD CONSTRAINT [unique_survey_questions_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index]);

ALTER TABLE [registered_members]
    ADD CONSTRAINT [unique_registered_members_1] PRIMARY KEY (
        [registered_member_id]);

ALTER TABLE [submissions]
    ADD CONSTRAINT [unique_submissions_1] PRIMARY KEY (
        [survey_id],
        [submission_index]);

ALTER TABLE [submission_answers]
    ADD CONSTRAINT [unique_submission_answers_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [submission_index],
        [submission_answer_index]);

ALTER TABLE [submission_integer_answers]
    ADD CONSTRAINT [unique_submission_integer_answers_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [submission_index],
        [submission_answer_index]);

ALTER TABLE [submission_text_answers]
    ADD CONSTRAINT [unique_submission_text_answers_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [submission_index],
        [submission_answer_index]);

ALTER TABLE [survey_question_answer_options]
    ADD CONSTRAINT [unique_survey_question_answer_options_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_answer_option_index],
        [survey_question_index]);

ALTER TABLE [survey_question_show_conditions]
    ADD CONSTRAINT [unique_survey_question_show_conditions_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_show_condition_index]);

ALTER TABLE [survey_question_show_conditions_args]
    ADD CONSTRAINT [unique_survey_question_show_conditions_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_show_condition_index],
        [survey_question_show_condition_arg_index]);

ALTER TABLE [survey_question_show_conditions_ref_args]
    ADD CONSTRAINT [unique_survey_question_show_conditions_ref_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_show_condition_index],
        [survey_question_show_condition_arg_index]);

ALTER TABLE [survey_question_show_conditions_integer_args]
    ADD CONSTRAINT [unique_survey_question_show_conditions_integer_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_show_condition_index],
        [survey_question_show_condition_arg_index]);

ALTER TABLE [survey_question_show_conditions_text_args]
    ADD CONSTRAINT [unique_survey_question_show_conditions_text_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_show_condition_index],
        [survey_question_show_condition_arg_index]);

ALTER TABLE [survey_question_validation_conditions]
    ADD CONSTRAINT [unique_survey_question_validation_conditions_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_validation_condition_index]);

ALTER TABLE [survey_question_validation_conditions_args]
    ADD CONSTRAINT [unique_survey_question_validation_conditions_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_validation_condition_index],
        [survey_question_validation_condition_arg_index]);

ALTER TABLE [survey_question_validation_conditions_ref_args]
    ADD CONSTRAINT [unique_survey_question_validation_conditions_ref_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_validation_condition_index],
        [survey_question_validation_condition_arg_index]);

ALTER TABLE [survey_question_validation_conditions_integer_args]
    ADD CONSTRAINT [unique_survey_question_validation_conditions_integer_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_validation_condition_index],
        [survey_question_validation_condition_arg_index]);

ALTER TABLE [survey_question_validation_conditions_text_args]
    ADD CONSTRAINT [unique_survey_question_validation_conditions_text_args_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_question_validation_condition_index],
        [survey_question_validation_condition_arg_index]);

ALTER TABLE [registered_member_sessions]
    ADD CONSTRAINT [unique_registered_member_sessions_1] PRIMARY KEY (
        [registered_member_id],
        [registered_member_session_token]);

ALTER TABLE [survey_sessions]
    ADD CONSTRAINT [unique_survey_sessions_1] PRIMARY KEY (
        [survey_id],
        [survey_session_token]);

ALTER TABLE [survey_session_answers]
    ADD CONSTRAINT [unique_survey_session_answers_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_session_token],
        [survey_session_answer_index]);

ALTER TABLE [survey_session_integer_answers]
    ADD CONSTRAINT [unique_survey_session_integer_answers_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_session_token],
        [survey_session_answer_index]);

ALTER TABLE [survey_session_text_answers]
    ADD CONSTRAINT [unique_survey_session_text_answers_1] PRIMARY KEY (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_session_token],
        [survey_session_answer_index]);

ALTER TABLE [survey_pages]
    ADD CONSTRAINT [fk_survey_pages_to_surveys_1]
        FOREIGN KEY (
            [survey_id])
        REFERENCES [surveys] (
            [survey_id]);

ALTER TABLE [survey_questions]
    ADD CONSTRAINT [fk_survey_questions_to_survey_pages_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index])
        REFERENCES [survey_pages] (
            [survey_id],
            [survey_page_index]);

ALTER TABLE [survey_questions]
    ADD CONSTRAINT [fk_survey_questions_to_survey_question_answer_types_2]
        FOREIGN KEY (
            [survey_question_answer_type])
        REFERENCES [survey_question_answer_types] (
            [survey_question_answer_type_id]);

ALTER TABLE [submissions]
    ADD CONSTRAINT [fk_submissions_to_surveys_1]
        FOREIGN KEY (
            [survey_id])
        REFERENCES [surveys] (
            [survey_id]);

ALTER TABLE [submissions]
    ADD CONSTRAINT [fk_submissions_to_registered_members_2]
        FOREIGN KEY (
            [registered_member_id])
        REFERENCES [registered_members] (
            [registered_member_id]);

ALTER TABLE [submission_answers]
    ADD CONSTRAINT [fk_submission_answers_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [submission_answers]
    ADD CONSTRAINT [fk_submission_answers_to_submissions_2]
        FOREIGN KEY (
            [survey_id],
            [submission_index])
        REFERENCES [submissions] (
            [survey_id],
            [submission_index]);

ALTER TABLE [submission_integer_answers]
    ADD CONSTRAINT [fk_submission_integer_answers_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [submission_integer_answers]
    ADD CONSTRAINT [fk_submission_integer_answers_to_submission_answers_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [submission_index],
            [submission_answer_index])
        REFERENCES [submission_answers] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [submission_index],
            [submission_answer_index]);

ALTER TABLE [submission_text_answers]
    ADD CONSTRAINT [fk_submission_text_answers_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [submission_text_answers]
    ADD CONSTRAINT [fk_submission_text_answers_to_submission_answers_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [submission_index],
            [submission_answer_index])
        REFERENCES [submission_answers] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [submission_index],
            [submission_answer_index]);

ALTER TABLE [survey_question_answer_options]
    ADD CONSTRAINT [fk_survey_question_answer_options_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_show_conditions]
    ADD CONSTRAINT [fk_survey_question_show_conditions_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_show_conditions]
    ADD CONSTRAINT [fk_survey_question_show_conditions_to_survey_question_show_condition_types_2]
        FOREIGN KEY (
            [survey_question_show_condition_type])
        REFERENCES [survey_question_show_condition_types] (
            [survey_question_show_condition_type_id]);

ALTER TABLE [survey_question_show_conditions]
    ADD CONSTRAINT [fk_survey_question_show_conditions_to_survey_question_condition_operator_3]
        FOREIGN KEY (
            [survey_question_show_condition_operator])
        REFERENCES [survey_question_condition_operator] (
            [survey_question_condition_operator_id]);

ALTER TABLE [survey_question_show_conditions_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_args_to_survey_question_show_conditions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index])
        REFERENCES [survey_question_show_conditions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index]);

ALTER TABLE [survey_question_show_conditions_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_show_conditions_ref_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_ref_args_to_survey_question_show_conditions_args_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index],
            [survey_question_show_condition_arg_index])
        REFERENCES [survey_question_show_conditions_args] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index],
            [survey_question_show_condition_arg_index]);

ALTER TABLE [survey_question_show_conditions_ref_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_ref_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_show_conditions_ref_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_ref_args_to_survey_questions_3]
        FOREIGN KEY (
            [survey_id],
            [referenced_survey_page_index],
            [referenced_survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_show_conditions_integer_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_integer_args_to_survey_question_show_conditions_args_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index],
            [survey_question_show_condition_arg_index])
        REFERENCES [survey_question_show_conditions_args] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index],
            [survey_question_show_condition_arg_index]);

ALTER TABLE [survey_question_show_conditions_integer_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_integer_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_show_conditions_text_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_text_args_to_survey_question_show_conditions_args_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index],
            [survey_question_show_condition_arg_index])
        REFERENCES [survey_question_show_conditions_args] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_show_condition_index],
            [survey_question_show_condition_arg_index]);

ALTER TABLE [survey_question_show_conditions_text_args]
    ADD CONSTRAINT [fk_survey_question_show_conditions_text_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_validation_conditions]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_validation_conditions]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_to_survey_question_validation_condition_types_2]
        FOREIGN KEY (
            [survey_question_validation_condition_type])
        REFERENCES [survey_question_validation_condition_types] (
            [survey_question_validation_condition_type_id]);

ALTER TABLE [survey_question_validation_conditions_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_args_to_survey_question_validation_conditions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index])
        REFERENCES [survey_question_validation_conditions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index]);

ALTER TABLE [survey_question_validation_conditions_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_validation_conditions_ref_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_ref_args_to_survey_question_validation_conditions_args_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index],
            [survey_question_validation_condition_arg_index])
        REFERENCES [survey_question_validation_conditions_args] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index],
            [survey_question_validation_condition_arg_index]);

ALTER TABLE [survey_question_validation_conditions_ref_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_ref_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_validation_conditions_ref_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_ref_args_to_survey_questions_3]
        FOREIGN KEY (
            [survey_id],
            [referenced_survey_page_index],
            [referenced_survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_validation_conditions_integer_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_integer_args_to_survey_question_validation_conditions_args_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index],
            [survey_question_validation_condition_arg_index])
        REFERENCES [survey_question_validation_conditions_args] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index],
            [survey_question_validation_condition_arg_index]);

ALTER TABLE [survey_question_validation_conditions_integer_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_integer_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_validation_conditions_text_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_text_args_to_survey_question_validation_conditions_args_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index],
            [survey_question_validation_condition_arg_index])
        REFERENCES [survey_question_validation_conditions_args] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_question_validation_condition_index],
            [survey_question_validation_condition_arg_index]);

ALTER TABLE [survey_question_validation_conditions_text_args]
    ADD CONSTRAINT [fk_survey_question_validation_conditions_text_args_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [registered_member_sessions]
    ADD CONSTRAINT [fk_registered_member_sessions_to_registered_members_1]
        FOREIGN KEY (
            [registered_member_id])
        REFERENCES [registered_members] (
            [registered_member_id]);

ALTER TABLE [survey_sessions]
    ADD CONSTRAINT [fk_survey_sessions_to_surveys_1]
        FOREIGN KEY (
            [survey_id])
        REFERENCES [surveys] (
            [survey_id]);

ALTER TABLE [survey_session_answers]
    ADD CONSTRAINT [fk_survey_session_answers_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_session_answers]
    ADD CONSTRAINT [fk_survey_session_answers_to_survey_sessions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_session_token])
        REFERENCES [survey_sessions] (
            [survey_id],
            [survey_session_token]);

ALTER TABLE [survey_session_integer_answers]
    ADD CONSTRAINT [fk_survey_session_integer_answers_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_session_integer_answers]
    ADD CONSTRAINT [fk_survey_session_integer_answers_to_survey_session_answers_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_session_token],
            [survey_session_answer_index])
        REFERENCES [survey_session_answers] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_session_token],
            [survey_session_answer_index]);

ALTER TABLE [survey_session_text_answers]
    ADD CONSTRAINT [fk_survey_session_text_answers_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_session_text_answers]
    ADD CONSTRAINT [fk_survey_session_text_answers_to_survey_session_answers_2]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_session_token],
            [survey_session_answer_index])
        REFERENCES [survey_session_answers] (
            [survey_id],
            [survey_page_index],
            [survey_question_index],
            [survey_session_token],
            [survey_session_answer_index]);

INSERT INTO [survey_question_answer_types] ([survey_question_answer_type_id], [survey_question_answer_type_name]) VALUES
    (0, 'small_text'),
    (1, 'checkbox'),
    (2, 'radio'),
    (3, 'radio_or_other'),
    (4, 'multi_select'),
    (5, 'multi_select_and_other');

INSERT INTO [survey_question_condition_operator] ([survey_question_condition_operator_id], [survey_question_condition_operator_name]) VALUES
    (0, 'and'),
    (1, 'or');

INSERT INTO [survey_question_show_condition_types] ([survey_question_show_condition_type_id], [survey_question_show_condition_type_name]) VALUES
    (0, 'has_answered'),
    (1, 'has_not_answered');

INSERT INTO [survey_question_validation_condition_types] ([survey_question_validation_condition_type_id], [survey_question_validation_condition_type_name]) VALUES
    (0, 'min'),
    (1, 'max');

INSERT INTO [survey_question_condition_passing] ([survey_question_condition_passing_id], [survey_question_condition_passing_name]) VALUES
    (0, 'failed'),
    (1, 'passed'),
    (2, 'undecided');

COMMIT TRANSACTION;

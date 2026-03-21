--- This file was auto-generated based on ./Build/database/database_structure.yaml

CREATE TABLE [surveys] (
    [survey_id] INT NOT NULL,
    [name] VARCHAR(255) NOT NULL,
    [description] VARCHAR(MAX) NOT NULL);

CREATE TABLE [survey_pages] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [name] VARCHAR(1023) NOT NULL,
    [description] VARCHAR(MAX) NOT NULL);

CREATE TABLE [survey_questions] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [prompt] VARCHAR(1023) NOT NULL,
    [answer_type] TINYINT NOT NULL);

CREATE TABLE [survey_question_conditions] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [other_survey_page_index] INT NOT NULL,
    [other_survey_question_index] INT NOT NULL,
    [condition] VARCHAR(255) NOT NULL);

CREATE TABLE [survey_answers] (
    [survey_id] INT NOT NULL,
    [survey_page_index] INT NOT NULL,
    [survey_question_index] INT NOT NULL,
    [survey_submission_index] INT NOT NULL,
    [answer_value] VARCHAR(4095) NOT NULL);

CREATE TABLE [answer_types] (
    [answer_type_id] TINYINT NOT NULL,
    [name] VARCHAR(255) NOT NULL);

CREATE TABLE [registered_members] (
    [registered_member_id] INT NOT NULL,
    [phone_number] VARCHAR NOT NULL,
    [password_hash] VARCHAR(255) NOT NULL,
    [birth_date] DATETIME NOT NULL,
    [first_name] VARCHAR(255) NOT NULL,
    [last_name] VARCHAR(255) NOT NULL);

CREATE TABLE [survey_submissions] (
    [survey_id] INT NOT NULL,
    [survey_submission_index] INT NOT NULL,
    [registered_member_id] INT NULL);

ALTER TABLE [surveys]
    ADD CONSTRAINT [unique_surveys_1] PRIMARY KEY (
        [survey_id]);

ALTER TABLE [survey_pages]
    ADD CONSTRAINT [unique_survey_pages_1] UNIQUE (
        [survey_id],
        [survey_page_index]);

ALTER TABLE [survey_questions]
    ADD CONSTRAINT [unique_survey_questions_1] UNIQUE (
        [survey_id],
        [survey_page_index],
        [survey_question_index]);

ALTER TABLE [survey_question_conditions]
    ADD CONSTRAINT [unique_survey_question_conditions_1] UNIQUE (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [other_survey_page_index],
        [other_survey_question_index]);

ALTER TABLE [survey_answers]
    ADD CONSTRAINT [unique_survey_answers_1] UNIQUE (
        [survey_id],
        [survey_page_index],
        [survey_question_index],
        [survey_submission_index]);

ALTER TABLE [answer_types]
    ADD CONSTRAINT [unique_answer_types_1] PRIMARY KEY (
        [answer_type_id]);

ALTER TABLE [registered_members]
    ADD CONSTRAINT [unique_registered_members_1] UNIQUE (
        [registered_member_id]);

ALTER TABLE [survey_submissions]
    ADD CONSTRAINT [unique_survey_submissions_1] UNIQUE (
        [survey_id],
        [survey_submission_index]);

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

ALTER TABLE [survey_question_conditions]
    ADD CONSTRAINT [fk_survey_question_conditions_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_question_conditions]
    ADD CONSTRAINT [fk_survey_question_conditions_to_survey_questions_2]
        FOREIGN KEY (
            [survey_id],
            [other_survey_page_index],
            [other_survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_answers]
    ADD CONSTRAINT [fk_survey_answers_to_survey_questions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_page_index],
            [survey_question_index])
        REFERENCES [survey_questions] (
            [survey_id],
            [survey_page_index],
            [survey_question_index]);

ALTER TABLE [survey_answers]
    ADD CONSTRAINT [fk_survey_answers_to_survey_submissions_2]
        FOREIGN KEY (
            [survey_id],
            [survey_submission_index])
        REFERENCES [survey_submissions] (
            [survey_id],
            [survey_submission_index]);

ALTER TABLE [survey_submissions]
    ADD CONSTRAINT [fk_survey_submissions_to_survey_submissions_1]
        FOREIGN KEY (
            [survey_id],
            [survey_submission_index])
        REFERENCES [survey_submissions] (
            [survey_id],
            [survey_submission_index]);

ALTER TABLE [survey_submissions]
    ADD CONSTRAINT [fk_survey_submissions_to_registered_members_2]
        FOREIGN KEY (
            [registered_member_id])
        REFERENCES [registered_members] (
            [registered_member_id]);

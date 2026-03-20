--- This file was auto-generated based on ./Build/database/database_structure.yaml

CREATE TABLE surveys (
    survey_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(65534) NOT NULL);

CREATE TABLE survey_pages (
    survey_id INT NOT NULL,
    survey_page_index INT NOT NULL,
    name VARCHAR(1024) NOT NULL,
    description VARCHAR(65534) NOT NULL);

CREATE TABLE survey_questions (
    survey_id INT NOT NULL,
    survey_page_index INT NOT NULL,
    survey_question_index INT NOT NULL,
    prompt VARCHAR(1024) NOT NULL,
    answer_type TINYINT NOT NULL);

CREATE TABLE survey_question_conditions (
    survey_id INT NOT NULL,
    survey_page_index INT NOT NULL,
    survey_question_index INT NOT NULL,
    other_survey_page_index INT NOT NULL,
    other_survey_question_index INT NOT NULL,
    condition VARCHAR(255) NOT NULL);

CREATE TABLE survey_answers (
    survey_id INT NOT NULL,
    survey_page_index INT NOT NULL,
    survey_question_index INT NOT NULL,
    submission_index INT NOT NULL,
    value VARCHAR(4096) NOT NULL);

CREATE TABLE answer_types (
    answer_type TINYINT NOT NULL,
    name VARCHAR(255) NOT NULL);

CREATE TABLE registered_members (
    registered_member_id INT NOT NULL,
    phone_number VARCHAR(12) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    birth_date DATE NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL);

CREATE TABLE survey_submissions (
    survey_id INT NOT NULL,
    submission_index INT NOT NULL,
    registered_member_id INT NOT NULL);

ALTER TABLE surveys
    ADD CONSTRAINT unique_survey_id PRIMARY KEY (
        survey_id);

ALTER TABLE survey_pages
    ADD CONSTRAINT unique_survey_id_and_survey_page_index UNIQUE (
        survey_id,
        survey_page_index);

ALTER TABLE survey_questions
    ADD CONSTRAINT unique_survey_id_and_survey_page_index_and_survey_question_index UNIQUE (
        survey_id,
        survey_page_index,
        survey_question_index);

ALTER TABLE survey_question_conditions
    ADD CONSTRAINT unique_survey_id_and_survey_page_index_and_survey_question_index_and_other_survey_page_index_and_other_survey_question_index UNIQUE (
        survey_id,
        survey_page_index,
        survey_question_index,
        other_survey_page_index,
        other_survey_question_index);

ALTER TABLE survey_answers
    ADD CONSTRAINT unique_survey_id_and_survey_page_index_and_survey_question_index_and_submission_index UNIQUE (
        survey_id,
        survey_page_index,
        survey_question_index,
        submission_index);

ALTER TABLE answer_types
    ADD CONSTRAINT unique_answer_type PRIMARY KEY (
        answer_type);

ALTER TABLE registered_members
    ADD CONSTRAINT unique_registered_member_id UNIQUE (
        registered_member_id);

ALTER TABLE survey_submissions
    ADD CONSTRAINT unique_survey_id_and_submission_index_and_registered_member_id UNIQUE (
        survey_id,
        submission_index,
        registered_member_id);

ALTER TABLE survey_pages
    ADD CONSTRAINT survey_id_in_surveys
        FOREIGN KEY (
            survey_id)
        REFERENCES surveys (
            survey_id);

ALTER TABLE survey_questions
    ADD CONSTRAINT survey_id_and_survey_page_index_in_survey_pages
        FOREIGN KEY (
            survey_id,
            survey_page_index)
        REFERENCES survey_pages (
            survey_id,
            survey_page_index);

ALTER TABLE survey_question_conditions
    ADD CONSTRAINT survey_id_and_survey_page_index_and_survey_question_index_in_survey_questions
        FOREIGN KEY (
            survey_id,
            survey_page_index,
            survey_question_index)
        REFERENCES survey_questions (
            survey_id,
            survey_page_index,
            survey_question_index);

ALTER TABLE survey_question_conditions
    ADD CONSTRAINT survey_id_and_survey_page_index_and_survey_question_index_in_survey_questions
        FOREIGN KEY (
            survey_id,
            other_survey_page_index,
            other_survey_question_index)
        REFERENCES survey_questions (
            survey_id,
            survey_page_index,
            survey_question_index);

ALTER TABLE survey_answers
    ADD CONSTRAINT survey_id_and_survey_page_index_and_survey_question_index_in_survey_questions
        FOREIGN KEY (
            survey_id,
            survey_page_index,
            survey_question_index)
        REFERENCES survey_questions (
            survey_id,
            survey_page_index,
            survey_question_index);

ALTER TABLE survey_answers
    ADD CONSTRAINT survey_id_and_submission_index_in_submissions
        FOREIGN KEY (
            survey_id,
            submission_index)
        REFERENCES submissions (
            survey_id,
            submission_index);

ALTER TABLE survey_submissions
    ADD CONSTRAINT survey_id_and_submission_index_in_survey_submissions
        FOREIGN KEY (
            survey_id,
            submission_index)
        REFERENCES survey_submissions (
            survey_id,
            submission_index);

ALTER TABLE survey_submissions
    ADD CONSTRAINT registered_member_id_in_registered_members
        FOREIGN KEY (
            registered_member_id)
        REFERENCES registered_members (
            registered_member_id);

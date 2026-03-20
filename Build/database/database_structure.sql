--- This file was auto-generated based on ./Build/database/database_structure.yaml

START TRANSACTION;

CREATE TABLE surveys (
    survey_id INT UNSIGNED NOT NULL,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(4095) NOT NULL);

CREATE TABLE survey_pages (
    survey_id INT UNSIGNED NOT NULL,
    survey_page_index INT UNSIGNED NOT NULL,
    name VARCHAR(1023) NOT NULL,
    description VARCHAR(4095) NOT NULL);

CREATE TABLE survey_questions (
    survey_id INT UNSIGNED NOT NULL,
    survey_page_index INT UNSIGNED NOT NULL,
    survey_question_index INT UNSIGNED NOT NULL,
    question_text VARCHAR(4095) NOT NULL,
    answer_type TINYINT UNSIGNED NOT NULL);

CREATE TABLE survey_answer_types (
    index TINYINT UNSIGNED NOT NULL,
    name VARCHAR(255) NOT NULL);

CREATE TABLE survey_question_conditions (
    survey_id INT UNSIGNED NOT NULL,
    survey_page_index INT UNSIGNED NOT NULL,
    survey_question_index INT UNSIGNED NOT NULL,
    other_survey_page_index INT UNSIGNED NOT NULL,
    other_survey_question_index INT UNSIGNED NOT NULL,
    condition VARCHAR(1023) NOT NULL);

CREATE TABLE registered_members (
    registered_member_id INT UNSIGNED NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    birth_date DATE NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL);

CREATE TABLE survey_answers (
    survey_id INT UNSIGNED NOT NULL,
    survey_page_index INT UNSIGNED NOT NULL,
    survey_question_index INT UNSIGNED NOT NULL,
    submission_index INT UNSIGNED NOT NULL,
    condition VARCHAR(1023) NOT NULL);

ALTER TABLE surveys
    ADD PRIMARY KEY (survey_id);

ALTER TABLE survey_pages
    ADD UNIQUE KEY survey_id_and_survey_page_index (survey_id, survey_page_index),
    ADD KEY survey_id (survey_id);

ALTER TABLE survey_questions
    ADD UNIQUE KEY survey_id_and_survey_page_index_and_survey_question_index (survey_id, survey_page_index, survey_question_index),
    ADD KEY survey_id_and_survey_page_index (survey_id, survey_page_index);

ALTER TABLE survey_answer_types
    ADD PRIMARY KEY (index);

ALTER TABLE survey_question_conditions
    ADD UNIQUE KEY survey_id_and_survey_page_index_and_survey_question_index (survey_id, survey_page_index, survey_question_index),
    ADD KEY survey_id_and_survey_page_index_and_survey_question_index_and_other_survey_page_index_and_other_survey_question_index (survey_id, survey_page_index, survey_question_index, other_survey_page_index, other_survey_question_index);

ALTER TABLE registered_members
    ADD PRIMARY KEY (registered_member_id);

ALTER TABLE survey_answers
    ADD UNIQUE KEY survey_id_and_survey_page_index_and_survey_question_index (survey_id, survey_page_index, survey_question_index),
    ADD KEY survey_id_and_survey_page_index_and_survey_question_index (survey_id, survey_page_index, survey_question_index),
    ADD KEY submission_index (submission_index);

ALTER TABLE survey_pages
    ADD CONSTRAINT survey_id_to_survey_id_in_surveys FOREIGN KEY (survey_id) REFERENCES surveys (survey_id);

ALTER TABLE survey_questions
    ADD CONSTRAINT survey_id_and_survey_page_index_to_survey_id_and_survey_page_index_in_survey_pages FOREIGN KEY (survey_id, survey_page_index) REFERENCES survey_pages (survey_id, survey_page_index);

ALTER TABLE survey_question_conditions
    ADD CONSTRAINT survey_id_and_survey_page_index_and_survey_question_index_and_other_survey_page_index_and_other_survey_question_index_to_survey_id_and_survey_page_index_and_survey_question_index_and_survey_page_index_and_survey_question_index_in_survey_questions FOREIGN KEY (survey_id, survey_page_index, survey_question_index, other_survey_page_index, other_survey_question_index) REFERENCES survey_questions (survey_id, survey_page_index, survey_question_index, survey_page_index, survey_question_index);

ALTER TABLE survey_answers
    ADD CONSTRAINT survey_id_and_survey_page_index_and_survey_question_index_to_survey_id_and_survey_page_index_and_survey_question_index_in_survey_questions FOREIGN KEY (survey_id, survey_page_index, survey_question_index) REFERENCES survey_questions (survey_id, survey_page_index, survey_question_index),
    ADD CONSTRAINT submission_index_to_submission_index_in_survey_questions FOREIGN KEY (submission_index) REFERENCES survey_questions (submission_index);

COMMIT;
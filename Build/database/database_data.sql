
BEGIN TRANSACTION;

DECLARE @answer_type_small_text TINYINT;
DECLARE @answer_type_checkbox TINYINT;
DECLARE @answer_type_radio TINYINT;
DECLARE @answer_type_radio_or_other TINYINT;
DECLARE @answer_type_multi_select TINYINT;
DECLARE @answer_type_multi_select_and_other TINYINT;

EXEC [survey_question_answer_type_fields]
    @small_text = @answer_type_small_text OUTPUT,
    @checkbox = @answer_type_checkbox OUTPUT,
    @radio = @answer_type_radio OUTPUT,
    @radio_or_other = @answer_type_radio_or_other OUTPUT,
    @multi_select = @answer_type_multi_select OUTPUT,
    @multi_select_and_other = @answer_type_multi_select_and_other OUTPUT;

DECLARE @show_condition_has_answered TINYINT;
DECLARE @show_condition_has_not_answered TINYINT;

EXEC [survey_question_show_condition_type_fields]
    @has_answered = @show_condition_has_answered OUTPUT,
    @has_not_answered = @show_condition_has_not_answered OUTPUT;

DECLARE @validation_condition_min TINYINT;
DECLARE @validation_condition_max TINYINT;

EXEC [survey_question_validation_condition_type_fields]
    @min = @validation_condition_min OUTPUT,
    @max = @validation_condition_max OUTPUT;

DECLARE @operator_and TINYINT;
DECLARE @operator_or TINYINT;

EXEC [survey_question_condition_operator_fields]
    @and = @operator_and OUTPUT,
    @or = @operator_or OUTPUT;

INSERT INTO [surveys] ([survey_id], [survey_title], [survey_author], [survey_description]) VALUES
    (1, 'AITR Research Form', 'AIT Research', '');

INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES
    (1, 0, 'Demographics', '');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 0, 'What is your gender?', 3);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 0, 0, 0, 'Man'),
    (1, 0, 0, 1, 'Woman'),
    (1, 0, 0, 2, 'Non-Binary');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 1, 'What is your age range?', @answer_type_radio);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 0, 1, 0, '≤17'),
    (1, 0, 1, 1, '18 - 24'),
    (1, 0, 1, 2, '25 - 37'),
    (1, 0, 1, 3, '38 - 49'),
    (1, 0, 1, 4, '≥50');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 2, 'What is your state or territory in Australia?', @answer_type_small_text);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 3, 'What is your home suburb?', @answer_type_small_text);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 4, 'What is your home postcode?', @answer_type_small_text);

INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES
    (1, 1, 'Interests', '');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 0, 'Do you read newspaper?', @answer_type_checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 1, 'Which sections are you most interested in?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 1, 0, 'Property'),
    (1, 1, 1, 1, 'Sport'),
    (1, 1, 1, 2, 'Financial'),
    (1, 1, 1, 3, 'Entrainment'),
    (1, 1, 1, 4, 'Lifestyle'),
    (1, 1, 1, 5, 'Travel'),
    (1, 1, 1, 6, 'Politics');

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 1, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 1, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 1, 0, 0, 1, 0);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 1, 1, 0, @validation_condition_max, @operator_and);

INSERT INTO [survey_question_validation_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index]) VALUES
    (1, 1, 1, 0, 0);

INSERT INTO [survey_question_validation_condition_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 1, 1, 0, 0, 1);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 2, 'Are you interested in sports?', @answer_type_checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 3, 'What sports are you interested in?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 3, 0, 'AFL'),
    (1, 1, 3, 1, 'Football'),
    (1, 1, 3, 2, 'Cricket'),
    (1, 1, 3, 3, 'Racing'),
    (1, 1, 3, 4, 'Motorsport'),
    (1, 1, 3, 5, 'Basketball'),
    (1, 1, 3, 6, 'Tennis');

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 3, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 3, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 3, 0, 0, 1, 2);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 1, 3, 0, @validation_condition_min, @operator_and);

INSERT INTO [survey_question_validation_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index]) VALUES
    (1, 1, 3, 0, 0);

INSERT INTO [survey_question_validation_condition_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 1, 3, 0, 0, 0);

INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES
    (1, 2, 'Future', '');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 0, 'Do you want to travel?', @answer_type_checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 1, 'Where do you want to travel to?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 2, 1, 0, 'Australia'),
    (1, 2, 1, 1, 'Europe'),
    (1, 2, 1, 2, 'Pacific'),
    (1, 2, 1, 3, 'North America'),
    (1, 2, 1, 4, 'South America'),
    (1, 2, 1, 5, 'Asia'),
    (1, 2, 1, 6, 'Middle East'),
    (1, 2, 1, 7, 'Africa');

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 2, 1, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 2, 1, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 2, 1, 0, 0, 2, 0);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 2, 1, 0, @validation_condition_min, @operator_and);

INSERT INTO [survey_question_validation_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index]) VALUES
    (1, 2, 1, 0, 0);

INSERT INTO [survey_question_validation_condition_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 2, 1, 0, 0, 2);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 2, 'What banks do you use?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 2, 2, 0, 'Commonwealth Bank'),
    (1, 2, 2, 1, 'Wespac'),
    (1, 2, 2, 2, 'ANZ');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 3, 'Do you use internet banking?', @answer_type_checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 4, 'Do you use home loans?', @answer_type_checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 5, 'Do you use credit cards?', @answer_type_checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 6, 'Do you use share investments?', @answer_type_checkbox);

COMMIT TRANSACTION;

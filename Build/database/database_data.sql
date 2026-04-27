
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
    (1, N'AITR Research Form', N'AIT Research', N'');

INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES
    (1, 0, N'Demographics', N'');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 0, N'What is your gender?', 3);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 0, 0, 0, N'Man'),
    (1, 0, 0, 1, N'Woman'),
    (1, 0, 0, 2, N'Non-Binary');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 1, N'What is your age range?', @answer_type_radio);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 0, 1, 0, N'≤17'),
    (1, 0, 1, 1, N'18 - 24'),
    (1, 0, 1, 2, N'25 - 37'),
    (1, 0, 1, 3, N'38 - 49'),
    (1, 0, 1, 4, N'≥50');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 2, N'What is your state or territory in Australia?', @answer_type_small_text);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 3, N'What is your home suburb?', @answer_type_small_text);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 4, N'What is your home postcode?', @answer_type_small_text);

INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES
    (1, 1, N'Interests', 'N');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 0, N'Do you read newspaper?', @answer_type_checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 1, N'Which sections are you most interested in?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 1, 0, N'Property'),
    (1, 1, 1, 1, N'Sport'),
    (1, 1, 1, 2, N'Financial'),
    (1, 1, 1, 3, N'Entrainment'),
    (1, 1, 1, 4, N'Lifestyle'),
    (1, 1, 1, 5, N'Travel'),
    (1, 1, 1, 6, N'Politics');

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
    (1, 1, 1, 0, 0, 4);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 2, N'What sports are you interested in?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 2, 0, N'AFL'),
    (1, 1, 2, 1, N'Football'),
    (1, 1, 2, 2, N'Cricket'),
    (1, 1, 2, 3, N'Racing'),
    (1, 1, 2, 4, N'Motorsport'),
    (1, 1, 2, 5, N'Basketball'),
    (1, 1, 2, 6, N'Tennis');

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 2, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 2, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 2, 0, 0, 1, 1);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 2, 0, 1);

INSERT INTO [survey_question_show_condition_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [survey_question_show_condition_arg_integer]) VALUES
    (1, 1, 2, 0, 1, 1);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 1, 2, 0, @validation_condition_max, @operator_and);

INSERT INTO [survey_question_validation_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index]) VALUES
    (1, 1, 2, 0, 0);

INSERT INTO [survey_question_validation_condition_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 1, 2, 0, 0, 2);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 3, N'Where do you want to travel to?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 3, 0, N'Australia'),
    (1, 1, 3, 1, N'Europe'),
    (1, 1, 3, 2, N'Pacific'),
    (1, 1, 3, 3, N'North America'),
    (1, 1, 3, 4, N'South America'),
    (1, 1, 3, 5, N'Asia'),
    (1, 1, 3, 6, N'Middle East'),
    (1, 1, 3, 7, N'Africa');

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 3, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 3, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 3, 0, 0, 1, 1);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 3, 0, 1);

INSERT INTO [survey_question_show_condition_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [survey_question_show_condition_arg_integer]) VALUES
    (1, 1, 3, 0, 1, 5);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 1, 3, 0, @validation_condition_min, @operator_and);

INSERT INTO [survey_question_validation_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index]) VALUES
    (1, 1, 3, 0, 0);

INSERT INTO [survey_question_validation_condition_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 1, 3, 0, 0, 2);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 4, N'What banks do you use?', @answer_type_multi_select);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 4, 0, N'Commonwealth Bank'),
    (1, 1, 4, 1, N'Wespac'),
    (1, 1, 4, 2, N'ANZ');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 5, N'Do you use internet banking?', @answer_type_checkbox);

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 5, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 5, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 5, 0, 0, 1, 4);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 6, N'Do you use home loans?', @answer_type_checkbox);

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 6, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 6, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 6, 0, 0, 1, 4);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 7, N'Do you use credit cards?', @answer_type_checkbox);

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 7, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 7, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 7, 0, 0, 1, 4);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 8, N'Do you use share investments?', @answer_type_checkbox);

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 8, 0, @show_condition_has_answered, @operator_and);

INSERT INTO [survey_question_show_condition_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index]) VALUES
    (1, 1, 8, 0, 0);

INSERT INTO [survey_question_show_condition_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 8, 0, 0, 1, 4);

COMMIT TRANSACTION;


BEGIN TRANSACTION;

DECLARE @SmallText TINYINT = (SELECT [survey_question_answer_type_id]
FROM [survey_question_answer_types]
WHERE [survey_question_answer_type_name] = 'SmallText');

IF (@SmallText IS NULL)
    THROW 50000, 'SmallText answer type not found in answer_types table.', 1;

DECLARE @Checkbox TINYINT = (SELECT [survey_question_answer_type_id]
FROM [survey_question_answer_types]
WHERE [survey_question_answer_type_name] = 'Checkbox');

IF (@Checkbox IS NULL)
    THROW 50000, 'Checkbox answer type not found in answer_types table.', 1;

DECLARE @Radio TINYINT = (SELECT [survey_question_answer_type_id]
FROM [survey_question_answer_types]
WHERE [survey_question_answer_type_name] = 'Radio');

IF (@Radio IS NULL)
    THROW 50000, 'Radio answer type not found in answer_types table.', 1;

DECLARE @RadioAndOther TINYINT = (SELECT [survey_question_answer_type_id]
FROM [survey_question_answer_types]
WHERE [survey_question_answer_type_name] = 'RadioAndOther');

IF (@RadioAndOther IS NULL)
    THROW 50000, 'RadioAndOther answer type not found in answer_types table.', 1;

DECLARE @MultiSelect TINYINT = (SELECT [survey_question_answer_type_id]
FROM [survey_question_answer_types]
WHERE [survey_question_answer_type_name] = 'MultiSelect');

IF (@MultiSelect IS NULL)
    THROW 50000, 'MultiSelect answer type not found in answer_types table.', 1;

DECLARE @HasAnswered TINYINT = (SELECT [survey_question_show_condition_type_id]
FROM [survey_question_show_condition_types]
WHERE [survey_question_show_condition_type_name] = 'HasAnswered');

IF (@HasAnswered IS NULL)
    THROW 50000, 'HasAnswered show condition type not found in survey_question_show_condition_types table.', 1;

DECLARE @HasNotAnswered TINYINT = (SELECT [survey_question_show_condition_type_id]
FROM [survey_question_show_condition_types]
WHERE [survey_question_show_condition_type_name] = 'HasNotAnswered');

IF (@HasNotAnswered IS NULL)
    THROW 50000, 'HasNotAnswered show condition type not found in survey_question_show_condition_types table.', 1;

DECLARE @Min TINYINT = (SELECT [survey_question_validation_condition_type_id]
FROM [survey_question_validation_condition_types]
WHERE [survey_question_validation_condition_type_name] = 'Min');

IF (@Min IS NULL)
    THROW 50000, 'Min validation condition type not found in survey_question_validation_condition_types table.', 1;

DECLARE @Max TINYINT = (SELECT [survey_question_validation_condition_type_id]
FROM [survey_question_validation_condition_types]
WHERE [survey_question_validation_condition_type_name] = 'Max');

IF (@Max IS NULL)
    THROW 50000, 'Max validation condition type not found in survey_question_validation_condition_types table.', 1;

DECLARE @And BIT = 0;
DECLARE @Or BIT = 1;

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
    (1, 0, 1, 'What is your age range?', @Radio);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 0, 1, 0, '≤17'),
    (1, 0, 1, 1, '18 - 24'),
    (1, 0, 1, 2, '25 - 37'),
    (1, 0, 1, 3, '38 - 49'),
    (1, 0, 1, 4, '≥50');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 2, 'What is your state or territory in Australia?', @SmallText);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 3, 'What is your home suburb?', @SmallText);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 0, 4, 'What is your home postcode?', @SmallText);

INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES
    (1, 1, 'Interests', '');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 0, 'Do you read newspaper?', @Checkbox);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 1, 'Which sections are you most interested in?', @MultiSelect);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 1, 0, 'Property'),
    (1, 1, 1, 1, 'Sport'),
    (1, 1, 1, 2, 'Financial'),
    (1, 1, 1, 3, 'Entrainment'),
    (1, 1, 1, 4, 'Lifestyle'),
    (1, 1, 1, 5, 'Travel'),
    (1, 1, 1, 6, 'Politics');

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 1, 0, @HasAnswered, @And);

INSERT INTO [survey_question_show_conditions_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 1, 0, 0, 1, 0);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 1, 1, 0, @Max, @And);

INSERT INTO [survey_question_validation_conditions_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 1, 1, 0, 0, 1);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 2, 'Are you interested in sports?', 1);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 1, 3, 'What sports are you interested in?', 4);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 1, 3, 0, 'AFL'),
    (1, 1, 3, 1, 'Football'),
    (1, 1, 3, 2, 'Cricket'),
    (1, 1, 3, 3, 'Racing'),
    (1, 1, 3, 4, 'Motorsport'),
    (1, 1, 3, 5, 'Basketball'),
    (1, 1, 3, 6, 'Tennis');

INSERT INTO [survey_question_show_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_type], [survey_question_show_condition_operator]) VALUES
    (1, 1, 3, 0, @HasAnswered, @And);

INSERT INTO [survey_question_show_conditions_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 1, 3, 0, 0, 1, 0);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 1, 3, 0, @Min, @And);

INSERT INTO [survey_question_validation_conditions_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 1, 3, 0, 0, 0);

INSERT INTO [survey_pages] ([survey_id], [survey_page_index], [survey_page_title], [survey_page_description]) VALUES
    (1, 2, 'Future', '');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 0, 'Do you want to travel?', 1);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 1, 'Where do you want to travel to?', 4);

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
    (1, 2, 1, 0, @HasAnswered, @And);

INSERT INTO [survey_question_show_conditions_ref_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_show_condition_index], [survey_question_show_condition_arg_index], [referenced_survey_page_index], [referenced_survey_question_index]) VALUES
    (1, 2, 1, 0, 0, 1, 0);

INSERT INTO [survey_question_validation_conditions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_type], [survey_question_validation_condition_operator]) VALUES
    (1, 2, 1, 0, @Min, @And);

INSERT INTO [survey_question_validation_conditions_integer_args] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_validation_condition_index], [survey_question_validation_condition_arg_index], [survey_question_validation_condition_arg_integer]) VALUES
    (1, 2, 1, 0, 0, 2);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 2, 'What banks do you use?', 4);

INSERT INTO [survey_question_answer_options] ([survey_id], [survey_page_index], [survey_question_index], [survey_answer_option_index], [survey_answer_option_text]) VALUES
    (1, 2, 2, 0, 'Commonwealth Bank'),
    (1, 2, 2, 1, 'Wespac'),
    (1, 2, 2, 2, 'ANZ');

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 3, 'Do you use internet banking?', 1);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 4, 'Do you use home loans?', 1);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 5, 'Do you use credit cards?', 1);

INSERT INTO [survey_questions] ([survey_id], [survey_page_index], [survey_question_index], [survey_question_prompt], [survey_question_answer_type]) VALUES
    (1, 2, 6, 'Do you use share investments?', 1);

COMMIT TRANSACTION;

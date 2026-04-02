// This file was auto-generated based on ./Build/database/database_structure.yaml

using System.Collections;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using DataDriven.Data;

namespace DataDriven.Data;

public enum SurveyQuestionAnswerType
{
    SmallText,
    Checkbox,
    Radio,
    RadioAndOther,
    MultiSelect,
}

public enum SurveyQuestionShowConditionType
{
    HasAnswered,
    HasNotAnswered,
}

public enum SurveyQuestionValidationConditionType
{
    Min,
    Max,
}

public class SurveyQuestionAnswerTypeMap(
    byte smallTextIndex,
    byte checkboxIndex,
    byte radioIndex,
    byte radioAndOtherIndex,
    byte multiSelectIndex)
        : IReadOnlyDictionary<byte, SurveyQuestionAnswerType>,
        IReadOnlyDictionary<SurveyQuestionAnswerType, byte>
{
    public SurveyQuestionAnswerType this[byte key] => key switch
    {
        var x when x == smallTextIndex => SurveyQuestionAnswerType.SmallText,
        var x when x == checkboxIndex => SurveyQuestionAnswerType.Checkbox,
        var x when x == radioIndex => SurveyQuestionAnswerType.Radio,
        var x when x == radioAndOtherIndex => SurveyQuestionAnswerType.RadioAndOther,
        var x when x == multiSelectIndex => SurveyQuestionAnswerType.MultiSelect,
        var x => throw new KeyNotFoundException($"Key {x} not found in SurveyQuestionAnswerTypeMap.")
    };

    public byte this[SurveyQuestionAnswerType key] => key switch
    {
        SurveyQuestionAnswerType.SmallText => smallTextIndex,
        SurveyQuestionAnswerType.Checkbox => checkboxIndex,
        SurveyQuestionAnswerType.Radio => radioIndex,
        SurveyQuestionAnswerType.RadioAndOther => radioAndOtherIndex,
        SurveyQuestionAnswerType.MultiSelect => multiSelectIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to SurveyQuestionAnswerTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return smallTextIndex;
            yield return checkboxIndex;
            yield return radioIndex;
            yield return radioAndOtherIndex;
            yield return multiSelectIndex;
        }
    }

    public IEnumerable<SurveyQuestionAnswerType> Values => Enum.GetValues<SurveyQuestionAnswerType>();

    IEnumerable<SurveyQuestionAnswerType> IReadOnlyDictionary<SurveyQuestionAnswerType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<SurveyQuestionAnswerType, byte>.Values => Keys;

    public int Count => 5;

    public bool ContainsKey(byte key)
        => key == smallTextIndex ||
            key == checkboxIndex ||
            key == radioIndex ||
            key == radioAndOtherIndex ||
            key == multiSelectIndex;

    bool IReadOnlyDictionary<SurveyQuestionAnswerType, byte>.ContainsKey(SurveyQuestionAnswerType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, SurveyQuestionAnswerType>> GetEnumerator()
    {
        yield return new(smallTextIndex, SurveyQuestionAnswerType.SmallText);
        yield return new(checkboxIndex, SurveyQuestionAnswerType.Checkbox);
        yield return new(radioIndex, SurveyQuestionAnswerType.Radio);
        yield return new(radioAndOtherIndex, SurveyQuestionAnswerType.RadioAndOther);
        yield return new(multiSelectIndex, SurveyQuestionAnswerType.MultiSelect);
    }

    IEnumerator<KeyValuePair<SurveyQuestionAnswerType, byte>> IEnumerable<KeyValuePair<SurveyQuestionAnswerType, byte>>.GetEnumerator()
    {
        yield return new(SurveyQuestionAnswerType.SmallText, smallTextIndex);
        yield return new(SurveyQuestionAnswerType.Checkbox, checkboxIndex);
        yield return new(SurveyQuestionAnswerType.Radio, radioIndex);
        yield return new(SurveyQuestionAnswerType.RadioAndOther, radioAndOtherIndex);
        yield return new(SurveyQuestionAnswerType.MultiSelect, multiSelectIndex);
    }

    public bool TryGetValue(byte key, out SurveyQuestionAnswerType value)
    {
        if (ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    bool IReadOnlyDictionary<SurveyQuestionAnswerType, byte>.TryGetValue(SurveyQuestionAnswerType key, out byte value)
    {
        if (((IReadOnlyDictionary<SurveyQuestionAnswerType, byte>)this).ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class SurveyQuestionShowConditionTypeMap(
    byte hasAnsweredIndex,
    byte hasNotAnsweredIndex)
        : IReadOnlyDictionary<byte, SurveyQuestionShowConditionType>,
        IReadOnlyDictionary<SurveyQuestionShowConditionType, byte>
{
    public SurveyQuestionShowConditionType this[byte key] => key switch
    {
        var x when x == hasAnsweredIndex => SurveyQuestionShowConditionType.HasAnswered,
        var x when x == hasNotAnsweredIndex => SurveyQuestionShowConditionType.HasNotAnswered,
        var x => throw new KeyNotFoundException($"Key {x} not found in SurveyQuestionShowConditionTypeMap.")
    };

    public byte this[SurveyQuestionShowConditionType key] => key switch
    {
        SurveyQuestionShowConditionType.HasAnswered => hasAnsweredIndex,
        SurveyQuestionShowConditionType.HasNotAnswered => hasNotAnsweredIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to SurveyQuestionShowConditionTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return hasAnsweredIndex;
            yield return hasNotAnsweredIndex;
        }
    }

    public IEnumerable<SurveyQuestionShowConditionType> Values => Enum.GetValues<SurveyQuestionShowConditionType>();

    IEnumerable<SurveyQuestionShowConditionType> IReadOnlyDictionary<SurveyQuestionShowConditionType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<SurveyQuestionShowConditionType, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == hasAnsweredIndex ||
            key == hasNotAnsweredIndex;

    bool IReadOnlyDictionary<SurveyQuestionShowConditionType, byte>.ContainsKey(SurveyQuestionShowConditionType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, SurveyQuestionShowConditionType>> GetEnumerator()
    {
        yield return new(hasAnsweredIndex, SurveyQuestionShowConditionType.HasAnswered);
        yield return new(hasNotAnsweredIndex, SurveyQuestionShowConditionType.HasNotAnswered);
    }

    IEnumerator<KeyValuePair<SurveyQuestionShowConditionType, byte>> IEnumerable<KeyValuePair<SurveyQuestionShowConditionType, byte>>.GetEnumerator()
    {
        yield return new(SurveyQuestionShowConditionType.HasAnswered, hasAnsweredIndex);
        yield return new(SurveyQuestionShowConditionType.HasNotAnswered, hasNotAnsweredIndex);
    }

    public bool TryGetValue(byte key, out SurveyQuestionShowConditionType value)
    {
        if (ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    bool IReadOnlyDictionary<SurveyQuestionShowConditionType, byte>.TryGetValue(SurveyQuestionShowConditionType key, out byte value)
    {
        if (((IReadOnlyDictionary<SurveyQuestionShowConditionType, byte>)this).ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class SurveyQuestionValidationConditionTypeMap(
    byte minIndex,
    byte maxIndex)
        : IReadOnlyDictionary<byte, SurveyQuestionValidationConditionType>,
        IReadOnlyDictionary<SurveyQuestionValidationConditionType, byte>
{
    public SurveyQuestionValidationConditionType this[byte key] => key switch
    {
        var x when x == minIndex => SurveyQuestionValidationConditionType.Min,
        var x when x == maxIndex => SurveyQuestionValidationConditionType.Max,
        var x => throw new KeyNotFoundException($"Key {x} not found in SurveyQuestionValidationConditionTypeMap.")
    };

    public byte this[SurveyQuestionValidationConditionType key] => key switch
    {
        SurveyQuestionValidationConditionType.Min => minIndex,
        SurveyQuestionValidationConditionType.Max => maxIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to SurveyQuestionValidationConditionTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return minIndex;
            yield return maxIndex;
        }
    }

    public IEnumerable<SurveyQuestionValidationConditionType> Values => Enum.GetValues<SurveyQuestionValidationConditionType>();

    IEnumerable<SurveyQuestionValidationConditionType> IReadOnlyDictionary<SurveyQuestionValidationConditionType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<SurveyQuestionValidationConditionType, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == minIndex ||
            key == maxIndex;

    bool IReadOnlyDictionary<SurveyQuestionValidationConditionType, byte>.ContainsKey(SurveyQuestionValidationConditionType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, SurveyQuestionValidationConditionType>> GetEnumerator()
    {
        yield return new(minIndex, SurveyQuestionValidationConditionType.Min);
        yield return new(maxIndex, SurveyQuestionValidationConditionType.Max);
    }

    IEnumerator<KeyValuePair<SurveyQuestionValidationConditionType, byte>> IEnumerable<KeyValuePair<SurveyQuestionValidationConditionType, byte>>.GetEnumerator()
    {
        yield return new(SurveyQuestionValidationConditionType.Min, minIndex);
        yield return new(SurveyQuestionValidationConditionType.Max, maxIndex);
    }

    public bool TryGetValue(byte key, out SurveyQuestionValidationConditionType value)
    {
        if (ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    bool IReadOnlyDictionary<SurveyQuestionValidationConditionType, byte>.TryGetValue(SurveyQuestionValidationConditionType key, out byte value)
    {
        if (((IReadOnlyDictionary<SurveyQuestionValidationConditionType, byte>)this).ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public interface IDatabaseEnumService
{
    SurveyQuestionAnswerTypeMap SurveyQuestionAnswerTypeMap { get; }

    SurveyQuestionShowConditionTypeMap SurveyQuestionShowConditionTypeMap { get; }

    SurveyQuestionValidationConditionTypeMap SurveyQuestionValidationConditionTypeMap { get; }
}

public class DatabaseEnumService : IDatabaseEnumService
{
    private readonly SurveyQuestionAnswerTypeMap surveyQuestionAnswerTypeMap;

    private readonly SurveyQuestionShowConditionTypeMap surveyQuestionShowConditionTypeMap;

    private readonly SurveyQuestionValidationConditionTypeMap surveyQuestionValidationConditionTypeMap;

    public DatabaseEnumService(IConfiguration configuration)
    {
        using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        connection.Open();

        using SqlCommand command = new(
            $"""
            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'SmallText';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'Checkbox';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'Radio';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'RadioAndOther';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'MultiSelect';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_show_condition_type_id]
            FROM [survey_question_show_condition_types]
            WHERE [survey_question_show_condition_type_name] = 'HasAnswered';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_show_condition_type_id]
            FROM [survey_question_show_condition_types]
            WHERE [survey_question_show_condition_type_name] = 'HasNotAnswered';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_validation_condition_type_id]
            FROM [survey_question_validation_condition_types]
            WHERE [survey_question_validation_condition_type_name] = 'Min';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_validation_condition_type_id]
            FROM [survey_question_validation_condition_types]
            WHERE [survey_question_validation_condition_type_name] = 'Max';
            """,
            connection);

        using SqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'SmallText' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeSmallText = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'Checkbox' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeCheckbox = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'Radio' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeRadio = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'RadioAndOther' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeRadioAndOther = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'MultiSelect' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeMultiSelect = reader.GetSqlByte(0).StrictValue();

        surveyQuestionAnswerTypeMap = new(
            surveyQuestionAnswerTypeSmallText,
            surveyQuestionAnswerTypeCheckbox,
            surveyQuestionAnswerTypeRadio,
            surveyQuestionAnswerTypeRadioAndOther,
            surveyQuestionAnswerTypeMultiSelect);

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'HasAnswered' in the 'survey_question_show_condition_types' enum.");

        byte surveyQuestionShowConditionTypeHasAnswered = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'HasNotAnswered' in the 'survey_question_show_condition_types' enum.");

        byte surveyQuestionShowConditionTypeHasNotAnswered = reader.GetSqlByte(0).StrictValue();

        surveyQuestionShowConditionTypeMap = new(
            surveyQuestionShowConditionTypeHasAnswered,
            surveyQuestionShowConditionTypeHasNotAnswered);

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'Min' in the 'survey_question_validation_condition_types' enum.");

        byte surveyQuestionValidationConditionTypeMin = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'Max' in the 'survey_question_validation_condition_types' enum.");

        byte surveyQuestionValidationConditionTypeMax = reader.GetSqlByte(0).StrictValue();

        surveyQuestionValidationConditionTypeMap = new(
            surveyQuestionValidationConditionTypeMin,
            surveyQuestionValidationConditionTypeMax);

    }

    public SurveyQuestionAnswerTypeMap SurveyQuestionAnswerTypeMap
        => surveyQuestionAnswerTypeMap;

    public SurveyQuestionShowConditionTypeMap SurveyQuestionShowConditionTypeMap
        => surveyQuestionShowConditionTypeMap;

    public SurveyQuestionValidationConditionTypeMap SurveyQuestionValidationConditionTypeMap
        => surveyQuestionValidationConditionTypeMap;
}

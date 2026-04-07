// This file was auto-generated based on ./Build/database/database_structure.yaml

using System.Collections;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public enum AnswerType : byte
{
    SmallText,
    Checkbox,
    Radio,
    RadioOrOther,
    MultiSelect,
    MultiSelectAndOther,
}

public enum ConditionOperator : byte
{
    And,
    Or,
}

public enum ShowConditionType : byte
{
    HasAnswered,
    HasNotAnswered,
}

public enum ValidationConditionType : byte
{
    Min,
    Max,
}

public class AnswerTypeMap(
    byte smallTextEnumId,
    byte checkboxEnumId,
    byte radioEnumId,
    byte radioOrOtherEnumId,
    byte multiSelectEnumId,
    byte multiSelectAndOtherEnumId)
    : IReadOnlyDictionary<byte, AnswerType>,
    IReadOnlyDictionary<AnswerType, byte>
{
    public AnswerType this[byte key] => key switch
    {
        var x when x == smallTextEnumId => AnswerType.SmallText,
        var x when x == checkboxEnumId => AnswerType.Checkbox,
        var x when x == radioEnumId => AnswerType.Radio,
        var x when x == radioOrOtherEnumId => AnswerType.RadioOrOther,
        var x when x == multiSelectEnumId => AnswerType.MultiSelect,
        var x when x == multiSelectAndOtherEnumId => AnswerType.MultiSelectAndOther,
        var x => throw new KeyNotFoundException($"Key {x} not found in AnswerTypeMap.")
    };

    public byte this[AnswerType key] => key switch
    {
        AnswerType.SmallText => smallTextEnumId,
        AnswerType.Checkbox => checkboxEnumId,
        AnswerType.Radio => radioEnumId,
        AnswerType.RadioOrOther => radioOrOtherEnumId,
        AnswerType.MultiSelect => multiSelectEnumId,
        AnswerType.MultiSelectAndOther => multiSelectAndOtherEnumId,
        _ => throw new KeyNotFoundException($"Invalid key given to AnswerTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return smallTextEnumId;
            yield return checkboxEnumId;
            yield return radioEnumId;
            yield return radioOrOtherEnumId;
            yield return multiSelectEnumId;
            yield return multiSelectAndOtherEnumId;
        }
    }

    public IEnumerable<AnswerType> Values => Enum.GetValues<AnswerType>();

    IEnumerable<AnswerType> IReadOnlyDictionary<AnswerType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<AnswerType, byte>.Values => Keys;

    public int Count => 6;

    public bool ContainsKey(byte key)
        => key == smallTextEnumId ||
            key == checkboxEnumId ||
            key == radioEnumId ||
            key == radioOrOtherEnumId ||
            key == multiSelectEnumId ||
            key == multiSelectAndOtherEnumId;

    bool IReadOnlyDictionary<AnswerType, byte>.ContainsKey(AnswerType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, AnswerType>> GetEnumerator()
    {
        yield return new(smallTextEnumId, AnswerType.SmallText);
        yield return new(checkboxEnumId, AnswerType.Checkbox);
        yield return new(radioEnumId, AnswerType.Radio);
        yield return new(radioOrOtherEnumId, AnswerType.RadioOrOther);
        yield return new(multiSelectEnumId, AnswerType.MultiSelect);
        yield return new(multiSelectAndOtherEnumId, AnswerType.MultiSelectAndOther);
    }

    IEnumerator<KeyValuePair<AnswerType, byte>> IEnumerable<KeyValuePair<AnswerType, byte>>.GetEnumerator()
    {
        yield return new(AnswerType.SmallText, smallTextEnumId);
        yield return new(AnswerType.Checkbox, checkboxEnumId);
        yield return new(AnswerType.Radio, radioEnumId);
        yield return new(AnswerType.RadioOrOther, radioOrOtherEnumId);
        yield return new(AnswerType.MultiSelect, multiSelectEnumId);
        yield return new(AnswerType.MultiSelectAndOther, multiSelectAndOtherEnumId);
    }

    public bool TryGetValue(byte key, out AnswerType value)
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

    bool IReadOnlyDictionary<AnswerType, byte>.TryGetValue(AnswerType key, out byte value)
    {
        if (((IReadOnlyDictionary<AnswerType, byte>)this).ContainsKey(key))
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

public class ConditionOperatorMap(
    byte andEnumId,
    byte orEnumId)
    : IReadOnlyDictionary<byte, ConditionOperator>,
    IReadOnlyDictionary<ConditionOperator, byte>
{
    public ConditionOperator this[byte key] => key switch
    {
        var x when x == andEnumId => ConditionOperator.And,
        var x when x == orEnumId => ConditionOperator.Or,
        var x => throw new KeyNotFoundException($"Key {x} not found in ConditionOperatorMap.")
    };

    public byte this[ConditionOperator key] => key switch
    {
        ConditionOperator.And => andEnumId,
        ConditionOperator.Or => orEnumId,
        _ => throw new KeyNotFoundException($"Invalid key given to ConditionOperatorMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return andEnumId;
            yield return orEnumId;
        }
    }

    public IEnumerable<ConditionOperator> Values => Enum.GetValues<ConditionOperator>();

    IEnumerable<ConditionOperator> IReadOnlyDictionary<ConditionOperator, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<ConditionOperator, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == andEnumId ||
            key == orEnumId;

    bool IReadOnlyDictionary<ConditionOperator, byte>.ContainsKey(ConditionOperator key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, ConditionOperator>> GetEnumerator()
    {
        yield return new(andEnumId, ConditionOperator.And);
        yield return new(orEnumId, ConditionOperator.Or);
    }

    IEnumerator<KeyValuePair<ConditionOperator, byte>> IEnumerable<KeyValuePair<ConditionOperator, byte>>.GetEnumerator()
    {
        yield return new(ConditionOperator.And, andEnumId);
        yield return new(ConditionOperator.Or, orEnumId);
    }

    public bool TryGetValue(byte key, out ConditionOperator value)
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

    bool IReadOnlyDictionary<ConditionOperator, byte>.TryGetValue(ConditionOperator key, out byte value)
    {
        if (((IReadOnlyDictionary<ConditionOperator, byte>)this).ContainsKey(key))
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

public class ShowConditionTypeMap(
    byte hasAnsweredEnumId,
    byte hasNotAnsweredEnumId)
    : IReadOnlyDictionary<byte, ShowConditionType>,
    IReadOnlyDictionary<ShowConditionType, byte>
{
    public ShowConditionType this[byte key] => key switch
    {
        var x when x == hasAnsweredEnumId => ShowConditionType.HasAnswered,
        var x when x == hasNotAnsweredEnumId => ShowConditionType.HasNotAnswered,
        var x => throw new KeyNotFoundException($"Key {x} not found in ShowConditionTypeMap.")
    };

    public byte this[ShowConditionType key] => key switch
    {
        ShowConditionType.HasAnswered => hasAnsweredEnumId,
        ShowConditionType.HasNotAnswered => hasNotAnsweredEnumId,
        _ => throw new KeyNotFoundException($"Invalid key given to ShowConditionTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return hasAnsweredEnumId;
            yield return hasNotAnsweredEnumId;
        }
    }

    public IEnumerable<ShowConditionType> Values => Enum.GetValues<ShowConditionType>();

    IEnumerable<ShowConditionType> IReadOnlyDictionary<ShowConditionType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<ShowConditionType, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == hasAnsweredEnumId ||
            key == hasNotAnsweredEnumId;

    bool IReadOnlyDictionary<ShowConditionType, byte>.ContainsKey(ShowConditionType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, ShowConditionType>> GetEnumerator()
    {
        yield return new(hasAnsweredEnumId, ShowConditionType.HasAnswered);
        yield return new(hasNotAnsweredEnumId, ShowConditionType.HasNotAnswered);
    }

    IEnumerator<KeyValuePair<ShowConditionType, byte>> IEnumerable<KeyValuePair<ShowConditionType, byte>>.GetEnumerator()
    {
        yield return new(ShowConditionType.HasAnswered, hasAnsweredEnumId);
        yield return new(ShowConditionType.HasNotAnswered, hasNotAnsweredEnumId);
    }

    public bool TryGetValue(byte key, out ShowConditionType value)
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

    bool IReadOnlyDictionary<ShowConditionType, byte>.TryGetValue(ShowConditionType key, out byte value)
    {
        if (((IReadOnlyDictionary<ShowConditionType, byte>)this).ContainsKey(key))
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

public class ValidationConditionTypeMap(
    byte minEnumId,
    byte maxEnumId)
    : IReadOnlyDictionary<byte, ValidationConditionType>,
    IReadOnlyDictionary<ValidationConditionType, byte>
{
    public ValidationConditionType this[byte key] => key switch
    {
        var x when x == minEnumId => ValidationConditionType.Min,
        var x when x == maxEnumId => ValidationConditionType.Max,
        var x => throw new KeyNotFoundException($"Key {x} not found in ValidationConditionTypeMap.")
    };

    public byte this[ValidationConditionType key] => key switch
    {
        ValidationConditionType.Min => minEnumId,
        ValidationConditionType.Max => maxEnumId,
        _ => throw new KeyNotFoundException($"Invalid key given to ValidationConditionTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return minEnumId;
            yield return maxEnumId;
        }
    }

    public IEnumerable<ValidationConditionType> Values => Enum.GetValues<ValidationConditionType>();

    IEnumerable<ValidationConditionType> IReadOnlyDictionary<ValidationConditionType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<ValidationConditionType, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == minEnumId ||
            key == maxEnumId;

    bool IReadOnlyDictionary<ValidationConditionType, byte>.ContainsKey(ValidationConditionType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, ValidationConditionType>> GetEnumerator()
    {
        yield return new(minEnumId, ValidationConditionType.Min);
        yield return new(maxEnumId, ValidationConditionType.Max);
    }

    IEnumerator<KeyValuePair<ValidationConditionType, byte>> IEnumerable<KeyValuePair<ValidationConditionType, byte>>.GetEnumerator()
    {
        yield return new(ValidationConditionType.Min, minEnumId);
        yield return new(ValidationConditionType.Max, maxEnumId);
    }

    public bool TryGetValue(byte key, out ValidationConditionType value)
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

    bool IReadOnlyDictionary<ValidationConditionType, byte>.TryGetValue(ValidationConditionType key, out byte value)
    {
        if (((IReadOnlyDictionary<ValidationConditionType, byte>)this).ContainsKey(key))
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
    AnswerTypeMap AnswerTypeMap { get; }

    ConditionOperatorMap ConditionOperatorMap { get; }

    ShowConditionTypeMap ShowConditionTypeMap { get; }

    ValidationConditionTypeMap ValidationConditionTypeMap { get; }
}

public class DatabaseEnumService : IDatabaseEnumService
{
    private readonly AnswerTypeMap answerTypeMap;

    private readonly ConditionOperatorMap conditionOperatorMap;

    private readonly ShowConditionTypeMap showConditionTypeMap;

    private readonly ValidationConditionTypeMap validationConditionTypeMap;

    public DatabaseEnumService(IConfiguration configuration)
    {
        using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        connection.Open();

        using SqlCommand command = new(
            $"""
            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'small_text';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'checkbox';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'radio';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'radio_or_other';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'multi_select';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_answer_type_id]
            FROM [survey_question_answer_types]
            WHERE [survey_question_answer_type_name] = 'multi_select_and_other';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_condition_operator_id]
            FROM [survey_question_condition_operator]
            WHERE [survey_question_condition_operator_name] = 'and';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_condition_operator_id]
            FROM [survey_question_condition_operator]
            WHERE [survey_question_condition_operator_name] = 'or';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_show_condition_type_id]
            FROM [survey_question_show_condition_types]
            WHERE [survey_question_show_condition_type_name] = 'has_answered';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_show_condition_type_id]
            FROM [survey_question_show_condition_types]
            WHERE [survey_question_show_condition_type_name] = 'has_not_answered';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_validation_condition_type_id]
            FROM [survey_question_validation_condition_types]
            WHERE [survey_question_validation_condition_type_name] = 'min';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_validation_condition_type_id]
            FROM [survey_question_validation_condition_types]
            WHERE [survey_question_validation_condition_type_name] = 'max';
            """,
            connection);

        using SqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'small_text' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeSmallText = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'checkbox' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeCheckbox = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'radio' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeRadio = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'radio_or_other' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeRadioOrOther = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'multi_select' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeMultiSelect = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'multi_select_and_other' in the 'survey_question_answer_types' enum.");

        byte surveyQuestionAnswerTypeMultiSelectAndOther = reader.GetSqlByte(0).StrictValue();

        answerTypeMap = new(
            surveyQuestionAnswerTypeSmallText,
            surveyQuestionAnswerTypeCheckbox,
            surveyQuestionAnswerTypeRadio,
            surveyQuestionAnswerTypeRadioOrOther,
            surveyQuestionAnswerTypeMultiSelect,
            surveyQuestionAnswerTypeMultiSelectAndOther);

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'and' in the 'survey_question_condition_operator' enum.");

        byte surveyQuestionConditionOperatorAnd = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'or' in the 'survey_question_condition_operator' enum.");

        byte surveyQuestionConditionOperatorOr = reader.GetSqlByte(0).StrictValue();

        conditionOperatorMap = new(
            surveyQuestionConditionOperatorAnd,
            surveyQuestionConditionOperatorOr);

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'has_answered' in the 'survey_question_show_condition_types' enum.");

        byte surveyQuestionShowConditionTypeHasAnswered = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'has_not_answered' in the 'survey_question_show_condition_types' enum.");

        byte surveyQuestionShowConditionTypeHasNotAnswered = reader.GetSqlByte(0).StrictValue();

        showConditionTypeMap = new(
            surveyQuestionShowConditionTypeHasAnswered,
            surveyQuestionShowConditionTypeHasNotAnswered);

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'min' in the 'survey_question_validation_condition_types' enum.");

        byte surveyQuestionValidationConditionTypeMin = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'max' in the 'survey_question_validation_condition_types' enum.");

        byte surveyQuestionValidationConditionTypeMax = reader.GetSqlByte(0).StrictValue();

        validationConditionTypeMap = new(
            surveyQuestionValidationConditionTypeMin,
            surveyQuestionValidationConditionTypeMax);

    }

    public AnswerTypeMap AnswerTypeMap
        => answerTypeMap;

    public ConditionOperatorMap ConditionOperatorMap
        => conditionOperatorMap;

    public ShowConditionTypeMap ShowConditionTypeMap
        => showConditionTypeMap;

    public ValidationConditionTypeMap ValidationConditionTypeMap
        => validationConditionTypeMap;
}

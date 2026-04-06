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

public enum ConditionPassing : byte
{
    Failed,
    Passed,
    Undecided,
}

public class AnswerTypeMap(
    byte smallTextIndex,
    byte checkboxIndex,
    byte radioIndex,
    byte radioOrOtherIndex,
    byte multiSelectIndex,
    byte multiSelectAndOtherIndex)
    : IReadOnlyDictionary<byte, AnswerType>,
    IReadOnlyDictionary<AnswerType, byte>
{
    public AnswerType this[byte key] => key switch
    {
        var x when x == smallTextIndex => AnswerType.SmallText,
        var x when x == checkboxIndex => AnswerType.Checkbox,
        var x when x == radioIndex => AnswerType.Radio,
        var x when x == radioOrOtherIndex => AnswerType.RadioOrOther,
        var x when x == multiSelectIndex => AnswerType.MultiSelect,
        var x when x == multiSelectAndOtherIndex => AnswerType.MultiSelectAndOther,
        var x => throw new KeyNotFoundException($"Key {x} not found in AnswerTypeMap.")
    };

    public byte this[AnswerType key] => key switch
    {
        AnswerType.SmallText => smallTextIndex,
        AnswerType.Checkbox => checkboxIndex,
        AnswerType.Radio => radioIndex,
        AnswerType.RadioOrOther => radioOrOtherIndex,
        AnswerType.MultiSelect => multiSelectIndex,
        AnswerType.MultiSelectAndOther => multiSelectAndOtherIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to AnswerTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return smallTextIndex;
            yield return checkboxIndex;
            yield return radioIndex;
            yield return radioOrOtherIndex;
            yield return multiSelectIndex;
            yield return multiSelectAndOtherIndex;
        }
    }

    public IEnumerable<AnswerType> Values => Enum.GetValues<AnswerType>();

    IEnumerable<AnswerType> IReadOnlyDictionary<AnswerType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<AnswerType, byte>.Values => Keys;

    public int Count => 6;

    public bool ContainsKey(byte key)
        => key == smallTextIndex ||
            key == checkboxIndex ||
            key == radioIndex ||
            key == radioOrOtherIndex ||
            key == multiSelectIndex ||
            key == multiSelectAndOtherIndex;

    bool IReadOnlyDictionary<AnswerType, byte>.ContainsKey(AnswerType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, AnswerType>> GetEnumerator()
    {
        yield return new(smallTextIndex, AnswerType.SmallText);
        yield return new(checkboxIndex, AnswerType.Checkbox);
        yield return new(radioIndex, AnswerType.Radio);
        yield return new(radioOrOtherIndex, AnswerType.RadioOrOther);
        yield return new(multiSelectIndex, AnswerType.MultiSelect);
        yield return new(multiSelectAndOtherIndex, AnswerType.MultiSelectAndOther);
    }

    IEnumerator<KeyValuePair<AnswerType, byte>> IEnumerable<KeyValuePair<AnswerType, byte>>.GetEnumerator()
    {
        yield return new(AnswerType.SmallText, smallTextIndex);
        yield return new(AnswerType.Checkbox, checkboxIndex);
        yield return new(AnswerType.Radio, radioIndex);
        yield return new(AnswerType.RadioOrOther, radioOrOtherIndex);
        yield return new(AnswerType.MultiSelect, multiSelectIndex);
        yield return new(AnswerType.MultiSelectAndOther, multiSelectAndOtherIndex);
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
    byte andIndex,
    byte orIndex)
    : IReadOnlyDictionary<byte, ConditionOperator>,
    IReadOnlyDictionary<ConditionOperator, byte>
{
    public ConditionOperator this[byte key] => key switch
    {
        var x when x == andIndex => ConditionOperator.And,
        var x when x == orIndex => ConditionOperator.Or,
        var x => throw new KeyNotFoundException($"Key {x} not found in ConditionOperatorMap.")
    };

    public byte this[ConditionOperator key] => key switch
    {
        ConditionOperator.And => andIndex,
        ConditionOperator.Or => orIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to ConditionOperatorMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return andIndex;
            yield return orIndex;
        }
    }

    public IEnumerable<ConditionOperator> Values => Enum.GetValues<ConditionOperator>();

    IEnumerable<ConditionOperator> IReadOnlyDictionary<ConditionOperator, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<ConditionOperator, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == andIndex ||
            key == orIndex;

    bool IReadOnlyDictionary<ConditionOperator, byte>.ContainsKey(ConditionOperator key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, ConditionOperator>> GetEnumerator()
    {
        yield return new(andIndex, ConditionOperator.And);
        yield return new(orIndex, ConditionOperator.Or);
    }

    IEnumerator<KeyValuePair<ConditionOperator, byte>> IEnumerable<KeyValuePair<ConditionOperator, byte>>.GetEnumerator()
    {
        yield return new(ConditionOperator.And, andIndex);
        yield return new(ConditionOperator.Or, orIndex);
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
    byte hasAnsweredIndex,
    byte hasNotAnsweredIndex)
    : IReadOnlyDictionary<byte, ShowConditionType>,
    IReadOnlyDictionary<ShowConditionType, byte>
{
    public ShowConditionType this[byte key] => key switch
    {
        var x when x == hasAnsweredIndex => ShowConditionType.HasAnswered,
        var x when x == hasNotAnsweredIndex => ShowConditionType.HasNotAnswered,
        var x => throw new KeyNotFoundException($"Key {x} not found in ShowConditionTypeMap.")
    };

    public byte this[ShowConditionType key] => key switch
    {
        ShowConditionType.HasAnswered => hasAnsweredIndex,
        ShowConditionType.HasNotAnswered => hasNotAnsweredIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to ShowConditionTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return hasAnsweredIndex;
            yield return hasNotAnsweredIndex;
        }
    }

    public IEnumerable<ShowConditionType> Values => Enum.GetValues<ShowConditionType>();

    IEnumerable<ShowConditionType> IReadOnlyDictionary<ShowConditionType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<ShowConditionType, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == hasAnsweredIndex ||
            key == hasNotAnsweredIndex;

    bool IReadOnlyDictionary<ShowConditionType, byte>.ContainsKey(ShowConditionType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, ShowConditionType>> GetEnumerator()
    {
        yield return new(hasAnsweredIndex, ShowConditionType.HasAnswered);
        yield return new(hasNotAnsweredIndex, ShowConditionType.HasNotAnswered);
    }

    IEnumerator<KeyValuePair<ShowConditionType, byte>> IEnumerable<KeyValuePair<ShowConditionType, byte>>.GetEnumerator()
    {
        yield return new(ShowConditionType.HasAnswered, hasAnsweredIndex);
        yield return new(ShowConditionType.HasNotAnswered, hasNotAnsweredIndex);
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
    byte minIndex,
    byte maxIndex)
    : IReadOnlyDictionary<byte, ValidationConditionType>,
    IReadOnlyDictionary<ValidationConditionType, byte>
{
    public ValidationConditionType this[byte key] => key switch
    {
        var x when x == minIndex => ValidationConditionType.Min,
        var x when x == maxIndex => ValidationConditionType.Max,
        var x => throw new KeyNotFoundException($"Key {x} not found in ValidationConditionTypeMap.")
    };

    public byte this[ValidationConditionType key] => key switch
    {
        ValidationConditionType.Min => minIndex,
        ValidationConditionType.Max => maxIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to ValidationConditionTypeMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return minIndex;
            yield return maxIndex;
        }
    }

    public IEnumerable<ValidationConditionType> Values => Enum.GetValues<ValidationConditionType>();

    IEnumerable<ValidationConditionType> IReadOnlyDictionary<ValidationConditionType, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<ValidationConditionType, byte>.Values => Keys;

    public int Count => 2;

    public bool ContainsKey(byte key)
        => key == minIndex ||
            key == maxIndex;

    bool IReadOnlyDictionary<ValidationConditionType, byte>.ContainsKey(ValidationConditionType key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, ValidationConditionType>> GetEnumerator()
    {
        yield return new(minIndex, ValidationConditionType.Min);
        yield return new(maxIndex, ValidationConditionType.Max);
    }

    IEnumerator<KeyValuePair<ValidationConditionType, byte>> IEnumerable<KeyValuePair<ValidationConditionType, byte>>.GetEnumerator()
    {
        yield return new(ValidationConditionType.Min, minIndex);
        yield return new(ValidationConditionType.Max, maxIndex);
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

public class ConditionPassingMap(
    byte failedIndex,
    byte passedIndex,
    byte undecidedIndex)
    : IReadOnlyDictionary<byte, ConditionPassing>,
    IReadOnlyDictionary<ConditionPassing, byte>
{
    public ConditionPassing this[byte key] => key switch
    {
        var x when x == failedIndex => ConditionPassing.Failed,
        var x when x == passedIndex => ConditionPassing.Passed,
        var x when x == undecidedIndex => ConditionPassing.Undecided,
        var x => throw new KeyNotFoundException($"Key {x} not found in ConditionPassingMap.")
    };

    public byte this[ConditionPassing key] => key switch
    {
        ConditionPassing.Failed => failedIndex,
        ConditionPassing.Passed => passedIndex,
        ConditionPassing.Undecided => undecidedIndex,
        _ => throw new KeyNotFoundException($"Invalid key given to ConditionPassingMap.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
            yield return failedIndex;
            yield return passedIndex;
            yield return undecidedIndex;
        }
    }

    public IEnumerable<ConditionPassing> Values => Enum.GetValues<ConditionPassing>();

    IEnumerable<ConditionPassing> IReadOnlyDictionary<ConditionPassing, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<ConditionPassing, byte>.Values => Keys;

    public int Count => 3;

    public bool ContainsKey(byte key)
        => key == failedIndex ||
            key == passedIndex ||
            key == undecidedIndex;

    bool IReadOnlyDictionary<ConditionPassing, byte>.ContainsKey(ConditionPassing key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, ConditionPassing>> GetEnumerator()
    {
        yield return new(failedIndex, ConditionPassing.Failed);
        yield return new(passedIndex, ConditionPassing.Passed);
        yield return new(undecidedIndex, ConditionPassing.Undecided);
    }

    IEnumerator<KeyValuePair<ConditionPassing, byte>> IEnumerable<KeyValuePair<ConditionPassing, byte>>.GetEnumerator()
    {
        yield return new(ConditionPassing.Failed, failedIndex);
        yield return new(ConditionPassing.Passed, passedIndex);
        yield return new(ConditionPassing.Undecided, undecidedIndex);
    }

    public bool TryGetValue(byte key, out ConditionPassing value)
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

    bool IReadOnlyDictionary<ConditionPassing, byte>.TryGetValue(ConditionPassing key, out byte value)
    {
        if (((IReadOnlyDictionary<ConditionPassing, byte>)this).ContainsKey(key))
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

    ConditionPassingMap ConditionPassingMap { get; }
}

public class DatabaseEnumService : IDatabaseEnumService
{
    private readonly AnswerTypeMap answerTypeMap;

    private readonly ConditionOperatorMap conditionOperatorMap;

    private readonly ShowConditionTypeMap showConditionTypeMap;

    private readonly ValidationConditionTypeMap validationConditionTypeMap;

    private readonly ConditionPassingMap conditionPassingMap;

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

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_condition_passing_id]
            FROM [survey_question_condition_passing]
            WHERE [survey_question_condition_passing_name] = 'failed';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_condition_passing_id]
            FROM [survey_question_condition_passing]
            WHERE [survey_question_condition_passing_name] = 'passed';

            IF @@ROWCOUNT = 0
                RETURN;

            SELECT [survey_question_condition_passing_id]
            FROM [survey_question_condition_passing]
            WHERE [survey_question_condition_passing_name] = 'undecided';
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

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'failed' in the 'survey_question_condition_passing' enum.");

        byte surveyQuestionConditionPassingFailed = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'passed' in the 'survey_question_condition_passing' enum.");

        byte surveyQuestionConditionPassingPassed = reader.GetSqlByte(0).StrictValue();

        reader.NextResult();

        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for 'undecided' in the 'survey_question_condition_passing' enum.");

        byte surveyQuestionConditionPassingUndecided = reader.GetSqlByte(0).StrictValue();

        conditionPassingMap = new(
            surveyQuestionConditionPassingFailed,
            surveyQuestionConditionPassingPassed,
            surveyQuestionConditionPassingUndecided);

    }

    public AnswerTypeMap AnswerTypeMap
        => answerTypeMap;

    public ConditionOperatorMap ConditionOperatorMap
        => conditionOperatorMap;

    public ShowConditionTypeMap ShowConditionTypeMap
        => showConditionTypeMap;

    public ValidationConditionTypeMap ValidationConditionTypeMap
        => validationConditionTypeMap;

    public ConditionPassingMap ConditionPassingMap
        => conditionPassingMap;
}


using System.Text.RegularExpressions;

namespace DataDriven.Models;

public interface ISurveyModel
{
    int SurveyId { get; }
    string SurveyTitle { get; }
    string SurveyAuthor { get; }
    string SurveyDescription { get; }
    IReadOnlyList<ISurveyPageModel> SurveyPages { get; }
}

public record SurveyModel(
    int SurveyId,
    string SurveyTitle,
    string SurveyAuthor,
    string SurveyDescription,
    IReadOnlyList<ISurveyPageModel> SurveyPages) : ISurveyModel;

public interface ISurveyPageModel
{
    int SurveyPageIndex { get; }
    string SurveyPageTitle { get; }
    string SurveyPageDescription { get; }
    IReadOnlyList<ISurveyQuestionModel> SurveyQuestions { get; }
}

public record SurveyPageModel(
    int SurveyPageIndex,
    string SurveyPageTitle,
    string SurveyPageDescription,
    IReadOnlyList<ISurveyQuestionModel> SurveyQuestions) : ISurveyPageModel;

public interface ISurveyQuestionModel
{
    int SurveyId { get; }
    string SurveyTitle { get; }
    string SurveyAuthor { get; }
    string SurveyDescription { get; }
    IReadOnlyList<ISurveyQuestionShowConditionModel> SurveyShowConstraint { get; }
    IReadOnlyList<ISurveyQuestionValidationConditionModel> SurveyValidationConstraint { get; }
}

public record SurveyQuestionSmallTextModel(
    int SurveyId,
    string SurveyTitle,
    string SurveyAuthor,
    string SurveyDescription,
    IReadOnlyList<ISurveyQuestionShowConditionModel> SurveyShowConstraint,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> SurveyValidationConstraint) : ISurveyQuestionModel;

public record SurveyQuestionCheckboxModel(
    int SurveyId,
    string SurveyTitle,
    string SurveyAuthor,
    string SurveyDescription,
    IReadOnlyList<ISurveyQuestionShowConditionModel> SurveyShowConstraint,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> SurveyValidationConstraint,
    string? SurveyCheckboxPrompt) : ISurveyQuestionModel;

public record SurveyQuestionRadioModel(
    int SurveyId,
    string SurveyTitle,
    string SurveyAuthor,
    string SurveyDescription,
    IReadOnlyList<ISurveyQuestionShowConditionModel> SurveyShowConstraint,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> SurveyValidationConstraint,
    IReadOnlyList<string> SurveyRadioValues) : ISurveyQuestionModel;

public record SurveyQuestionRadioOrOtherModel(
    int SurveyId,
    string SurveyTitle,
    string SurveyAuthor,
    string SurveyDescription,
    IReadOnlyList<ISurveyQuestionShowConditionModel> SurveyShowConstraint,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> SurveyValidationConstraint,
    IReadOnlyList<string> SurveyRadioValues) : ISurveyQuestionModel;

public record SurveyQuestionMultiSelectModel(
    int SurveyId,
    string SurveyTitle,
    string SurveyAuthor,
    string SurveyDescription,
    IReadOnlyList<ISurveyQuestionShowConditionModel> SurveyShowConstraint,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> SurveyValidationConstraint,
    IReadOnlyList<string> SurveyOptionValues) : ISurveyQuestionModel;

public record SurveyQuestionMultiSelectAndOtherModel(
    int SurveyId,
    string SurveyTitle,
    string SurveyAuthor,
    string SurveyDescription,
    IReadOnlyList<ISurveyQuestionShowConditionModel> SurveyShowConstraint,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> SurveyValidationConstraint,
    IReadOnlyList<string> SurveyOptionValues) : ISurveyQuestionModel;

public interface ISurveyQuestionShowConditionModel { }

public record SurveyQuestionShowConditionHasAnsweredSmallTextModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionSmallTextModel> ReferencingSurveyQuestion,
    Regex? AnswerMatch) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredCheckboxModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionCheckboxModel> ReferencingSurveyQuestion) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredRadioModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionRadioModel> ReferencingSurveyQuestion,
    int? AnswerSpecific) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredRadioOrOtherOptionModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionRadioOrOtherModel> ReferencingSurveyQuestion,
    int? AnswerSpecific) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredRadioOrOtherOtherModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionRadioOrOtherModel> ReferencingSurveyQuestion,
    Regex? OtherAnswerMask) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredMultiSelectModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionMultiSelectModel> ReferencingSurveyQuestion,
    int? AnswerSpecific) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredMultiSelectAndOtherOptionModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionMultiSelectAndOtherModel> ReferencingSurveyQuestion,
    int? AnswerSpecific) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredMultiSelectAndOtherOtherModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionMultiSelectAndOtherModel> ReferencingSurveyQuestion,
    Regex? OtherAnswerMask) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredSmallTextModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionSmallTextModel> ReferencingSurveyQuestion,
    Regex? AnswerMatch) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredCheckboxModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionCheckboxModel> ReferencingSurveyQuestion) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredRadioModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionRadioModel> ReferencingSurveyQuestion,
    int? AnswerSpecificallyNot) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredRadioOrOtherOptionModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionRadioOrOtherModel> ReferencingSurveyQuestion,
    int? AnswerSpecificallyNot) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredRadioOrOtherOtherModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionRadioOrOtherModel> ReferencingSurveyQuestion,
    Regex? OtherAnswerMask) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredMultiSelectModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionMultiSelectModel> ReferencingSurveyQuestion,
    int? AnswerSpecificallyNot) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredMultiSelectAndOtherOptionModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionMultiSelectAndOtherModel> ReferencingSurveyQuestion,
    int? AnswerSpecificallyNot) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasNotAnsweredMultiSelectAndOtherOtherModel(
    ISurveyQuestionModel AffectedSurveyQuestion,
    KeyValuePair<
        (int SurveyTitle, int SurveyAuthor),
        SurveyQuestionMultiSelectAndOtherModel> ReferencingSurveyQuestion,
    Regex? OtherAnswerMask) : ISurveyQuestionShowConditionModel;

public interface ISurveyQuestionValidationConditionModel { }

public record SurveyQuestionValidationConditionMinSmallTextModel(
    SurveyQuestionSmallTextModel SurveyQuestion,
    int AnswerMinLength) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionValidationConditionMinMultiSelectModel(
    SurveyQuestionMultiSelectModel SurveyQuestion,
    int AnswerMinLength) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionValidationConditionMinMultiSelectAndOtherModel(
    SurveyQuestionMultiSelectAndOtherModel SurveyQuestion,
    int AnswerMinLength) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionValidationConditionMaxSmallTextModel(
    SurveyQuestionSmallTextModel SurveyQuestion,
    int AnswerMaxLength) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionValidationConditionMaxMultiSelectModel(
    SurveyQuestionMultiSelectModel SurveyQuestion,
    int AnswerMaxLength) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionValidationConditionMaxMultiSelectAndOtherModel(
    SurveyQuestionMultiSelectAndOtherModel SurveyQuestion,
    int AnswerMaxLength) : ISurveyQuestionShowConditionModel;

public interface ISubmissionModel
{
    ISurveyModel Survey { get; }
    IList<ISubmissionPageModel> SurveyPages { get; }
}

public record SubmissionModel(
    ISurveyModel Survey,
    IList<ISubmissionPageModel> SurveyPages) : ISubmissionModel;

public interface ISubmissionPageModel
{
    ISurveyPageModel SurveyPage { get; }
    IList<ISubmissionQuestionAnswerModel> SurveyAnswers { get; }
}

public record SubmissionPageModel(
    ISurveyPageModel SurveyPage,
    IList<ISubmissionQuestionAnswerModel> SurveyAnswers) : ISubmissionPageModel;

public interface ISubmissionQuestionAnswerModel
{
    ISurveyQuestionModel SurveyQuestion { get; }
    object ValueAsObject { get; }
}

public record SurveyQuestionSmallTextAnswerModel(
    SurveyQuestionSmallTextModel SurveyQuestion,
    string Value) : ISubmissionQuestionAnswerModel
{
    ISurveyQuestionModel ISubmissionQuestionAnswerModel.SurveyQuestion => SurveyQuestion;
    public object ValueAsObject => Value;
}

public record SurveyQuestionCheckboxAnswerModel(
    SurveyQuestionCheckboxModel SurveyQuestion,
    bool Value) : ISubmissionQuestionAnswerModel
{

    ISurveyQuestionModel ISubmissionQuestionAnswerModel.SurveyQuestion => SurveyQuestion;
    public object ValueAsObject => Value;
}

public record SurveyQuestionRadioAnswerModel(
    SurveyQuestionRadioModel SurveyQuestion,
    int Value) : ISubmissionQuestionAnswerModel
{
    ISurveyQuestionModel ISubmissionQuestionAnswerModel.SurveyQuestion => SurveyQuestion;
    public object ValueAsObject => Value;
}

public record SurveyQuestionRadioOrOtherAnswerModel(
    SurveyQuestionRadioOrOtherModel SurveyQuestion,
    int Value,
    string? OrOther) : ISubmissionQuestionAnswerModel
{
    ISurveyQuestionModel ISubmissionQuestionAnswerModel.SurveyQuestion => SurveyQuestion;
    public object ValueAsObject => OrOther == null ? Value : OrOther;
}

public record SurveyQuestionMultiSelectAnswerModel(
    SurveyQuestionMultiSelectModel SurveyQuestion,
    bool[] Value) : ISubmissionQuestionAnswerModel
{
    ISurveyQuestionModel ISubmissionQuestionAnswerModel.SurveyQuestion => SurveyQuestion;
    public object ValueAsObject => Value;
}

public record SurveyQuestionMultiSelectAndOtherAnswerModel(
    SurveyQuestionMultiSelectAndOtherModel SurveyQuestion,
    bool[] Value,
    string? AndOther) : ISubmissionQuestionAnswerModel
{
    ISurveyQuestionModel ISubmissionQuestionAnswerModel.SurveyQuestion => SurveyQuestion;
    public object ValueAsObject => (Value, AndOther);
}

using System.Diagnostics;
using System.Text.RegularExpressions;
using DataDriven.Data;

namespace DataDriven.Models;

public interface ISurveyModel
{
    public int Id { get; }
    public string Title { get; }
    public string Author { get; }
    public string Description { get; }
    public int PageCount { get; }
    public IReadOnlyList<ISurveyPageModel>? Pages { get; }
}

public record SurveyModel : ISurveyModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public IReadOnlyList<ISurveyPageModel>? Pages
    {
        get => pageObject is IReadOnlyList<ISurveyPageModel> pages ? pages : null;
        set => pageObject = value;
    }
    public int PageCount
    {
        get => pageObject switch
        { 
            IReadOnlyList<ISurveyPageModel> pages => pages.Count,
            int pageCount => pageCount,
            null => 0,
            _ => throw new UnreachableException(),
        };
        set => pageObject = value;
    }

    object? pageObject;

    public SurveyModel(
        int Id,
        string Title,
        string Author,
        string Description,
        IReadOnlyList<ISurveyPageModel> Pages)
    {
        this.Id = Id;
        this.Title = Title;
        this.Author = Author;
        this.Description = Description;
        pageObject = Pages;
    }

    public SurveyModel(
        int Id,
        string Title,
        string Author,
        string Description,
        int PageCount)
    {
        this.Id = Id;
        this.Title = Title;
        this.Author = Author;
        this.Description = Description;
        pageObject = PageCount;
    }
}

public interface ISurveyPageModel
{
    public ISurveyModel? Parent { get; }
    public string Title { get; }
    public string Description { get; }
    public IReadOnlyDictionary<int, ISurveyQuestionModel> Questions { get; }
}

public record SurveyPageModel(
    string Title,
    string Description,
    IReadOnlyDictionary<int, ISurveyQuestionModel> Questions,
    ISurveyModel? Parent = null) : ISurveyPageModel;

public interface ISurveyQuestionModel
{
    public ISurveyPageModel? Parent { get; }
    public int Id { get; }
    public string Title { get; }
    public IReadOnlyList<ISurveyQuestionShowConditionModel> ShowConditions { get; }
    public IReadOnlyList<ISurveyQuestionValidationConditionModel> ValidationConditions { get; }
}

public record SurveyQuestionSmallTextModel(
    int Id,
    string Title,
    string? Label,
    IReadOnlyList<ISurveyQuestionShowConditionModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionCheckboxModel(
    int Id,
    string Title,
    string? Label,
    IReadOnlyList<ISurveyQuestionShowConditionModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionRadioModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConditionModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionRadioOrOtherModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConditionModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionMultiSelectModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConditionModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionMultiSelectAndOtherModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConditionModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConditionModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public interface ISurveyQuestionShowConditionModel
{
    public ConditionOperator Operator { get; }
    public ISurveyQuestionModel Parent { get; }
}

public record SurveyQuestionShowConditionPreviouslyPassed(
    ConditionOperator Operator,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredSmallTextModel(
    ConditionOperator Operator,
    SurveyQuestionSmallTextModel ReferencedQuestion,
    Regex Match,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredCheckboxModel(
    ConditionOperator Operator,
    SurveyQuestionCheckboxModel ReferencedQuestion,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredRadioModel(
    ConditionOperator Operator,
    SurveyQuestionRadioModel ReferencedQuestion,
    int? OptionIndex,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredOptionOfRadioOrOtherModel(
    ConditionOperator Operator,
    SurveyQuestionRadioOrOtherModel ReferencedQuestion,
    int? OptionIndex,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredOtherOfRadioOrOtherModel(
    ConditionOperator Operator,
    SurveyQuestionRadioOrOtherModel ReferencedQuestion,
    Regex Match,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredMultiSelectModel(
    ConditionOperator Operator,
    SurveyQuestionMultiSelectModel ReferencedQuestion,
    int? OptionIndex,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredOptionOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    SurveyQuestionMultiSelectAndOtherModel ReferencedQuestion,
    int? OptionIndex,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public record SurveyQuestionShowConditionHasAnsweredOtherOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    SurveyQuestionMultiSelectAndOtherModel ReferencedQuestion,
    Regex Match,
    bool Invert,
    ISurveyQuestionModel Parent) : ISurveyQuestionShowConditionModel;

public interface ISurveyQuestionValidationConditionModel
{
    public ConditionOperator Operator { get; }
    public ISurveyQuestionModel Parent { get; }
}

public record SurveyQuestionValidationConditionPreviouslyPassed(
    ConditionOperator Operator,
    ISurveyQuestionModel Parent) : ISurveyQuestionValidationConditionModel;

public record SurveyQuestionValidationConditionBoundSmallTextModel(
    ConditionOperator Operator,
    int LengthBound,
    bool IsMax,
    SurveyQuestionSmallTextModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}

public record SurveyQuestionValidationConditionBoundCheckboxModel(
    ConditionOperator Operator,
    bool IsMax,
    SurveyQuestionCheckboxModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}

public record SurveyQuestionValidationConditionBoundRadioModel(
    ConditionOperator Operator,
    bool IsMax,
    SurveyQuestionRadioModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}

public record SurveyQuestionValidationConditionBoundOptionOfRadioOrOtherModel(
    ConditionOperator Operator,
    bool IsMax,
    SurveyQuestionRadioOrOtherModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}

public record SurveyQuestionValidationConditionBoundOtherOfRadioOrOtherModel(
    ConditionOperator Operator,
    int LengthBound,
    bool IsMax,
    SurveyQuestionRadioOrOtherModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}

public record SurveyQuestionValidationConditionBoundMultiSelectModel(
    ConditionOperator Operator,
    int CountBound,
    bool IsMax,
    SurveyQuestionMultiSelectModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}

public record SurveyQuestionValidationConditionBoundOptionOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    int CountBound,
    bool IsMax,
    SurveyQuestionMultiSelectAndOtherModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}

public record SurveyQuestionValidationConditionBoundOtherOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    int LengthBound,
    bool IsMax,
    SurveyQuestionMultiSelectAndOtherModel Parent) : ISurveyQuestionValidationConditionModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConditionModel.Parent => Parent;
}
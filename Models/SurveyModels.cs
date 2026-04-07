
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using DataDriven.Data;

namespace DataDriven.Models;

public interface ISurveyModel
{
    string Title { get; }
    string Author { get; }
    string Description { get; }
    int PageCount { get; }
    IReadOnlyList<ISurveyPageModel>? Pages { get; }
}

public record SurveyModel : ISurveyModel
{
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
        string Title,
        string Author,
        string Description,
        IReadOnlyList<ISurveyPageModel> Pages)
    {
        this.Title = Title;
        this.Author = Author;
        this.Description = Description;
        pageObject = Pages;
    }

    public SurveyModel(
        string Title,
        string Author,
        string Description,
        int PageCount)
    {
        this.Title = Title;
        this.Author = Author;
        this.Description = Description;
        pageObject = PageCount;
    }
}

public interface ISurveyPageModel
{
    ISurveyModel? Parent { get; }
    string Title { get; }
    string Description { get; }
    IReadOnlyList<ISurveyQuestionModel> Questions { get; }
}

public record SurveyPageModel(
    string Title,
    string Description,
    IReadOnlyList<ISurveyQuestionModel> Questions,
    ISurveyModel? Parent = null) : ISurveyPageModel;

public interface ISurveyQuestionModel
{
    ISurveyPageModel? Parent { get; }
    int Id { get; }
    string Title { get; }
    IReadOnlyList<ISurveyQuestionShowConstraintModel> ShowConditions { get; }
    IReadOnlyList<ISurveyQuestionValidationConstraintModel> ValidationConditions { get; }
}

public record SurveyQuestionSmallTextModel(
    int Id,
    string Title,
    string? Label,
    IReadOnlyList<ISurveyQuestionShowConstraintModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConstraintModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionCheckboxModel(
    int Id,
    string Title,
    string? Label,
    IReadOnlyList<ISurveyQuestionShowConstraintModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConstraintModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionRadioModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConstraintModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConstraintModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionRadioOrOtherModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConstraintModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConstraintModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionMultiSelectModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConstraintModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConstraintModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public record SurveyQuestionMultiSelectAndOtherModel(
    int Id,
    string Title,
    IReadOnlyList<string> Options,
    IReadOnlyList<ISurveyQuestionShowConstraintModel> ShowConditions,
    IReadOnlyList<ISurveyQuestionValidationConstraintModel> ValidationConditions,
    ISurveyPageModel? Parent) : ISurveyQuestionModel;

public interface ISurveyQuestionShowConstraintModel
{
    ConditionOperator Operator { get; }
    ISurveyQuestionModel? Parent { get; }
}

public record SurveyQuestionShowConstraintPreviouslyPassed(
    ConditionOperator Operator,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredSmallTextModel(
    ConditionOperator Operator,
    SurveyQuestionSmallTextModel ReferencedQuestion,
    Regex Match,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredCheckboxModel(
    ConditionOperator Operator,
    SurveyQuestionCheckboxModel ReferencedQuestion,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredRadioModel(
    ConditionOperator Operator,
    SurveyQuestionRadioModel ReferencedQuestion,
    IReadOnlySet<int> Mask,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredOptionOfRadioOrOtherModel(
    ConditionOperator Operator,
    SurveyQuestionRadioOrOtherModel ReferencedQuestion,
    IReadOnlySet<int> Mask,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredOtherOfRadioOrOtherModel(
    ConditionOperator Operator,
    SurveyQuestionRadioOrOtherModel ReferencedQuestion,
    Regex Match,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredMultiSelectModel(
    ConditionOperator Operator,
    SurveyQuestionMultiSelectModel ReferencedQuestion,
    IReadOnlySet<int> Mask,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredOptionOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    SurveyQuestionMultiSelectAndOtherModel ReferencedQuestion,
    IReadOnlySet<int> Mask,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public record SurveyQuestionShowConstraintHasAnsweredOtherOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    SurveyQuestionMultiSelectAndOtherModel ReferencedQuestion,
    Regex Match,
    bool Invert = false,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionShowConstraintModel;

public interface ISurveyQuestionValidationConstraintModel
{
    ConditionOperator Operator { get; }
    ISurveyQuestionModel? Parent { get; }
}

public record SurveyQuestionValidationConstraintPreviouslyPassed(
    ConditionOperator Operator,
    ISurveyQuestionModel? Parent = null) : ISurveyQuestionValidationConstraintModel;

public record SurveyQuestionValidationConstraintBoundSmallTextModel(
    ConditionOperator Operator,
    int LengthBound,
    bool IsMax,
    SurveyQuestionSmallTextModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}

public record SurveyQuestionValidationConstraintBoundCheckboxModel(
    ConditionOperator Operator,
    bool IsMax,
    SurveyQuestionCheckboxModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}

public record SurveyQuestionValidationConstraintBoundRadioModel(
    ConditionOperator Operator,
    int Bound,
    bool IsMax,
    SurveyQuestionRadioModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}

public record SurveyQuestionValidationConstraintBoundOptionOfRadioOrOtherModel(
    ConditionOperator Operator,
    int Bound,
    bool IsMax,
    SurveyQuestionRadioOrOtherModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}

public record SurveyQuestionValidationConstraintBoundOtherOfRadioOrOtherModel(
    ConditionOperator Operator,
    int LengthBound,
    bool IsMax,
    SurveyQuestionRadioOrOtherModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}

public record SurveyQuestionValidationConstraintBoundMultiSelectModel(
    ConditionOperator Operator,
    int Bound,
    bool IsMax,
    SurveyQuestionMultiSelectModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}

public record SurveyQuestionValidationConstraintBoundOptionOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    int Bound,
    bool IsMax,
    SurveyQuestionMultiSelectAndOtherModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}

public record SurveyQuestionValidationConstraintBoundOtherOfMultiSelectAndOtherModel(
    ConditionOperator Operator,
    int LengthBound,
    bool IsMax,
    SurveyQuestionMultiSelectAndOtherModel Parent) : ISurveyQuestionValidationConstraintModel
{
    ISurveyQuestionModel ISurveyQuestionValidationConstraintModel.Parent => Parent;
}
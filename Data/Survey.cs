
// using System.Diagnostics;
// using System.Text.RegularExpressions;

// namespace DataDriven.Data;

// // Non-specific publicity is really annoying.

// public enum TextQuestionType : byte
// {
//     Small,
// }

// public enum BoundType : byte
// {
//     Min,
//     Max,
// }

// public class Survey
// {
//     public class Builder
//     {
//         public class Page
//         {
//             public abstract class Question
//             {
//                 public abstract class ShowCondition
//                 {
//                     public Question Parent { get; }

//                     public ShowCondition(Question builder)
//                     {
//                         ArgumentNullException.ThrowIfNull(builder);

//                         this.Parent = builder;
//                         this.Parent.showConditions.Add(this);
//                     }
//                 }

//                 public class ReferencingShowCondition<Q>(Question builder)
//                     : ShowCondition(builder) where Q : Question
//                 {
//                     private TextQuestion reference = null!;

//                     public required TextQuestion Reference
//                     {
//                         get => reference;
//                         set
//                         {
//                             if (value.Parent.Parent != this.Parent.Parent.Parent)
//                             {
//                                 throw new InvalidOperationException(
//                                     "Referencing question must be in the same" +
//                                     " survey.");
//                             }

//                             if (value.Parent != this.Parent.Parent)
//                             {
//                                 bool foundReference = false;
//                                 foreach (Page page in this.Parent.Parent.Parent.pages)
//                                 {
//                                     if (page == value.Parent)
//                                         foundReference = true;

//                                     if (page == this.Parent.Parent)
//                                     {
//                                         if (!foundReference)
//                                             throw new InvalidOperationException(
//                                                 "Referencing question must be" +
//                                                 " in the same or previous page.");

//                                         reference = value;
//                                         break;
//                                     }
//                                 }

//                                 throw new UnreachableException();
//                             }
//                             else
//                             {
//                                 bool foundReference = false;
//                                 foreach (Question question in this.Parent.Parent.questions)
//                                 {
//                                     if (question == value)
//                                         foundReference = true;

//                                     if (question == this.Parent)
//                                     {
//                                         if (!foundReference)
//                                             throw new InvalidOperationException(
//                                                 "Referencing question must be" +
//                                                 " a previous question.");

//                                         reference = value;
//                                         break;
//                                     }
//                                 }

//                                 throw new UnreachableException();
//                             }
//                         }
//                     }
//                 }

//                 public class TextHasAnsweredCondition(Question builder)
//                     : ReferencingShowCondition<TextQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                 }

//                 public class TextHasAnsweredLikeCondition(Question builder)
//                     : ReferencingShowCondition<TextQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                     public required Regex Pattern { get; set; }
//                 }

//                 public class CheckboxHasAnsweredCondition(Question builder)
//                     : ReferencingShowCondition<CheckboxQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                 }

//                 public class RadioHasAnsweredCondition(Question builder)
//                     : ReferencingShowCondition<RadioQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                 }

//                 public class RadioHasAnsweredOptionCondition(Question builder)
//                     : ReferencingShowCondition<RadioQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                     public required int OptionIndex { get; set; }
//                 }

//                 public class RadioHasAnsweredOtherCondition(Question builder)
//                     : ReferencingShowCondition<RadioQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                 }

//                 public class RadioHasAnsweredOtherLikeCondition(Question builder)
//                     : ReferencingShowCondition<RadioQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                     public required Regex Pattern { get; set; }
//                 }

//                 public class MultiSelectHasAnsweredCondition(Question builder)
//                     : ReferencingShowCondition<MultiSelectQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                 }

//                 public class MultiSelectHasAnsweredOptionCondition(Question builder)
//                     : ReferencingShowCondition<MultiSelectQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                     public required int OptionIndex { get; set; }
//                 }

//                 public class MultiSelectHasAnsweredOtherCondition(Question builder)
//                     : ReferencingShowCondition<MultiSelectQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                 }

//                 public class MultiSelectHasAnsweredOtherLikeCondition(Question builder)
//                     : ReferencingShowCondition<MultiSelectQuestion>(builder)
//                 {
//                     public bool Invert { get; set; } = false;
//                     public required Regex Pattern { get; set; }
//                 }

//                 public abstract class ValidationCondition
//                 {
//                     public Question Parent { get; }

//                     public ValidationCondition(Question builder)
//                     {
//                         ArgumentNullException.ThrowIfNull(builder);

//                         this.Parent = builder;
//                         this.Parent.validationConditions.Add(this);
//                     }
//                 }

//                 public class TextLengthFitsBoundCondition(TextQuestion builder)
//                     : ValidationCondition(builder)
//                 {
//                     public new TextQuestion Parent => (TextQuestion)base.Parent;
//                     public required BoundType Bound { get; set; }
//                     public required int Length { get; set; }
//                 }

//                 public class CheckboxCheckedCondition(CheckboxQuestion builder)
//                     : ValidationCondition(builder)
//                 {
//                     public new CheckboxQuestion Parent => (CheckboxQuestion)base.Parent;
//                     public bool Invert { get; set; }
//                 }

//                 public class RadioOptionCheckedCondition(RadioQuestion builder)
//                     : ValidationCondition(builder)
//                 {
//                     public new RadioQuestion Parent => (RadioQuestion)base.Parent;
//                     public bool Invert { get; set; }
//                 }

//                 public class RadioOtherLengthFitsBoundCondition(RadioQuestion builder)
//                     : ValidationCondition(builder)
//                 {
//                     public new RadioQuestion Parent => (RadioQuestion)base.Parent;
//                     public required BoundType Bound { get; set; }
//                     public required int Length { get; set; }
//                 }

//                 public class MultiSelectOptionCheckedCondition(MultiSelectQuestion builder)
//                     : ValidationCondition(builder)
//                 {
//                     public new MultiSelectQuestion Parent => (MultiSelectQuestion)base.Parent;
//                     public required BoundType Bound { get; set; }
//                     public required int Count { get; set; }
//                 }

//                 public class MultiSelectOtherLengthFitsBoundCondition(MultiSelectAndOtherQuestion builder)
//                     : ValidationCondition(builder)
//                 {
//                     public new MultiSelectAndOtherQuestion Parent => (MultiSelectAndOtherQuestion)base.Parent;
//                     public required BoundType Bound { get; set; }
//                     public required int Length { get; set; }
//                 }

//                 public required string Prompt { get; set; }
//                 public Page Parent { get; }

//                 private readonly List<ShowCondition> showConditions = [];
//                 private readonly List<ValidationCondition> validationConditions = [];

//                 public Question(Page builder)
//                 {
//                     ArgumentNullException.ThrowIfNull(builder);

//                     this.Parent = builder;
//                     this.Parent.questions.Add(this);
//                 }
//             }

//             public class TextQuestion(Page builder) : Question(builder)
//             {
//                 public required TextQuestionType Type { get; set; } = TextQuestionType.Small;
//             }

//             public class CheckboxQuestion(Page builder) : Question(builder);

//             public abstract class QuestionWithOptions(Page builder) : Question(builder)
//             {
//                 public IEnumerable<string>? Options { get; set; }

//                 public void Add(string option)
//                 {
//                     ArgumentNullException.ThrowIfNull(option);

//                     Options = Options switch
//                     {
//                         ICollection<string> x => x,
//                         IEnumerable<string> x => (ICollection<string>)[.. x],
//                         null => (ICollection<string>)[],
//                     };

//                     ((ICollection<string>)Options).Add(option);
//                 }
//             }

//             public class RadioQuestion(Page builder) : QuestionWithOptions(builder);

//             public class RadioOrOtherQuestion(Page builder) : RadioQuestion(builder);

//             public class MultiSelectQuestion(Page builder) : QuestionWithOptions(builder);

//             public class MultiSelectAndOtherQuestion(Page builder) : MultiSelectQuestion(builder);

//             public required string Title { get; set; }
//             public required string Description { get; set; }
//             public Builder Parent { get; }

//             private readonly List<Question> questions = [];

//             public Page(Builder builder)
//             {
//                 this.Parent = builder;
//                 this.Parent.pages.Add(this);
//             }
//         }

//         public required string Title { get; set; }
//         public required string Description { get; set; }

//         private readonly List<Page> pages = [];
//     }

//     private class PageData
//     {
//         public class QuestionData
//         {
            
//         }
//     }

//     private List<> pages;

//     private Survey() { }
// }
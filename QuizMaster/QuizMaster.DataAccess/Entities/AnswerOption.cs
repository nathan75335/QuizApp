using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.DataAccess.Entities;

/// <summary>
/// AnswerOption class, this class gonna help the user to have multiple options
/// </summary>
public class AnswerOption
{
    [Key]
    public int OptionId {  get; set; }
    public string Text {  get; set; }
    public bool IsCorrect {  get; set; }

    [ForeignKey(nameof(Question))]
    public int QuestionId {  get; set; }
    public Question Question { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizMaster.DataAccess.Entities;

public class UserAnswer
{
    [Key]
    public int UserAnswerId { get; set; }

    [ForeignKey(nameof(UserQuiz))]
    public int UserQuizId { get; set; }
    public UserQuiz UserQuiz { get; set; }

    [ForeignKey(nameof(Question))]
    public int QuestionId { get; set; }
    public Question Question { get; set; }

    [ForeignKey(nameof(AnswerOption))]
    public int AnswerOptionId { get; set; }
    public AnswerOption AnswerOption { get; set; }
}

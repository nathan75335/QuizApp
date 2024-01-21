using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.DataAccess.Entities;

/// <summary>
/// Quiz class, A Quiz can have multiple questions
/// </summary>
public class Quiz
{
    [Key]
    public int QuizId {  get; set; }
    public string Title {  get; set; }

    [ForeignKey(nameof(Creator))]
    public int UserId {  get; set; }
    public User Creator { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId {  get; set; }
    public Category Category { get; set; }

    public List<Question> Questions { get; set; }
    public List<UserQuiz> UserQuizzes { get; set; }
}

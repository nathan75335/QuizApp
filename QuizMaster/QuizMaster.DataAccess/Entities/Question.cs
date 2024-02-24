using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.DataAccess.Entities;

public class Question
{
    [Key]
    public int QuestionId { get; set; }
    public string QuestionTitle { get; set; }
    public int Point {  get; set; }
    
    [ForeignKey(nameof(Quiz))]
    public int QuizId {  get; set; }
    public Quiz Quiz { get; set; }

    public List<AnswerOption> Options { get; set; }

}

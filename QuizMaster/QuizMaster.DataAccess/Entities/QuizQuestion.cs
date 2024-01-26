namespace QuizMaster.DataAccess.Entities;

public class QuizQuestion
{
    public int QuizQuestionId {  get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int AnswerOptionId { get; set; }
    public AnswerOption AnswerOption { get; set; }
}

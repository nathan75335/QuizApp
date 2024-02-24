namespace QuizMaster.BusinessLogic.Requests;

public class QuizRequest
{
    public string Title { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}

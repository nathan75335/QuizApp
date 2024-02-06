using QuizMaster.DataAccess.Entities;

namespace QuizMaster.BusinessLogic.Requests;

public class UserQuizRequest
{
    public int UserId { get; set; }
    public int QuizId { get; set; }
}

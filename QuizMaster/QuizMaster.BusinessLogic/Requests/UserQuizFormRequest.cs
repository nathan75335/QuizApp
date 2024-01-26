using QuizMaster.DataAccess.Entities;

namespace QuizMaster.BusinessLogic.Requests;

public class UserQuizFormRequest
{
    public int QuizId { get; set; }
    public List<QuizQuestion> QuizQuestions { get; set; }
}

using QuizMaster.DataAccess.Entities;

namespace QuizMaster.BusinessLogic.Requests;

public class UserQuizFormRequest
{
    public int QuizId { get; set; }
    public List<QuizQuestionRequest> QuizQuestions { get; set; }
}

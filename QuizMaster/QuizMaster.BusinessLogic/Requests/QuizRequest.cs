using QuizMaster.DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.BusinessLogic.Requests;

public class QuizRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}

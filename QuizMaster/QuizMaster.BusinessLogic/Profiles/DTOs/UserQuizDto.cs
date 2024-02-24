using QuizMaster.DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.BusinessLogic.Profiles.DTOs;

public class UserQuizDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int QuizId { get; set; }
    public string QuizTitle { get; set; }
    public int Score { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.DataAccess.Entities;

/// <summary>
/// User Class, a User can create multiple quizzes, 
/// can take multiple quizzes.
/// </summary>
public class User
{
    [Key]
    public int UserId {  get; set; }
    public string UserName { get; set; }
    public string Email {  get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    //Quiz Created by the user
    public List<Quiz> CreatedQuizzes { get; set; }
    //Quuizz taken by the user
    public List<UserQuiz> TakenQuizzes { get; set; }
}

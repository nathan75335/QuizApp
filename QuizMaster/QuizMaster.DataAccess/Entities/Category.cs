using System.ComponentModel.DataAnnotations;

namespace QuizMaster.DataAccess.Entities;

/// <summary>
/// Category class, 
/// </summary>
public class Category
{
    [Key]
    public int CategoryId {  get; set; }
    public string Name { get; set; }
    public List<Quiz> Quizzes { get; set; }

}

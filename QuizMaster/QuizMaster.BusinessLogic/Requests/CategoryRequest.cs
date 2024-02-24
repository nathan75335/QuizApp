using System.ComponentModel.DataAnnotations;

namespace QuizMaster.BusinessLogic.Requests;

public class CategoryRequest
{
    [Required]
    public string Name { get; set; }
}

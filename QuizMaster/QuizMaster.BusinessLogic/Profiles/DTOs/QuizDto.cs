namespace QuizMaster.BusinessLogic.Profiles.DTOs;

public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<QuestionDto> Questions { get; set; }

}

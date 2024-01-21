using System.ComponentModel.DataAnnotations;

namespace QuizMaster.BusinessLogic.Requests;

public class UserLoginRequest
{
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

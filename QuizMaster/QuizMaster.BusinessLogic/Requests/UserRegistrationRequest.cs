using System.ComponentModel.DataAnnotations;

namespace QuizMaster.BusinessLogic.Requests;

public class UserRegistrationRequest
{
    [Required(ErrorMessage = "The user's name field is required")]
    public string Name {  get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword {  get; set; }
}

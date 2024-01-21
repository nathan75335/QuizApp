using FluentValidation;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.API.Validators;

public class UserLogInRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLogInRequestValidator()
    {
        RuleFor(u => u.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress();

        RuleFor(u => u.Password)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters")
            .Matches("[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]")
                .WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]")
                .WithMessage("Password must contain at least one digit");
    }
}

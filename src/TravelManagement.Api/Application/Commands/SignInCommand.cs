using FluentValidation;
using FluentValidation.Results;

namespace TravelManagement.Api.Application.Commands;

public class SignInCommand
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }

    public bool IsValid => Validate();

    public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

    public SignInCommand(string email, string fullName, string password)
    {
        Email = email;
        FullName = fullName;
        Password = password;
    }

    private bool Validate()
    {
        ValidationResult = new SignInCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    private class SignInCommandValidation : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidation()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("The {PropertyName} cannot be empty")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("The {PropertyName} must have a valid email format");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .WithMessage("The {PropertyName} cannot be empty");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("The {PropertyName} cannot be empty")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=!]).*$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character (@#$%^&+=!)");
        }
    }
}

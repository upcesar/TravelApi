using FluentValidation;
using TravelManagement.Domain.Common;

namespace TravelManagement.Domain.Entities;

public class Users : Entity
{
    public string Email { get; init; }
    public string FullName { get; init; }
    public string Password { get; init; }

    public override bool IsValid => Validate();

    public Users(string email, string fullName, string password)
    {
        Email = email;
        FullName = fullName;
        Password = password;
    }

    private bool Validate()
    {
        ValidationResult = new UsersValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    private class UsersValidation : AbstractValidator<Users>
    {
        public UsersValidation()
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
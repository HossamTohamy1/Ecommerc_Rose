// Application/Features/Auth/Commands/Register/RegisterCommandValidator.cs
using Application.Features.Auth.Commands.Register;
using Domain.Constants;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            // ── FullName ─────────────────────────────────────────────────
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MinimumLength(3).WithMessage("Full name must be at least 3 characters.")
                .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");

            // ── Email ────────────────────────────────────────────────────
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .MaximumLength(256).WithMessage("Email must not exceed 256 characters.");

            // ── Password ─────────────────────────────────────────────────
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            // ── ConfirmPassword ──────────────────────────────────────────
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is required.")
                .Equal(x => x.Password).WithMessage("Passwords do not match.");

            // ── PhoneNumber (optional) ───────────────────────────────────
            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Phone number is not valid.")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));

            // ── Role ─────────────────────────────────────────────────────
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(role => AppRoles.AllowedForRegistration.Contains(role))
                .WithMessage($"Role must be one of: {string.Join(", ", AppRoles.AllowedForRegistration)}.");

            // ── CompanyName (required only for Trader) ─────────────
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company name is required for Trader accounts.")
                .MaximumLength(200).WithMessage("Company name must not exceed 200 characters.")
                .When(x => x.Role == AppRoles.Trader);

            // ── Country (optional) ───────────────────────────────────────
            RuleFor(x => x.Country)
                .MaximumLength(100).WithMessage("Country must not exceed 100 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Country));

            // ── Address (optional) ───────────────────────────────────────
            RuleFor(x => x.Address)
                .MaximumLength(300).WithMessage("Address must not exceed 300 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Address));
        }
    }
}
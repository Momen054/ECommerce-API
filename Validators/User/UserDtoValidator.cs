using E_Commerce.Data;
using E_Commerce.DTOs.User;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Validators.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator(EcommerceDbContext dbContext)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.SecondName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.UserName)
            .NotEmpty()
            .Length(3, 30)
            .MustAsync(async (username, ct) =>
                !await dbContext.Users.AnyAsync(u => u.UserName == username, ct))
            .WithMessage("Username already exists.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(100)
                .MustAsync(async (email, CancellationToken) =>
                    !await dbContext.Users.AnyAsync(u => u.Email == email, CancellationToken))
                .WithMessage("Email already exists");

            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches(@"[!@#$%^&*(),.?""':{}|<>]")
                .WithMessage("Password must contain at least one special character.");

        }
    }
}

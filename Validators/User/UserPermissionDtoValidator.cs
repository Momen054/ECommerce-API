using E_Commerce.Data;
using E_Commerce.DTOs.User;
using FluentValidation;

namespace E_Commerce.Validators.User
{
    public class UserPermissionDtoValidator : AbstractValidator<UserPermissionDto>
    {
        public UserPermissionDtoValidator()
        {
            RuleFor(up => up.UserName)
                .NotEmpty();

            RuleFor(up => up.PasswordHash)
                .NotEmpty();
        }
    }
}

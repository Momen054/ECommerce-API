using E_Commerce.Data;
using E_Commerce.DTOs.Role;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Validators.Role
{
    public class RoleDtoValidator:AbstractValidator<RoleDto>
    {
        public RoleDtoValidator(EcommerceDbContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .MustAsync(async (name, ct) =>
                    !await context.Roles.AnyAsync(r => r.Name == name, ct))
                .WithMessage("Role already exists.");
        }
    }
}

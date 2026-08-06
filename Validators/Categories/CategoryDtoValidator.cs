using E_Commerce.Data;
using E_Commerce.DTOs.Categories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Validators.Categories
{
    public class CategoryDtoValidator:AbstractValidator<CategoriesDto>
    {
        public CategoryDtoValidator(EcommerceDbContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .MustAsync(async (name, ct) =>
                    !await context.Categories.AnyAsync(c => c.Name == name, ct))
                .WithMessage("Category already exists.");

            RuleFor(x => x.Description)
                .MaximumLength(300);

        }
    }
}

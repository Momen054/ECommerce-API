using E_Commerce.Data;
using E_Commerce.DTOs.Product;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Validators.Product
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator(EcommerceDbContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Stock)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryId)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, ct) =>
                    await context.Categories.AnyAsync(c => c.Id == id, ct))
                .WithMessage("Category not found.");
        }
    }
}

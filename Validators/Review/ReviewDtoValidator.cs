using E_Commerce.Data;
using E_Commerce.DTOs.Review;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Validators.Review
{
    public class ReviewDtoValidator:AbstractValidator<ReviewDto>
    {
        public ReviewDtoValidator(EcommerceDbContext context)
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.ProductId)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, ct) =>
                    await context.Products.AnyAsync(p => p.Id == id, ct))
                .WithMessage("Product not found.");

            RuleFor(x => x.Rating)
                .InclusiveBetween((byte)1, (byte)5);

            RuleFor(x => x.Comment)
                .MaximumLength(500);
        }
    }
}

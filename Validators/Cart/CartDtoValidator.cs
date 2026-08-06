using E_Commerce.Data;
using E_Commerce.DTOs.Cart;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Validators.Cart
{
    public class CartDtoValidator:AbstractValidator<CartDto>
    {
        public CartDtoValidator(EcommerceDbContext context)
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, ct) =>
                    await context.Users.AnyAsync(u => u.Id == id, ct))
                .WithMessage("Invalid User Id");
        }
    }
}

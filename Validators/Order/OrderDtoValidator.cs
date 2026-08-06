using E_Commerce.Data;
using E_Commerce.DTOs.Order;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Validators.Order
{
    public class OrderDtoValidator:AbstractValidator<OrderDto>
    {
        public OrderDtoValidator(EcommerceDbContext context)
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, ct) =>
                    await context.Users.AnyAsync(u => u.Id == id, ct))
                .WithMessage("Invalid User Id");

            RuleFor(x => x.ShippingAddress)
                .NotEmpty()
                .MaximumLength(300);
        }
    }
}

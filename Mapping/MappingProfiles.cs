using AutoMapper;
using E_Commerce.DTOs.Cart;
using E_Commerce.DTOs.Categories;
using E_Commerce.DTOs.Order;
using E_Commerce.DTOs.Product;
using E_Commerce.DTOs.Review;
using E_Commerce.DTOs.Role;
using E_Commerce.DTOs.User;
using E_Commerce.Models;
using System.Runtime;

namespace E_Commerce.Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CartDto, Cart>();
            CreateMap<Cart, GetCartDto>();

            CreateMap<CategoriesDto, Category>();
            CreateMap<Category, GetCategoriesDto>();

            CreateMap<OrderDto, Order>();
            CreateMap<Order, GetOrderDto>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product, GetProductDto>();

            CreateMap<ReviewDto,Review>();
            CreateMap<Review, GetReviewDto>();

            CreateMap<RoleDto, Role>();
            CreateMap<Role, GetRoleDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, GetUserDto>();
        }
    }
}

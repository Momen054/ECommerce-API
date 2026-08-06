using E_Commerce.DTOs.Review;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IReviewService
    {
        Task<GetReviewDto> GetById(int id);
        Task Create(ReviewDto dto);
        Task Put(ReviewDto dto);
        Task Delete(int id,int userId);
    }
}

using AutoMapper;
using E_Commerce.DTOs.Review;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;


namespace E_Commerce.Services
{
    public class ReviewService(IMapper _mapper,IUnitOfWork _repository) : IReviewService
    {
        public async Task<GetReviewDto> GetById(int id)
        {
            var review = await _repository.GenericRepository<Review>().GetById(id);
            if (review == null) throw new KeyNotFoundException("Review not found");
            return _mapper.Map<GetReviewDto>(review);
        }
        public async Task Create(ReviewDto dto)
        {
            if(dto == null) throw new Exception("Invalid Review");
            dto.CreatedAt = DateTime.Now;
            await _repository.GenericRepository<Review>().Create(_mapper.Map<Review>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Put(ReviewDto dto)
        {
            if (dto == null) throw new Exception("Invalid Review");
            _repository.GenericRepository<Review>().Put(_mapper.Map<Review>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id,int userId)
        {
            var review = await _repository.GenericRepository<Review>().GetById(id);
            if (review == null || review.UserId != userId) throw new KeyNotFoundException("Invalid Review");
            _repository.GenericRepository<Review>().Delete(id);
            await _repository.SaveChangesAsync();
        }
    }
}

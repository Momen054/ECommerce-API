using AutoMapper;
using E_Commerce.DTOs.User;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;

namespace E_Commerce.Services
{
    public class UserService(IMapper _mapper,IUnitOfWork _repository) : IUserService
    {
        public async Task<IEnumerable<GetUserDto>> Get()
        {
            var users = await _repository.Users.GetAllUsers();
            if (users.Count()==0) throw new KeyNotFoundException("User not found");
            return _mapper.Map<IEnumerable<GetUserDto>>(users);
        }
        public async Task<GetUserDto> GetById(int id)
        {
            var user = await _repository.GenericRepository<User>().GetById(id);
            if (user == null || user.IsDeleted==false) throw new Exception("User not found");
            return _mapper.Map<GetUserDto>(user);
        }
        public async Task Put(UserDto dto)
        {
            if(dto==null) throw new Exception("User not found");
            _repository.GenericRepository<User>().Put(_mapper.Map<User>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _repository.GenericRepository<User>().GetById(id);
            if (result == null) throw new KeyNotFoundException("Invalid User");
            result.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }
    }
}

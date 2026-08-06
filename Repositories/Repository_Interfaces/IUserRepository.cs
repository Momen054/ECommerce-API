using E_Commerce.Models;

namespace E_Commerce.Repositories.Repository_Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}

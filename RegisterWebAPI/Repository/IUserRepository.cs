using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace RegisterWebAPI.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetRange(int range);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Add(User entity);
        Task Remove(User entity);
        Task Update(User entity);
        Task<User> GetUserWithPassword(string username);
    }
}
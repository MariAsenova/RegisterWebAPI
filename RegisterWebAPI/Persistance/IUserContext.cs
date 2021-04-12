using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData
{
    public interface IUserContext
    {
        Task SaveChangesAsync();
        Task<IList<User>> GetUsersAsync();
    }
}
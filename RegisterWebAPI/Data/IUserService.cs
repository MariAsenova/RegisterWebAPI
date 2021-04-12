using System.Threading.Tasks;
using Models;

namespace Familyregister.Data
{
    public interface IUserService
    {
        Task<User> GetUserWithPassword(string userName);
    }
}
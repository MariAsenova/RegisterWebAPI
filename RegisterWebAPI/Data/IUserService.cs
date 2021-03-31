using Models;

namespace Familyregister.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
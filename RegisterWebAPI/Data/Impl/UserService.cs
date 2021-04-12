using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Familyregister.Data.Impl
{
    public class UserService : IUserService
    {
        private IUserContext userContext;

        public UserService(IUserContext userContext)
        {
            this.userContext = userContext;
        }

        public async Task<User> GetUserWithPassword(string username)
        {
            try
            {
                // TODO 
                Task<IList<User>> usersAsync = userContext.GetUsersAsync();
                // getting result out
                IList<User> list = usersAsync.GetAwaiter().GetResult();
                
                User first = list.First(userTo => userTo.UserName.Equals(username));
                
                return first;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
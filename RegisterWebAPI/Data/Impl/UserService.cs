using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;

namespace Familyregister.Data.Impl
{
    public class UserService : IUserService
    {
        private List<User> users;

        public UserService()
        {
            users = new[]
            {
                new User()
                {
                    Password = "1234",
                    Role = "Manager",
                    UserName = "mariaasenova"
                },
                new User()
                {
                    Password = "1234",
                    Role = "Analyst",
                    UserName = "rasmus"
                }
            }.ToList();
        }
        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User userGiven = users.FirstOrDefault(user => user.UserName.Equals(username));

            if (username == null)
            {
                throw new Exception("User not found");
            }

            if (!userGiven.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return userGiven;
        }
    }
    

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Models;

namespace Familyregister.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
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
        
        public User ValidateUser(string username, string password)
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
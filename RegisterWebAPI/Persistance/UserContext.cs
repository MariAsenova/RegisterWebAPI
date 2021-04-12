using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace FileData
{
    public class UserContext : IUserContext
    {
        public IList<User> Users { get; private set; }
        private readonly string usersFile = "users.json";

        public UserContext()
        {
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
        }

        public async Task SaveChangesAsync()
        {
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter streamWriter = new StreamWriter(usersFile, false))
            {
                streamWriter.Write(jsonUsers);
            }
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return Users;
        }

        private IList<T> ReadData<T>(string fileName)
        {
            using (var jsonReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Familyregister.Data;
using FileData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;
using RegisterWebAPI.Repository;

namespace RegisterWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRepository<Family> repositoryFamily = new FamiliesRepository();
            List<Family> families = repositoryFamily.GetAll().GetAwaiter().GetResult().ToList();
            if (!families.Any())
            {
                Console.WriteLine("No families, seeding the database");
                IList<Family> seedFamilies = SeedFamilies();
                foreach (Family family in seedFamilies)
                {
                    Console.WriteLine(family.StreetName);
                    family.Children = null;
                    family.Pets = null;
                    repositoryFamily.Add(family);
                }
            }

            IUserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetAll().GetAwaiter().GetResult().ToList();
            if (!users.Any())
            {
                Console.WriteLine("No users, seeding the database");
                IList<User> seedUsers = SeedUsers();
                foreach (User user in seedUsers)
                {
                    userRepository.Add(user);
                }
            }
            
            CreateHostBuilder(args).Build().Run();
        }

        private static IList<Family> SeedFamilies()
        {
            Console.WriteLine("Getting families from file");
            FileContext fileContext = new FileContext();
            IList<Family> families = fileContext.GetFamiliesAsync().GetAwaiter().GetResult();
            return families;
        }

        private static IList<User> SeedUsers()
        {
            Console.WriteLine("Getting families from file");
            UserContext userContext = new UserContext();
            IList<User> users = userContext.GetUsersAsync().GetAwaiter().GetResult();
            return users;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
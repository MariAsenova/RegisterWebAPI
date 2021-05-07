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
            IFamily repositoryFamily = new FamiliesRepository();
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
            
            

            CreateHostBuilder(args).Build().Run();
        }

        private static IList<Family> SeedFamilies()
        {
            Console.WriteLine("Getting families from file");
            FileContext fileContext = new FileContext();
            IList<Family> families = fileContext.GetFamiliesAsync().GetAwaiter().GetResult();
            return families;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
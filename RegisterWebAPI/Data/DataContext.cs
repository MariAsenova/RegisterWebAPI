using Microsoft.EntityFrameworkCore;
using Models;

namespace Familyregister.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=register;Username=postgres;Password=9533",
                options => options.UseAdminDatabase("register"));
        }
    }
}
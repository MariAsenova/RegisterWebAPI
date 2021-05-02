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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adult>(entity =>
            {
                entity.HasOne(a => a.JobTitle).WithOne(j => j.Adult)
                    .HasForeignKey<Adult>(a => a.IdJob);
            });

            modelBuilder.Entity<Adult>().HasData(
                new Adult
                {
                    Id = 1,
                    FirstName = "Maria",
                    LastName = "Asenova",
                    HairColor = "Brown",
                    EyeColor = "blue",
                    Age = 24,
                    Weight = 56,
                    Height = 167,
                    Sex = "F",
                    IdJob = 1
                },
                new Adult
                {
                    Id = 2,
                    FirstName = "Kasper",
                    LastName = "Andersen",
                    HairColor = "Black",
                    EyeColor = "Green",
                    Age = 30,
                    Weight = 72,
                    Height = 168,
                    Sex = "F",
                    IdJob = 2
                });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasOne(d => d.Adult).WithOne(a => a.JobTitle)
                    .HasForeignKey<Job>(j => j.IdAdult);
            });

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    IdJob = 1,
                    JobTitle = "Project Manager",
                    Salary = 45000,
                    IdAdult = 1
                },
                new Job
                {
                    IdJob = 2,
                    JobTitle = "Head of Marketing",
                    Salary = 36000,
                    IdAdult = 2
                }
            );
        }
    }
}
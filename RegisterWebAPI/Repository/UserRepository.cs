using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace RegisterWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        public  async Task<IEnumerable<User>> GetRange(int range)
        {
         await using DataContext context= new DataContext();
         return context.Users.Take(range).ToList();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            await using DataContext context= new DataContext();
            return context.Users.ToList();
        }

        public async Task<User> GetById(int id)
        {
            await using DataContext context= new DataContext();
            return await context.Users.FirstOrDefaultAsync(user => user.IdUser == id);
        }

        public async Task Add(User entity)
        {
            await using DataContext context= new DataContext();
            EntityEntry<User> entityEntry = await context.Users.AddAsync(entity);
            Console.WriteLine($"User added with name: {entityEntry.Entity.UserName}");
            await context.SaveChangesAsync();
        }

        public async Task Remove(User entity)
        {
            await using DataContext context= new DataContext();
            EntityEntry<User> entityEntry = context.Users.Remove(entity);
            Console.WriteLine($"User added with name: {entityEntry.Entity.UserName} is removed");
            await context.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            await using DataContext context= new DataContext();
            EntityEntry<User> entityEntry = context.Users.Update(entity);
            Console.WriteLine($"User added with name: {entityEntry.Entity.UserName} is updated");
            await context.SaveChangesAsync();
        }

        public async Task<User> GetUserWithPassword(string username)
        {
            await using DataContext context= new DataContext();
            return await context.Users.FirstOrDefaultAsync(user => user.UserName.Equals(username));
        }
    }
}
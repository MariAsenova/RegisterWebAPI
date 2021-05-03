using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace RegisterWebAPI.Repository
{
    public class AdultRepository : IRepository<Adult>
    {
        public async Task<IEnumerable<Adult>> GetAll()
        {
            
            await using DataContext context = new DataContext();
            return context.Adults.ToList();
        }

        public async Task<Adult> GetById(int id)
        {
            await using DataContext context = new DataContext();
            IQueryable<Adult> adults = context.Adults.Where(a => a.Id == id);
            Adult firstAsync = await adults.FirstAsync(a => a.Id == id);
            return firstAsync;
        }

        public async Task Add(Adult entity)
        {
            await using DataContext context = new DataContext();
            await context.Adults.AddAsync(entity);
        }

        public async Task Remove(Adult entity)
        {
            await using DataContext context = new DataContext();
            context.Adults.Remove(entity);
        }

        public async Task Update(Adult entity)
        {
            await using DataContext context = new DataContext();
            context.Adults.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
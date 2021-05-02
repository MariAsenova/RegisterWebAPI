using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace RegisterWebAPI.Repository
{
    public class FamiliesRepository : IRepository<Family>
    {
        public async Task<IEnumerable<Family>> GetAll()
        {
            await using DataContext context = new DataContext();
            return context.Families.ToList();
        }

        public async Task<Family> GetById(int id)
        {
            await using DataContext context = new DataContext();
            IQueryable<Family> families = context.Families.Where(f => f.IdFamily == id);
            Family firstOrDefaultAsync = await families.FirstOrDefaultAsync(f => f.IdFamily == id);
            return firstOrDefaultAsync;
        }

        public async Task Add(Family entity)
        {
           await using DataContext context = new DataContext();
            await context.Families.AddAsync(entity);
        }

        public async Task Remove(Family entity)
        {
            await using DataContext context = new DataContext();
            context.Families.Remove(entity);
        }

        public async Task Update(Family entity)
        {
            await using DataContext context = new DataContext();
            context.Families.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
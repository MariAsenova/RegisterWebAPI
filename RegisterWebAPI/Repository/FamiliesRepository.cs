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
    public class FamiliesRepository : IRepository<Family>
    {
        public async Task<IEnumerable<Family>> GetAll()
        {
            await using DataContext context = new DataContext();
            return context.Families.Include(family => family.Adults).ToList();
        }

        public async Task<Family> GetById(int id)
        {
            /*
            await using DataContext context = new DataContext();
            IQueryable<Family> families = context.Families.Where(f => f.IdFamily == id);
            Family firstOrDefaultAsync = await families.FirstOrDefaultAsync(f => f.IdFamily == id);
            return firstOrDefaultAsync;
            */
            throw new NotImplementedException();
        }

        public async Task Add(Family entity)
        {
            await using DataContext context = new DataContext();
            EntityEntry<Family> entityEntry = await context.Families.AddAsync(entity);
            // to get back what you add
            //Family entityEntryEntity = entityEntry.Entity;
            await context.SaveChangesAsync();
        }

        public async Task Remove(Family entity)
        {
            await using DataContext context = new DataContext();
            context.Families.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(Family entity)
        {
            await using DataContext context = new DataContext();
            context.Families.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
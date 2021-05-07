using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Models;

namespace RegisterWebAPI.Repository
{
    public class FamiliesRepository : IRepository<Family>
    {
        public async Task<IEnumerable<Family>> GetRange(int range)
        {
            await using DataContext context = new DataContext();
            IEnumerable<Family> families = context.Families.Include(family => family.Adults)
                .ThenInclude(adult => adult.JobTitle).Take(range).ToList();
            return families;
        }

        public async Task<Family> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Family entity)
        {
            await using DataContext context = new DataContext();
            EntityEntry<Family> entityEntry = await context.Families.AddAsync(entity);
            Family familyEntityAdded = entityEntry.Entity;
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

        public async Task<IEnumerable<Family>> GetAll()
        {
            // TODO Check why error when keyword using
            DataContext context = new DataContext();
            return context.Families.Include(family => family.Adults).ThenInclude(adult => adult.JobTitle).ToList();
        }
    }
}
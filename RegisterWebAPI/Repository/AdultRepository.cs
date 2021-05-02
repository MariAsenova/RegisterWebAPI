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
        protected readonly DataContext context;

        public AdultRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Adult>> GetAll()
        {
            return context.Adults.ToList();
        }

        public async Task<Adult> GetById(int id)
        {
            IQueryable<Adult> adults = context.Adults.Where(a => a.Id == id);
            Adult firstAsync = await adults.FirstAsync(a => a.Id == id);
            return firstAsync;
        }

        public async Task Add(Adult entity)
        {
            await context.Adults.AddAsync(entity);
        }

        public async Task Remove(Adult entity)
        {
            context.Adults.Remove(entity);
        }
    }
}
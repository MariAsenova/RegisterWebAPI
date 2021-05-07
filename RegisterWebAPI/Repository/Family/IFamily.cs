using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace RegisterWebAPI.Repository
{
    public interface IFamily : IRepository<Family>
    {
        Task<IEnumerable<Family>> GetAll();
    }
}
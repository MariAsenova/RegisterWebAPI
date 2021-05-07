using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterWebAPI.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetRange(int range);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Remove(T entity);
        Task Update(T entity);

    }
}
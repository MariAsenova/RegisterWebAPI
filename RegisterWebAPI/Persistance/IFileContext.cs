using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData
{
    public interface IFileContext
    {
        Task SaveChanges();
        Task<IList<Family>> GetFamilies();
    }
}
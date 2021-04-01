using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Familyregister.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesAsync();
        Task UpdateAsync(Adult adult, Family family);
        Task<Adult> GetAdultAsync(int id);
        Task RemoveAdultAsync(int id);
        Task AddAdultAsync(Adult adult, Family family);
    }
}
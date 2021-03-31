using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Familyregister.Data
{
    public class FamilyService : IFamilyService
    {
        private IFileContext fileContext;
        public FamilyService(IFileContext fileContext)
        {
            this.fileContext = fileContext;
        }
        
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            IList<Family> familiesAsync = await fileContext.GetFamiliesAsync();
            return familiesAsync;
        }

        public async Task UpdateAsync(Adult adult, Family family)
        {
            Family familyToUpdate = fileContext.GetFamiliesAsync().Result.First(matchFamily =>
                matchFamily.HouseNumber == family.HouseNumber && matchFamily.StreetName.Equals(family.StreetName));
            familyToUpdate.Adults.Remove(adult);
            familyToUpdate.Adults.Add(adult);

            await fileContext.SaveChangesAsync();
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            IList<Family> familiesAsync = await fileContext.GetFamiliesAsync();
            
            Adult adultToEdit = familiesAsync.SelectMany(family => family.Adults)
                .FirstOrDefault(adult => adult.Id == id);
            if (adultToEdit == null)
            {
                throw new Exception("Adult not found");
            }

            return adultToEdit;
        }

        public async Task RemoveAdultAsync(int id)
        {
            IList<Family> families= await fileContext.GetFamiliesAsync();

            foreach (var family in families)
            {
                foreach (var adult in family.Adults)
                {
                    if (adult.Id == id)
                    {
                        family.Adults.Remove(adult);
                        break;
                    }
                }
            }
            await fileContext.SaveChangesAsync();
        }

        public async Task AddAdultAsync(Adult adult, Family family)
        {
            IList<Family> familiesAsync = await fileContext.GetFamiliesAsync();
            Family familyToAddTo = familiesAsync.First(familyTo => familyTo.Equals(family));
            familyToAddTo.Adults.Add(adult);
            await fileContext.SaveChangesAsync();
        }
    }
}
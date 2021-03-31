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
        private IList<Family> families;

        public FamilyService(IFileContext fileContext)
        {
            this.fileContext = fileContext;
            families = fileContext.GetFamilies();
        }

// ----------
        public IList<Family> GetFamilies()
        {
            return fileContext.GetFamilies();
        }

        public void Update(Adult adult, Family family)
        {
            Family familyToUpdate = fileContext.GetFamilies().First(matchFamily =>
                matchFamily.HouseNumber == family.HouseNumber && matchFamily.StreetName.Equals(family.StreetName));
            familyToUpdate.Adults.Remove(adult);
            familyToUpdate.Adults.Add(adult);

            fileContext.SaveChanges();
        }

        public Adult GetAdult(int id)
        {
            IList<Family> families = fileContext.GetFamilies();

            Adult adultToEdit = fileContext.GetFamilies().SelectMany(family => family.Adults)
                .FirstOrDefault(adult => adult.Id == id);
            if (adultToEdit == null)
            {
                throw new Exception("Adult not found");
            }

            return adultToEdit;
        }

        public void RemoveAdult(int id)
        {
            Adult adultToRemove = GetAdult(id);
            IList<Family> families = fileContext.GetFamilies();

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

                // adultToEdit = family.Adults.Find(adult => adult.Id == id);
            }

            fileContext.SaveChanges();
        }

        public void AddAdult(Adult adult, Family family)
        {
            Family familyToAddTo = fileContext.GetFamilies().First(familyTo => familyTo.Equals(family));
            familyToAddTo.Adults.Add(adult);
            fileContext.SaveChanges();
        }


        // ---------------
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            IList<Family> familiesAsync = await fileContext.GetFamilies();
            return familiesAsync;
        }

        public Task UpdateAsync(Adult adult, Family family)
        {
            throw new NotImplementedException();
        }

        public Task<Adult> GetAdultAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAdultAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAdultAsync(Adult adult, Family family)
        {
            throw new NotImplementedException();
        }
    }
}
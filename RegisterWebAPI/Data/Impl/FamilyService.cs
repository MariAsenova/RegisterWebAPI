using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Familyregister.Data
{
    public class FamilyService : IFamilyService
    {
        private string familiesFile = "families.json";
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

        public async Task UpdateAsync(Adult adult)
        {
            Family family = fileContext.GetFamiliesAsync().Result
                .First(f => f.Adults.Exists(adultTo => adultTo.Id == adult.Id));

            if (family != null)
            {
                fileContext.GetFamiliesAsync().Result.First(f => f.Adults.Exists(adultTo => adultTo.Id == adult.Id))
                    .Adults.Remove(adult);
                fileContext.GetFamiliesAsync().Result.First(f => f.Adults.Exists(adultTo => adultTo.Id == adult.Id))
                    .Adults.Add(adult);

                await fileContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Family for updating adult not found");
            }
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            IList<Family> familiesAsync = await fileContext.GetFamiliesAsync();

            // TODO refactor
            Adult adultToEdit = null;

            foreach (var family in familiesAsync)
            {
                foreach (var adult in family.Adults)
                {
                    if (adult.Id == id)
                    {
                        adultToEdit = adult;
                    }
                }
            }

            if (adultToEdit == null)
            {
                throw new Exception("Adult not found");
            }

            return adultToEdit;
        }

        public async Task RemoveAdultAsync(int id)
        {
            Adult adult = fileContext.GetFamiliesAsync().Result
                .First(f => f.Adults.Exists(adultTo => adultTo.Id == id)).Adults.First(adultTo => adultTo.Id == id);
            var removedAdult = fileContext.GetFamiliesAsync().Result.First(family => family.Adults.Exists(adultTo => adultTo.Id == id))
                .Adults.Remove(adult);

            if (removedAdult)
            {
                await fileContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("adult to remove not found");
            }
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
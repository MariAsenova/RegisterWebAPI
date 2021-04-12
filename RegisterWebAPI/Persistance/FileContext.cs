using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace FileData
{
    public class FileContext : IFileContext
    {
        public IList<Family> Families { get; private set; }
        private readonly string familiesFile = "families.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
        }


        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public async Task SaveChangesAsync()
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            return Families;
        }
    }
}
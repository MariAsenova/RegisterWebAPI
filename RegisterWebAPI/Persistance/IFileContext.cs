using System.Collections.Generic;
using Models;

namespace FileData
{
    public interface IFileContext
    {
        void SaveChanges();
        IList<Family> GetFamilies();
    }
}
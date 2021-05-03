using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Adult : Person
    {
        public Job JobTitle { get; set; }
    }
}
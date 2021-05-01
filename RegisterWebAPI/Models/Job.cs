using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Models
{
    public class Job
    {
        [Key] public int IdJob { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int IdAdult { get; set; }
        public Adult Adult { get; set; }
    }
}
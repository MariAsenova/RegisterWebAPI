using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        
    }
}
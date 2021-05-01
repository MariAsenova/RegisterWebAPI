using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
public class Interest {
    [Key]
    public int IdInterest { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

}
}
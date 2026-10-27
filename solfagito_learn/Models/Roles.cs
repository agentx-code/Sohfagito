using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace solfagito_learn.Models
{
    [Table("tbl_roles")]
    public class Roles
    {
        [Key]
        public Guid id { get; set; }
        public string? Role_name { get; set; }
    }
}

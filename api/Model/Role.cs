using System.ComponentModel.DataAnnotations;

namespace api1.Model
{
    public class Role
    {
        [Key]
        public int id_Role { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

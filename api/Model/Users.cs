using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api1.DataBaseContext;

namespace api1.Model
{
    public class Users
    {
        [Key]
        public int id_User{get; set;}
        public string Name { get; set;} 
        public string Description { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int Role_id { get; set; } 
        public Role Role { get; set; }

    }
}

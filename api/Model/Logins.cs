using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api1.Model
{
    [Index(nameof(Login), IsUnique = true)]
    public class Logins
    {
        [Key]
        public int id_Login { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int User_id { get; set; }
        public Users Users { get; set; }
    }
}
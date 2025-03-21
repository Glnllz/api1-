using System.ComponentModel.DataAnnotations;

namespace api1.Model
{
    public class LoginRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace api1.Requests
{
    public class CreateNewUserAndLogin
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}

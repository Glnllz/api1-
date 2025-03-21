using System.ComponentModel.DataAnnotations;

namespace api1.Model
{
    public class UpdateUserRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Role_id { get; set; }
    }
}

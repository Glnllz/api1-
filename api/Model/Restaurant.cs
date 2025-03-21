using System.ComponentModel.DataAnnotations;

namespace api1.Model
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
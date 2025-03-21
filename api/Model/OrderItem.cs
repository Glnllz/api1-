using System.ComponentModel.DataAnnotations;

namespace api1.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int MenuId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Menu Menu { get; set; }
    }
}
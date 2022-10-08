using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartService.Models{
    [Table("ShoppingCart")]
    public class ShoppingCart{
        [Key]
        [Required]
        public string? id{get; set;}
        public ICollection<Item>? items{get; set;}
        public Order? purchase{get; set;}
    }
}
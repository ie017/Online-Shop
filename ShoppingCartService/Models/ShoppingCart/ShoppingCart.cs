using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShoppingCartService.Models{
    [Table("ShoppingCarts")]
    public class ShoppingCart{
        [Key]
        [Required]
        public string? shoppingcartId{get; set;}
        [JsonIgnore]
        public virtual IList<Item>? items{get; set;}
        public string? purchaseId{get; set;}
    }
}
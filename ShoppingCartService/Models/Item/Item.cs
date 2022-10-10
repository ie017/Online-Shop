using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartService.Models{
    [Table("Items")]
    public class Item{
        [Key]
        public string? id{get; set;}
        public string? shoppingcartId{get; set;}
        [ForeignKey("shoppingcartId")]
        public virtual ShoppingCart? ShoppingCart{get; set;}
        public Product? product{get; set;}
        public int quantity{get; set;}
        public double price{get; set;}
    }
}
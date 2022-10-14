using ShoppingCartService.Models;

namespace ShoppingCartService.Dtos{
    public class ShoppingCartCreateDto{
        public string? shoppingcartId{get; set;}
        public ICollection<Item>? items{get; set;}
        public string? purchaseId{get; set;}
    }
}
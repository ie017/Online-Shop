using ShoppingCartService.Models;

namespace ShoppingCartService.Dtos{
    public class ItemCreateDto{
        public string? id{get; set;}
        public Product? product{get; set;}
        public int quantity{get; set;}
        public double price{get; set;}
    }
}
using Microsoft.EntityFrameworkCore;
using ShoppingCartService.Models;

namespace ShoppingCartService.Data{
    public class ShoppingCartContext : DbContext{
        public DbSet<ShoppingCart> shoppingCarts{get; set;} = null!;
        public DbSet<Item> items{get; set;} = null!;
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options){
            
        }
    }
}
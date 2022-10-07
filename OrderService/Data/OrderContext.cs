using Microsoft.EntityFrameworkCore;
using OrderService.Models;
using OrderService.Models.Order;

namespace OrderService.Data{
    public class OrderContext : DbContext{
        public DbSet<Order> orders{get; set;} = null!;
        public DbSet<Bill> bills{get; set;} = null!;

        public OrderContext(DbContextOptions<OrderContext> options) : base(options){

        }
    }
}
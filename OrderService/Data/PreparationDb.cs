using Microsoft.EntityFrameworkCore;
using OrderService.Models.Order;

namespace OrderService.Data{
    public static class PreparationDb{
        public static void PrepOrders(IApplicationBuilder app, bool isPro){
            using( var services = app.ApplicationServices.CreateScope())
            {
                SeedData(services.ServiceProvider.GetService<OrderContext>()!, isPro);
            }
        }
        private static void SeedData(OrderContext context, bool isProd)
        {
            if(!context.orders.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.orders.AddRange(
                    new Order() {OrderId=Guid.NewGuid().ToString(), OrderDate = DateTime.Now, sum = 123},
                    new Order() {OrderId=Guid.NewGuid().ToString(), OrderDate = DateTime.Now,  sum = 526},
                    new Order() {OrderId=Guid.NewGuid().ToString(), OrderDate = DateTime.Now,  sum = 892}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
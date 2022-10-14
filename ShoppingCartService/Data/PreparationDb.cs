using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using ShoppingCartService.Models;

namespace ShoppingCartService.Data
{
    public static class PreparationDb
    {
        public static void PrepShoppingCart(IApplicationBuilder app, bool isPro)
        {
            using (var services = app.ApplicationServices.CreateScope())
            {
                SeedData(services.ServiceProvider.GetService<ShoppingCartContext>()!, isPro);
            }
        }
        private static void SeedData(ShoppingCartContext context, bool isProd)
        {

            Console.WriteLine("--> Migrate...");

            context.Database.Migrate();

            if (!context.shoppingCarts.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.shoppingCarts.AddRange(
                    new ShoppingCart() { shoppingcartId = Guid.NewGuid().ToString(), items = new List<Item>(), purchaseId = null },
                    new ShoppingCart() { shoppingcartId = Guid.NewGuid().ToString(), items = new List<Item>(), purchaseId = null },
                    new ShoppingCart() { shoppingcartId = Guid.NewGuid().ToString(), items = new List<Item>(), purchaseId = null }
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
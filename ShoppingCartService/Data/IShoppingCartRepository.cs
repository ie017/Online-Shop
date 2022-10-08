using ShoppingCartService.Models;

namespace ShoppingCartService.Data{
    public interface IShoppingCartRepository{
        bool SaveShoppingCart(ShoppingCart shoppingCart);
        IEnumerable<ShoppingCart> GetAllShoppingCart();
        ShoppingCart GetShoppingCart(string ShoppingCartId);
        bool DeleteShoppingCart(string ShoppingCartId);
        bool Update(string ShoppingCartId, Item item);
        bool Remove(string ShoppingCartId, string itemId);
        Order SetPurchase(string ShoppingCartId, Order order);
        bool SaveChange();
    }
}
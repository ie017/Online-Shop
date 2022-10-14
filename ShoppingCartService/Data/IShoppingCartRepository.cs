using ShoppingCartService.Models;

namespace ShoppingCartService.Data{
    public interface IShoppingCartRepository{
        bool SaveShoppingCart(ShoppingCart shoppingCart);
        IEnumerable<Item> GetAllItemsOfShoppingCart(string shoppingcartId);
        IEnumerable<ShoppingCart> GetAllShoppingCart();
        ShoppingCart GetShoppingCart(string ShoppingCartId);
        bool DeleteShoppingCart(string ShoppingCartId);
        bool AddItem(string ShoppingCartId, Item item);
        bool UpdateItem(string ShoppingCartId, Item item);
        bool RemoveItem(string ShoppingCartId, string itemId);
        void SetPurchase(string ShoppingCartId, Order order);
        void DeletePurchase(string ShoppingCartId);
        string GetPurchase(string ShoppingCartId);
        void SaveChange();
    }
}
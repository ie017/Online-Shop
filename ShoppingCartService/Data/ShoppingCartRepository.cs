using System.Collections.ObjectModel;
using ShoppingCartService.Exceptions;
using ShoppingCartService.Models;

namespace ShoppingCartService.Data{
    public class ShoppingCartRepository : IShoppingCartRepository{
        private readonly ShoppingCartContext _ShoppingCartContext;

        public ShoppingCartRepository(ShoppingCartContext shoppingCartContext){
            _ShoppingCartContext = shoppingCartContext; 
        }

        public bool DeleteShoppingCart(string ShoppingCartId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if(findShoppingCart != null){
                _ShoppingCartContext.shoppingCarts.Remove(findShoppingCart);
                SaveChange();
                return true;
            }
            else{
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public IEnumerable<ShoppingCart> GetAllShoppingCart()
        {
            return _ShoppingCartContext.shoppingCarts.ToList();
        }

        public ShoppingCart GetShoppingCart(string ShoppingCartId)
        {
           return _ShoppingCartContext.shoppingCarts.FirstOrDefault(ShoppingCart => ShoppingCart.shoppingcartId == ShoppingCartId)!;
        }

        public Order SetPurchase(string ShoppingCartId, Order order)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if(findShoppingCart != null){
                if(order != null){
                    findShoppingCart.purchase = order;
                    _ShoppingCartContext.shoppingCarts.Update(findShoppingCart);
                    SaveChange();
                    return order;
                }else {
                    throw new OrderNullReferenceException("Your Order doesn't exist");
                }
            }
            else{
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public bool Remove(string ShoppingCartId, string itemId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if(findShoppingCart != null){
                Item item = findShoppingCart.items!.FirstOrDefault(item => item.id == itemId)!;
                if(item != null){
                    findShoppingCart.items!.Remove(item);
                    _ShoppingCartContext.items.Remove(item);
                    _ShoppingCartContext.shoppingCarts.Update(findShoppingCart);
                    SaveChange();
                    return true;
                }else{
                    throw new ItemNotFoundException("Item Not Found");
                }
            }
            else{
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public bool SaveChange()
        {
           return (_ShoppingCartContext.SaveChanges() >= 0);
        }

        public bool SaveShoppingCart(ShoppingCart shoppingCart)
        {
            _ShoppingCartContext.shoppingCarts.Add(shoppingCart);
            SaveChange();
            return true;
        }

        public bool Update(string ShoppingCartId, Item item)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if(findShoppingCart != null){
                if(item != null){
                    findShoppingCart.items?.Add(item);
                    _ShoppingCartContext.items.Add(item);
                    _ShoppingCartContext.shoppingCarts.Update(findShoppingCart);
                    SaveChange();
                    return true;
                }else{
                    throw new ItemNullReferenceException("Your item doesn't exist");
                }
            }
            else{
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public IEnumerable<Item> GetAllItemsOfShoppingCart(string ShoppingCartId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if(findShoppingCart != null){
               return _ShoppingCartContext.items.Where(item => item.shoppingcartId == ShoppingCartId);
            }
            else{
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }
    }
}
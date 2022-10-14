using System.Collections.ObjectModel;
using ShoppingCartService.Dtos;
using ShoppingCartService.Exceptions;
using ShoppingCartService.Models;

namespace ShoppingCartService.Data
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingCartContext _ShoppingCartContext;

        public ShoppingCartRepository(ShoppingCartContext shoppingCartContext)
        {
            _ShoppingCartContext = shoppingCartContext;
        }

        public bool DeleteShoppingCart(string ShoppingCartId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                IEnumerable<Item> items = _ShoppingCartContext.items.ToList();
                foreach (Item item in items)
                {
                    if (item.shoppingcartId == findShoppingCart.shoppingcartId)
                    {
                        _ShoppingCartContext.items.Remove(item);
                        SaveChange();
                    }
                }
                _ShoppingCartContext.shoppingCarts.Remove(findShoppingCart);
                SaveChange();
                return true;
            }
            else
            {
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

        public void SetPurchase(string ShoppingCartId, Order order)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                if (order != null)
                {
                    findShoppingCart.purchaseId = order.OrderId;
                    _ShoppingCartContext.shoppingCarts.Update(findShoppingCart);
                    SaveChange();
                }
                else
                {
                    throw new OrderNullReferenceException("Your Order doesn't exist");
                }
            }
            else
            {
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public bool RemoveItem(string ShoppingCartId, string itemId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                Item item = _ShoppingCartContext.items.FirstOrDefault(i => i.id == itemId)!;
                _ShoppingCartContext.items.Remove(item);
                _ShoppingCartContext.shoppingCarts.Update(findShoppingCart);
                SaveChange();
                return true;
            }
            else
            {
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public void SaveChange()
        {
            _ShoppingCartContext.SaveChanges();
        }

        public bool SaveShoppingCart(ShoppingCart shoppingCart)
        {
            _ShoppingCartContext.shoppingCarts.Add(shoppingCart);
            SaveChange();
            return true;
        }

        public bool AddItem(string ShoppingCartId, Item item)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                Item item1 = _ShoppingCartContext.items.FirstOrDefault(i => i.productId == item.productId)!;
                if (item != null)
                {
                    if (item1 == null)
                    {
                        _ShoppingCartContext.items.Add(item);
                        _ShoppingCartContext.shoppingCarts.Update(findShoppingCart);
                        SaveChange();
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new ItemNullReferenceException("Please add new item");
                }
            }
            else
            {
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public IEnumerable<Item> GetAllItemsOfShoppingCart(string ShoppingCartId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                return _ShoppingCartContext.items.Where(item => item.shoppingcartId == ShoppingCartId);
            }
            else
            {
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public bool UpdateItem(string ShoppingCartId, Item item)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                _ShoppingCartContext.items.Update(item);
                SaveChange();
                return true;
            }
            else
            {
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public void DeletePurchase(string ShoppingCartId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                if(findShoppingCart.purchaseId != null){
                    findShoppingCart.purchaseId = null;
                    _ShoppingCartContext.shoppingCarts.Update(findShoppingCart);
                    SaveChange();
                }
            }
            else
            {
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }

        public string GetPurchase(string ShoppingCartId)
        {
            ShoppingCart findShoppingCart = GetShoppingCart(ShoppingCartId);
            if (findShoppingCart != null)
            {
                return findShoppingCart.purchaseId!;
            }
            else
            {
                throw new ShoppingCartNotFound("Shopping Cart Not Found");
            }
        }
    }
}
using System.Data;
namespace ShoppingCartService.Exceptions{
    public class ShoppingCartNotFound : DataException {
        public ShoppingCartNotFound(string message) : base(message){}
    }
}
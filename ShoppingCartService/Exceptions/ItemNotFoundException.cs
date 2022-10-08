using System.Data;

namespace ShoppingCartService.Exceptions{
    public class ItemNotFoundException : DataException{
        public ItemNotFoundException(string message) : base(message){}
    }
}
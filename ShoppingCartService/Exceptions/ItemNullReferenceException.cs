namespace ShoppingCartService.Exceptions{
    public class ItemNullReferenceException : NullReferenceException{
        public ItemNullReferenceException(string message) : base(message){}
    }
}
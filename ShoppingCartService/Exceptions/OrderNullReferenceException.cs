namespace ShoppingCartService.Exceptions{
    public class OrderNullReferenceException : NullReferenceException{
        public OrderNullReferenceException(string message) : base(message){}
    }
}
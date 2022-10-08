namespace ShoppingCartService.Models{
    public class Address{
        public string? id{get; set;}
        private string? street{get; set;}
        private string? streetNumber{get; set;}
        private long? zepCode{get; set;}
        private string? city{get; set;}
        private string? country{get; set;}
        private string? homePhone{get; set;}
        private string? type{get; set;}
    }
}
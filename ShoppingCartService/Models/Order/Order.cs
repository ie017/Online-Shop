using System.ComponentModel.DataAnnotations.Schema;
using ShoppingCartService.Enums;

namespace ShoppingCartService.Models{
        public class Order{
        public string? OrderId{get; set;}
        public DateTime OrderDate{get; set;}
        public double sum{get; set;}
        public string? billingId{get; set;}
        [ForeignKey("billingId")]
        public OrderStatus orderStatus{get; set;}
        public string? billingAddressId{get; set;}
        [ForeignKey("billingAddressId")]
        public virtual Address? billingAddress{get; set;}
        public string? deliveryAddressId{get; set;}
        [ForeignKey("deliveryAddressId")]
        public virtual Address? deliveryAddress{get; set;}

    }
}
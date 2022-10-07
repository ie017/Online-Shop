using System.ComponentModel.DataAnnotations.Schema;
using OrderService.Models;
using OrderService.Enums;

namespace OrderService.Dtos{
    public class OrderReadDto{
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
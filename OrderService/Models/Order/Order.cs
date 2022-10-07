using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderService.Enums;
using System.Text.Json.Serialization;

namespace OrderService.Models.Order{
    [Table("Order")]
    public class Order{
        [Key]
        public string? OrderId{get; set;}
        [Required]
        public DateTime OrderDate{get; set;}
        [Required]
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
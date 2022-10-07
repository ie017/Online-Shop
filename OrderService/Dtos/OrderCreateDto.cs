using System.ComponentModel.DataAnnotations.Schema;
using OrderService.Models;
using OrderService.Enums;

namespace OrderService.Dtos{
    public class OrderCreateDto{
        public string? OrderId{get; set;}
        public DateTime OrderDate{get; set;}
        public double sum{get; set;}
        public OrderStatus orderStatus{get; set;}
    }
}
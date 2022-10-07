using AutoMapper;
using OrderService.Dtos;
using OrderService.Models.Order;

namespace OrderService.Profiles{
    public class OrderProfile : Profile{
        public OrderProfile(){
            // Source -> Target
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
        }
    }
}
using AutoMapper;
using ShoppingCartService.Dtos;
using ShoppingCartService.Models;

namespace ShoppingCartService.Profiles{
    public class ShoppingCartProfile : Profile{
        public ShoppingCartProfile(){
            CreateMap<ShoppingCart, ShoppingCartReadDto>();
            CreateMap<ShoppingCartCreateDto, ShoppingCart>();
        }
    }
}
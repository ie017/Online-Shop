using AutoMapper;
using ShoppingCartService.Dtos;
using ShoppingCartService.Models;

namespace ShoppingCartService.Profiles{
    public class ItemProfile : Profile{
        public ItemProfile(){
            CreateMap<ItemCreateDto, Item>();
        }
    }
}
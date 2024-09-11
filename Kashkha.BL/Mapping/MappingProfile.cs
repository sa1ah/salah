using AutoMapper;
using Kashkha.DAL.Models;
using Kashkha.BL.DTOs;
using Kashkha.DAL;
using Kashkha.BL.DTOs.CartDTOs;

namespace Kashkha.BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Favorite, FavoriteDTO>().ReverseMap();
            CreateMap<CreateFavoriteDTO, Favorite>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>().ReverseMap();
        }

      
    }

   
}
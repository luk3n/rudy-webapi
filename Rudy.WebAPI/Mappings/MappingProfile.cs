using AutoMapper;
using Rudy.Models;
using Rudy.DTO;
using Rudy.Common.Data.Pagination;

namespace Rudy.WebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>(); // ???
            CreateMap<Client, CreateResponseDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ClientDTOEdit, Client>();
            CreateMap<PagedResults<Client>, PagedResults<ClientDTO>>();
            CreateMap<PagedResults<Product>, PagedResults<ProductDTO>>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}

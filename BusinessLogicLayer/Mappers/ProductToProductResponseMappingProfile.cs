using AutoMapper;
using eShop.DataAccessLayer.Entities;
using eShop.BusinessLogicLayer.DTO;

namespace eShop.BusinessLogicLayer.Mappers;

public class ProductToProductResponseMappingProfile : Profile
{
  public ProductToProductResponseMappingProfile()
  {
    CreateMap<Product, ProductResponse>()
      .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
      .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
      .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
      .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
      .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.ProductID))
      ;
  }
}

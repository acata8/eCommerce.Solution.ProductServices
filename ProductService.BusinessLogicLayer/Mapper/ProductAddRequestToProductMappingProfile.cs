using AutoMapper;
using eCommerce.BusinessLogicLayer.DTOs;
using eCommerce.DataAccessLayer.Entities;

namespace eCommerce.BusinessLogicLayer.Mapper;

public class ProductAddRequestToProductMappingProfile : Profile
{
    public ProductAddRequestToProductMappingProfile()
    {
        CreateMap<ProductAddRequest, Product>()
          .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
          .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
          .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
          .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
          .ForMember(dest => dest.ProductID, opt => opt.Ignore());
    }
}
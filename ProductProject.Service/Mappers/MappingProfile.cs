using AutoMapper;
using ProductsProject.Domain.Entities;
using ProductsProject.Service.DTOs.Product;
using ProductsProject.Service.DTOs.ProductImage;
using ProductsProject.Service.DTOs.ProductType;

namespace ProductsProject.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<Product, ProductForCreateDTOs>().ReverseMap();
            CreateMap<Product, ProductForViewDTOs>().ReverseMap();
            #endregion

            #region Product Type
            CreateMap<ProductType, ProductTypeForCreateDTOs>().ReverseMap();
            CreateMap<ProductType, ProductTypeForViewDTOs>().ReverseMap();
            #endregion

            #region Product Image
            CreateMap<ProductImage, ProductImageForCreatDTOs>().ReverseMap();
            CreateMap<ProductImage, ProductImageForViewDTOs>().ReverseMap();
            #endregion
        }
    }
}

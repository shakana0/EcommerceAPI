using AutoMapper;
using EcommerceAPI.Application.Categories.Commands.CreateCategory;
using EcommerceAPI.Application.Categories.Dtos;
using EcommerceAPI.Application.Products.Commands.CreateProduct;
using EcommerceAPI.Application.Products.Dtos;
using EcommerceAPI.Domain.Entities;



namespace EcommerceAPI.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Product
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductCommand, Product>();

            //Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}

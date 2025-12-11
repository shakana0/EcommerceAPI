using EcommerceAPI.Application.Categories.Dtos;

namespace EcommerceAPI.Application.Products.Dtos
{
    public record ProductDto(
     int Id,
     string Name,
     string Description,
     decimal Price,
     int StockQuantity,
     int CategoryId,
     CategoryDto Category
 );

}

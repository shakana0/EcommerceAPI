namespace EcommerceAPI.Application.Products.Dtos
{
    public record ProductDto(
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        int CategoryId
    );
}

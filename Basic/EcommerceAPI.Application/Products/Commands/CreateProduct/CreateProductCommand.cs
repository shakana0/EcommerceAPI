using MediatR;
using EcommerceAPI.Application.Products.Dtos;

namespace EcommerceAPI.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }

        public CreateProductCommand() { }

        public CreateProductCommand(string name, string description, decimal price, int stockQuantity, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
        }
    }
}

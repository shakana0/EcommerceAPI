using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Domain.Entities;

public class Product
{
    public int Id { get; private set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; private set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; private set; } = string.Empty;

    [Required]
    public decimal Price { get; private set; }

    public int StockQuantity { get; private set; }

    public int CategoryId { get; private set; }

    public Category Category { get; private set; } = null!;

    public Product() { }

    public Product(string name, string description, decimal price, int stockQuantity, int categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        CategoryId = categoryId;
    }

    public void UpdateDetails(string? name, string? description, decimal? price, int? stockQuantity, int? categoryId)
    {
        if (!string.IsNullOrWhiteSpace(name))
            Name = name;

        if (!string.IsNullOrWhiteSpace(description))
            Description = description;

        if (price.HasValue && price.Value > 0)
            Price = price.Value;

        if (stockQuantity.HasValue && stockQuantity.Value >= 0)
            StockQuantity = stockQuantity.Value;

        if (categoryId.HasValue && categoryId.Value > 0)
            CategoryId = categoryId.Value;
    }
}

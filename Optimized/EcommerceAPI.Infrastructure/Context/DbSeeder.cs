using Bogus;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public static class DbSeeder
{
    public static async Task SeedAsync(EcommerceApiDbContext context)
    {
        // Se till att databasen finns
        await context.Database.MigrateAsync();

        // Exempel: seeda kategorier om tomt
        if (!context.Categories.Any())
        {
            var categories = new List<Category>
            {
                new Category("Gaming Computers", "High-performance desktops and laptops for gaming"),
                new Category("Headphones & Audio", "Wired and wireless headphones, earbuds, speakers"),
                new Category("Smart Home Devices", "Smart bulbs, plugs, thermostats, assistants"),
                new Category("Mobile Accessories", "Chargers, cases, screen protectors, power banks"),
                new Category("Computer Peripherals", "Keyboards, mice, monitors, webcams, storage")
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }

        var categoriesList = context.Categories.ToList();

        if (!context.Products.Any())
        {
            var productFaker = new Faker<Product>()
                .CustomInstantiator(f =>
                {
                    var category = f.PickRandom(categoriesList);

                    decimal price;
                    int stock;

                    switch (category.Name)
                    {
                        case "Gaming Computers":
                            price = f.Random.Decimal(1000, 30000);
                            stock = f.Random.Int(1, 10);
                            break;
                        case "Headphones & Audio":
                            price = f.Random.Decimal(200, 2000);
                            stock = f.Random.Int(10, 50);
                            break;
                        case "Smart Home Devices":
                            price = f.Random.Decimal(300, 5000);
                            stock = f.Random.Int(5, 30);
                            break;
                        case "Mobile Accessories":
                            price = f.Random.Decimal(10, 200);
                            stock = f.Random.Int(50, 200);
                            break;
                        case "Computer Peripherals":
                            price = f.Random.Decimal(100, 3000);
                            stock = f.Random.Int(20, 100);
                            break;
                        default:
                            price = f.Random.Decimal(50, 500);
                            stock = f.Random.Int(1, 50);
                            break;
                    }

                    return new Product(
                        f.Commerce.ProductName(),
                        f.Commerce.ProductDescription(),
                        price,
                        stock,
                        category.Id
                    );
                });

            var products = productFaker.Generate(5000);
            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}

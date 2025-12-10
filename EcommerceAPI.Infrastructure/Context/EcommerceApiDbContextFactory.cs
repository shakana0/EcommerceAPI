using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EcommerceAPI.Infrastructure.Context
{
    public class EcommerceApiDbContextFactory : IDesignTimeDbContextFactory<EcommerceApiDbContext>
    {
        public EcommerceApiDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EcommerceAPI.WebAPI"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("EcommerceDb");

            var optionsBuilder = new DbContextOptionsBuilder<EcommerceApiDbContext>();
            optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    );
                });

            return new EcommerceApiDbContext(optionsBuilder.Options);
        }
    }
}

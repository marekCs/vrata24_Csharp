using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vrata24.Core.Entities;

namespace Vrata24.Infrastructure.Data
{
    public class StoreContextSeed
    {
        private readonly StoreContext _context;
        private readonly ILoggerFactory _loggerFactory;
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Vrata24.Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands != null)
                    {
                        foreach (var item in brands)
                        {
                            context.ProductBrands.Add(item);
                        }
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Vrata24.Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    if (types != null)
                    {
                        foreach (var item in types)
                        {
                            context.ProductTypes.Add(item);
                        }
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Vrata24.Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products != null)
                    {
                        foreach (var item in products)
                        {
                            context.Products.Add(item);
                        }
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
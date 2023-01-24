using Microsoft.EntityFrameworkCore;
using Vrata24.Core.Entities;
using Vrata24.Core.Interfaces;

namespace Vrata24.Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        return await _context.ProductBrands.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var result = await _context.Products
        .Include(p => p.ProductType)
        .Include(p => p.ProductBrand)
        .FirstOrDefaultAsync(p => p.Id == id);

        return result;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products
        .Include(p => p.ProductType)
        .Include(p => p.ProductBrand)
        .ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await _context.ProductTypes.ToListAsync();
    }
}
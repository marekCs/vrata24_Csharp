using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vrata24.Core.Entities;
using Vrata24.Infrastructure.Data;

namespace Vrata24.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly StoreContext _context;

    public ProductController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProduct(int id)
    {
        var result = await _context.Products.FindAsync(id);
        return result;
    }
}

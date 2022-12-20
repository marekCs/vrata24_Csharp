using Microsoft.EntityFrameworkCore;
using Vrata24.Core.Entities;

namespace Vrata24.Infrastructure.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}

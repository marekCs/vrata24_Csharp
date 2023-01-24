using Microsoft.EntityFrameworkCore;
using Vrata24.Api.Helpers;
using Vrata24.Core.Interfaces;
using Vrata24.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.AddAutoMapper(typeof(MappingProfiles));
    builder.Services.AddControllers();
    builder.Services.AddDbContext<StoreContext>(
        x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseStaticFiles();

    app.UseAuthorization();
    app.MapControllers();

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = services.GetRequiredService<StoreContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration.");
    }
}

app.Run();

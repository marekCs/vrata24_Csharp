using Microsoft.EntityFrameworkCore;
using Vrata24.Api.Extensions;
using Vrata24.Api.Helpers;
using Vrata24.Api.Middleware;
using Vrata24.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddAutoMapper(typeof(MappingProfiles));
    builder.Services.AddControllers();
    builder.Services.AddDbContext<StoreContext>(
        x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

    builder.Services.AddApplicationServices();
    builder.Services.AddSwaggerDocumentation();
}

var app = builder.Build();
{
    app.UseMiddleware<ExceptionMiddleware>();

    app.UseStatusCodePagesWithReExecute("/errors/{0}");

    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseStaticFiles();

    app.UseAuthorization();

    app.UseSwaggerDocumentation();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

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

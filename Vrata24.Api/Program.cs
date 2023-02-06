using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Vrata24.Api.Extensions;
using Vrata24.Api.Helpers;
using Vrata24.Api.Middleware;
using Vrata24.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddApplicationServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<ExceptionMiddleware>();

    app.UseStatusCodePagesWithReExecute("/errors/{0}");

    // UseSwagger() and UseSwaggerUI()
    app.UseSwaggerDocumentation();

    app.UseStaticFiles();

    app.UseCors("CorsPolicy");

    app.UseAuthorization();

    app.UseHttpsRedirection();

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

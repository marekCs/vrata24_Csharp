using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Vrata24.Api.Extensions;
using Vrata24.Api.Helpers;
using Vrata24.Api.Middleware;
using Vrata24.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
// builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
var app = builder.Build();
// Configure the http request pipeline
app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDocumentation();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseAuthentication();
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
    // var userManager = services.GetRequiredService<UserManager<AppUser>>();
    // var identityContext = services.GetRequiredService<AppIdentityDbContext>();
    // await identityContext.Database.MigrateAsync();
    // await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred during migration");
}
app.Run();

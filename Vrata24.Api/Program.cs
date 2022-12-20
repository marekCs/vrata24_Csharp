using Microsoft.EntityFrameworkCore;
using Vrata24.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddDbContext<StoreContext>(
        x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
    builder.Services.AddControllers();
}

var app = builder.Build();


{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

app.Run();

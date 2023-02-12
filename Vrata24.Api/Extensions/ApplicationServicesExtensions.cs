using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Vrata24.Api.Errors;
using Vrata24.Api.Helpers;
using Vrata24.Core.Interfaces;
using Vrata24.Infrastructure.Data;

namespace Vrata24.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddDbContext<StoreContext>(x =>
            x.UseSqlite(config.GetConnectionString("DefaultConnection")));
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            // services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            // services.AddScoped<ITokenService, TokenService>();
            // services.AddScoped<IOrderService, OrderService>();
            // services.AddScoped<IPaymentService, PaymentService>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
.Where(e => e.Value.Errors.Count > 0)
.SelectMany(x => x.Value.Errors)
.Select(x => x.ErrorMessage).ToArray();
        var errorResponse = new ApiValidationErrorResponse
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);
    };
            });
            return services;
        }
    }

}
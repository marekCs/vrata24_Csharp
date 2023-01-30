using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vrata24.Api.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Vrata24Api", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c
                .SwaggerEndpoint("/swagger/v1/swagger.json", "Vrata24Api v1");
            });

            return app;
        }
    }
}
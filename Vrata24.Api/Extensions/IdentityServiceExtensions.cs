using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vrata24.Api.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
IConfiguration config)
        {
            // services.AddDbContext<AppIdentityDbContext>(x =>
            // {
            //     x.UseSqlite(config.GetConnectionString("IdentityConnection"));
            // });
            // var builder = services.AddIdentityCore<AppUser>();
            // builder = new IdentityBuilder(builder.UserType, builder.Services);
            // builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            // builder.AddSignInManager<SignInManager<AppUser>>();
            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddJwtBearer(options =>
            // {
            //     options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
            //         ValidIssuer = config["Token:Issuer"],
            //         ValidateIssuer = true,
            //         ValidateAudience = false
            //     };
            // });
            // return services;
            throw new NotImplementedException();
        }
    }
}
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace QuizMaster.API.Extensions
{
    public static partial class ApplicationDependenciesConfiguration
    {
        public static IServiceCollection AddJwtAuthenticationAndAuthorization
            (this IServiceCollection services)
        {
            services
            .AddCors(options =>
            {
                options.AddPolicy("any", opts => opts.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
            });

            return services;
        }

        public static IServiceCollection AddJwtToken(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };

            });

            return builder.Services;
        }
    }
}

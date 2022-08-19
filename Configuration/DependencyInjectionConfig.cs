using Bravi.Backend.Data.Context;
using Bravi.Backend.Data.Repositories;
using Bravi.Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bravi.Backend.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddBraviServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BraviDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("LocalDb"));
        });

        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IContactMethodRepository, ContactMethodRepository>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
}
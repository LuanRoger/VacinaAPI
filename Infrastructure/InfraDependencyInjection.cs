using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlite("Data Source=./sqlite.db;"));
        services.AddScoped<IPostosRepository, PostosRepository>();
        services.AddScoped<IVacinasRepository, VacinasRepository>();

        return services;
    }
}
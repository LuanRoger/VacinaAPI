using VacinaAPI.Mappers;
using VacinaAPI.Vacinas.Handlers;

namespace VacinaAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VacinaModelMapper), typeof(CreateVascinaRequestMapper));
        services.AddScoped<GetVacinasHandlers>();
        services.AddScoped<PostVacinasHandlers>();
        services.AddScoped<DeleteVacinasHandlers>();

        return services;
    }
}
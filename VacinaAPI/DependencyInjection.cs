using VacinaAPI.Mappers;

namespace VacinaAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VacinaModelMapper));

        return services;
    }
}
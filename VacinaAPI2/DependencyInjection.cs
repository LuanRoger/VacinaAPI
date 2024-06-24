using VacinaAPI2.Mappers;

namespace VacinaAPI2;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VacinaModelMapper));

        return services;
    }
}
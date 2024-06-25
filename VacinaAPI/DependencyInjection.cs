using VacinaAPI.Mappers;
using VacinaAPI.PostoVacinacao.Handlers;
using VacinaAPI.Vacinas.Handlers;

namespace VacinaAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VacinaModelMapper), typeof(CreateVascinaRequestMapper), 
            typeof(PostoVacinacaoModelMapper), typeof(CreatePostoVascinacaoRequestMapper));
        
        services.AddScoped<GetVacinasHandlers>();
        services.AddScoped<PostVacinasHandlers>();
        services.AddScoped<DeleteVacinasHandlers>();
        services.AddScoped<PutVacinasHandlers>();

        services.AddScoped<GetPostosVacinacaoHandler>();
        services.AddScoped<PostPostosVacinacaoHandler>();
        services.AddScoped<PutPostosVacinacaoHandler>();
        services.AddScoped<DeletePostoVacinacaoHandler>();

        return services;
    }
}
using Application.PostoVacinacao.Entities;
using Application.PostoVacinacao.Handlers;
using Application.PostoVacinacao.Mappers;
using Application.PostoVacinacao.Validations;
using Application.Vacinas.Entities;
using Application.Vacinas.Handlers;
using Application.Vacinas.Mappers;
using Application.Vacinas.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class AppDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VacinaModelMapper), typeof(CreateVascinaRequestMapper), 
            typeof(PostoVacinacaoModelMapper), typeof(CreatePostoVascinacaoRequestMapper));
        
        services.AddScoped<IValidator<CreatePostoVacinacaoRequest>, CreatePostoVacinacaoRequestValidator>();
        services.AddScoped<IValidator<CreateVacinaRequest>, CreateVacinaRequestValidator>();
        services.AddScoped<IValidator<UpdatePostoVacinacaoRequest>, UpdatePostoVacinacaoRequestValidator>();
        services.AddScoped<IValidator<UpdateVacinaByIdRequest>, UpdateVacinaByIdRequestValidator>();
        
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
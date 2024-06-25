﻿namespace VacinaAPI.PostoVacinacao;

public static class PostosVacinacaoEndpoints
{
    public static IEndpointRouteBuilder MapPostosVacinacaoEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/{id:int}", GetPostoVacinacao.GetPostoById);
        builder.MapGet("/{name:required}", GetPostoVacinacao.GetPostoByName);

        builder.MapPost("/", PostPostoVacinacao.PostPosto);

        builder.MapPut("/", PutPostoVacinacao.PutPosto);
        
        builder.MapDelete("/{id:int}", DeletePostoVacinacao.DeletePostoById);
        builder.MapDelete("/nome/{name:required}", DeletePostoVacinacao.DeletePostoByName);
        
        return builder;
    }
}
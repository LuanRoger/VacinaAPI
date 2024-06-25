using Application.Exceptions;
using Application.PostoVacinacao.Entities;
using Application.PostoVacinacao.Handlers;
using Microsoft.AspNetCore.Mvc;
using VacinaAPI.Exceptions;

namespace VacinaAPI.Endpoints.PostosVacinacao;

public static class PostPostoVacinacao
{
    public async static Task<IResult> PostPosto(
        HttpContext _,
        [FromBody] CreatePostoVacinacaoRequest request,
        [FromServices] PostPostosVacinacaoHandler handler)
    {
        PostoVacinacao posto;
        try
        {
            posto = await handler.PostPosto(request);   
        }
        catch (Exception e) when (e is SameNameException or ValidationException)
        { return Results.BadRequest(e.Message); }

        return Results.Created($"/postos/{posto.id}", posto);
    }
}
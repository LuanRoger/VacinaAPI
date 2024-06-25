using Application.PostoVacinacao.Entities;
using Application.PostoVacinacao.Handlers;
using Microsoft.AspNetCore.Mvc;
using VacinaAPI.Exceptions;

namespace VacinaAPI.Endpoints.PostosVacinacao;

public static class PutPostoVacinacao
{
    public async static Task<IResult> PutPosto(
        HttpContext _,
        [FromBody] UpdatePostoVacinacaoRequest request,
        [FromServices] PutPostosVacinacaoHandler handler)
    {
        PostoNVacina? posto;
        try
        {
            posto = await handler.PutPosto(request);
        }
        catch (SameNameException e) { return Results.BadRequest(e.Message); }

        return posto is not null ? Results.Ok(posto) : Results.NotFound();
    }
}
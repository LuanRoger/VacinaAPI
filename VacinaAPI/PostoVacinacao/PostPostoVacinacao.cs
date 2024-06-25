using Microsoft.AspNetCore.Mvc;
using VacinaAPI.Exceptions;
using VacinaAPI.PostoVacinacao.Entities;
using VacinaAPI.PostoVacinacao.Handlers;

namespace VacinaAPI.PostoVacinacao;

public static class PostPostoVacinacao
{
    public async static Task<IResult> PostPosto(
        HttpContext _,
        [FromBody] CreatePostoVacinacaoRequest request,
        [FromServices] PostPostosVacinacaoHandler handler)
    {
        Entities.PostoVacinacao posto;
        try
        {
            posto = await handler.PostPosto(request);   
        }
        catch (SameNameException e) { return Results.BadRequest(e.Message); }

        return Results.Created($"/postos/{posto.id}", posto);
    }
}
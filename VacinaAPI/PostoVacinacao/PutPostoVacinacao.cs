using Microsoft.AspNetCore.Mvc;
using VacinaAPI.PostoVacinacao.Entities;
using VacinaAPI.PostoVacinacao.Handlers;

namespace VacinaAPI.PostoVacinacao;

public static class PutPostoVacinacao
{
    public async static Task<IResult> PutPosto(
        HttpContext _,
        [FromBody] UpdatePostoVacinacaoRequest request,
        [FromServices] PutPostosVacinacaoHandler handler)
    {
        Entities.PostoVacinacao? posto = await handler.PutPosto(request);

        return posto is not null ? Results.Ok(posto) : Results.NotFound();
    }
}
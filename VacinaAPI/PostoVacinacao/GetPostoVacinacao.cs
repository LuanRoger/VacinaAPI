using Microsoft.AspNetCore.Mvc;
using VacinaAPI.PostoVacinacao.Handlers;

namespace VacinaAPI.PostoVacinacao;

public static class GetPostoVacinacao
{
    public async static Task<IResult> GetPostoById(
        HttpContext _,
        [FromRoute] int id,
        [FromServices] GetPostosVacinacaoHandler handler)
    {
        Entities.PostoVacinacao? posto = await handler.GetPostoById(id);

        return posto is not null ? Results.Ok(posto) : Results.NotFound();
    }

    public async static Task<IResult> GetPostoByName(
        HttpContext _,
        [FromRoute] string name,
        [FromServices] GetPostosVacinacaoHandler handler)
    {
        Entities.PostoVacinacao? posto = await handler.GetPostoByName(name);

        return posto is not null ? Results.Ok(posto) : Results.NotFound();
    }
}
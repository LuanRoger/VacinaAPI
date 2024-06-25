using Application.PostoVacinacao.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace VacinaAPI.Endpoints.PostosVacinacao;

public static class GetPostoVacinacao
{
    public async static Task<IResult> GetAllPostos(
        [FromServices] GetPostosVacinacaoHandler handlers)
    {
        var postos = await handlers.GetAllPostos();

        return Results.Ok(postos);
    }
    
    public async static Task<IResult> GetPostoById(
        HttpContext _,
        [FromRoute] int id,
        [FromServices] GetPostosVacinacaoHandler handlers)
    {
        Application.PostoVacinacao.Entities.PostoVacinacao? posto = await handlers.GetPostoById(id);

        return posto is not null ? Results.Ok(posto) : Results.NotFound();
    }

    public async static Task<IResult> GetPostoByName(
        HttpContext _,
        [FromRoute] string name,
        [FromServices] GetPostosVacinacaoHandler handlers)
    {
        Application.PostoVacinacao.Entities.PostoVacinacao? posto = await handlers.GetPostoByName(name);

        return posto is not null ? Results.Ok(posto) : Results.NotFound();
    }
}
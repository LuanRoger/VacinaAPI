using Microsoft.AspNetCore.Mvc;
using VacinaAPI.PostoVacinacao.Handlers;

namespace VacinaAPI.PostoVacinacao;

public static class DeletePostoVacinacao
{
    public async static Task<IResult> DeletePostoById(
        HttpContext _,
        [FromRoute] int id,
        [FromServices] DeletePostoVacinacaoHandler handler)
    {
        int? deletedId = await handler.DeletePostoById(id);

        return deletedId is not null ? Results.Ok(deletedId) : Results.NotFound();
    }
    
    public async static Task<IResult> DeletePostoByName(
        HttpContext _,
        [FromRoute] string name,
        [FromServices] DeletePostoVacinacaoHandler handler)
    {
        int? deletedId = await handler.DeletePostoByName(name);

        return deletedId is not null ? Results.Ok(deletedId) : Results.NotFound();
    }
}
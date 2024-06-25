using Application.PostoVacinacao.Handlers;
using Microsoft.AspNetCore.Mvc;
using VacinaAPI.Exceptions;

namespace VacinaAPI.Endpoints.PostosVacinacao;

public static class DeletePostoVacinacao
{
    public async static Task<IResult> DeletePostoById(
        HttpContext _,
        [FromRoute] int id,
        [FromServices] DeletePostoVacinacaoHandler handler)
    {
        int? deletedId;
        try
        {
            deletedId = await handler.DeletePostoById(id);
        }
        catch (CantDeleteRelationException e)
        {
            return Results.BadRequest(e.Message);
        }
        

        return deletedId is not null ? Results.Ok(deletedId) : Results.NotFound();
    }
    
    public async static Task<IResult> DeletePostoByName(
        HttpContext _,
        [FromRoute] string name,
        [FromServices] DeletePostoVacinacaoHandler handler)
    {
        int? deletedId;
        try
        {
            deletedId = await handler.DeletePostoByName(name);
        }
        catch(CantDeleteRelationException e)
        {
            return Results.BadRequest(e.Message);
        }

        return deletedId is not null ? Results.Ok(deletedId) : Results.NotFound();
    }
}
using Microsoft.AspNetCore.Mvc;
using VacinaAPI.Vacinas.Handlers;

namespace VacinaAPI.Vacinas;

public static class DeleteVacinas
{
    public async static Task<IResult> DeleteVacinaById(
        HttpContext _,
        [FromRoute] int id,
        [FromServices] DeleteVacinasHandlers handlers)
    {
        int? deletedVacinaId = await handlers.DeleteVacinaById(id);

        return deletedVacinaId is not null ? Results.Ok(deletedVacinaId) : Results.NotFound();
    }
    
    public async static Task<IResult> DeleteVacinaByLote(
        HttpContext _,
        [FromRoute] string lote,
        [FromServices] DeleteVacinasHandlers handlers)
    {
        string? deletedVacinaLote = await handlers.DeleteVacinaByLote(lote);

        return deletedVacinaLote is not null ? Results.Ok(deletedVacinaLote) : Results.NotFound();
    }
}
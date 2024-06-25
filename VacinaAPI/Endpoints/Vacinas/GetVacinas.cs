using Application.Vacinas.Entities;
using Application.Vacinas.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace VacinaAPI.Endpoints.Vacinas;

public static class GetVacinas
{
    public async static Task<IResult> GetPostoVacinas(
        HttpContext _,
        [FromRoute] int id,
        [FromServices] GetVacinasHandlers handlers)
    {
        var vacinasPosto = await handlers.GetPostoVacinas(id);
        
        return vacinasPosto is not null ? Results.Ok(vacinasPosto) : Results.NotFound();

    }
    public async static Task<IResult> GetVacinasById(
        HttpContext _,
        [FromRoute] int id,
        [FromServices] GetVacinasHandlers handlers)
    {
        Vacina? vacina = await handlers.GetVacinaById(id);
        
        return vacina is not null ? Results.Ok(vacina) : Results.NotFound();
    }
    public async static Task<IResult> GetVacinasByFabricante(
        HttpContext _,
        [FromRoute] string fabricante,
        [FromServices] GetVacinasHandlers handlers)
    {
        var vacinas = await handlers.GetVacinasByFabricante(fabricante);
        
        return vacinas is not null ? Results.Ok(vacinas) : Results.NotFound();
    }
    public async static Task<IResult> GetVacinasByLote(
        HttpContext _,
        [FromRoute] string lote,
        [FromServices] GetVacinasHandlers handlers)
    {
        Vacina? vacina = await handlers.GetVacinasByLote(lote);

        return vacina is not null ? Results.Ok(vacina) : Results.NotFound();
    }
}
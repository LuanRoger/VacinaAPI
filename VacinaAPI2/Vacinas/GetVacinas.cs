using Microsoft.AspNetCore.Mvc;
using VacinaAPI2.Vacinas.Entities;

namespace VacinaAPI2.Vacinas;

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
    /*public static Task<IResult> GetVacinasByFabricante(string fabricante)
    {
        
    }
    public static Task<IResult> GetVacinasByLote(string lote)
    {
        
    }*/
}
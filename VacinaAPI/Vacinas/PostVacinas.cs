using Microsoft.AspNetCore.Mvc;
using VacinaAPI.Vacinas.Entities;
using VacinaAPI.Vacinas.Handlers;

namespace VacinaAPI.Vacinas;

public static class PostVacinas
{
    public async static Task<IResult> PostVacina(
        HttpContext _,
        [FromBody] CreateVacinaRequest request,
        [FromServices] PostVacinasHandlers handlers)
    {
        Vacina vacina = await handlers.PostVacina(request);
        
        return Results.Created($"/vacinas/{vacina.id}", vacina);
    }
}
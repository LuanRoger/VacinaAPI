using Application.Vacinas.Entities;
using Application.Vacinas.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace VacinaAPI.Endpoints.Vacinas;

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
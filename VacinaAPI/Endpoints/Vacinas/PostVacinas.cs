using Application.Exceptions;
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
        Vacina vacina;

        try
        {
            vacina = await handlers.PostVacina(request);
        }
        catch (ValidationException e) { return Results.BadRequest(e.Message); }
        catch (NotFoundException e) { return Results.NotFound(e.Message); }
        catch (ResourceConflictException e) { return Results.Conflict(e.Message); }
        
        return Results.Created($"/vacinas/{vacina.id}", vacina);
    }
}
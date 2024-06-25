using Application.Exceptions;
using Application.Vacinas.Entities;
using Application.Vacinas.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace VacinaAPI.Endpoints.Vacinas;

public static class PutVacinas
{
    public async static Task<IResult> PutVacinaById(
        HttpContext _,
        [FromBody] UpdateVacinaByIdRequest request,
        [FromServices] PutVacinasHandlers handlers)
    {
        Vacina? vacina;
        try
        {
            vacina = await handlers.UpdateVacinaById(request);
        }
        catch(ValidationException e) { return Results.BadRequest(e.Message); }

        return vacina is not null ? Results.Ok(vacina) : Results.NotFound();
    }
}
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
        Vacina? vacina = await handlers.UpdateVacinaById(request);

        return vacina is not null ? Results.Ok(vacina) : Results.NotFound();
    }
}
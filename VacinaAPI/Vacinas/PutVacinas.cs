using Microsoft.AspNetCore.Mvc;
using VacinaAPI.Vacinas.Entities;
using VacinaAPI.Vacinas.Handlers;

namespace VacinaAPI.Vacinas;

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
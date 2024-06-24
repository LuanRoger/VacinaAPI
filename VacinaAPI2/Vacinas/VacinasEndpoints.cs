namespace VacinaAPI2.Vacinas;

public static class VacinasEndpoints
{
    public static IEndpointRouteBuilder MapVacinasEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/posto/{id:int}", GetVacinas.GetPostoVacinas);
        endpoints.MapGet("/{id:int}", GetVacinas.GetVacinasById);
        //endpoints.MapGet("/vacinas/fabricante/{fabricante}", GetVacinas.GetVacinasByFabricante);
        //endpoints.MapGet("/vacinas/lote/{lote}", GetVacinas.GetVacinasByLote);
        return endpoints;
    }
}
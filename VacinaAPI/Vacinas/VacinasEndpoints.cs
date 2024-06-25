namespace VacinaAPI.Vacinas;

public static class VacinasEndpoints
{
    public static IEndpointRouteBuilder MapVacinasEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("posto/{id:int}", GetVacinas.GetPostoVacinas);
        endpoints.MapGet("{id:int}", GetVacinas.GetVacinasById);
        endpoints.MapGet("fabricante/{fabricante:required}", GetVacinas.GetVacinasByFabricante);
        endpoints.MapGet("lote/{lote:required}", GetVacinas.GetVacinasByLote);

        endpoints.MapPost("/", PostVacinas.PostVacina);

        endpoints.MapPut("/", PutVacinas.PutVacinaById);
        
        endpoints.MapDelete("/{id:int}", DeleteVacinas.DeleteVacinaById);
        endpoints.MapDelete("/lote/{lote:required}", DeleteVacinas.DeleteVacinaByLote);
        
        return endpoints;
    }
}
namespace VacinaAPI.Endpoints.Vacinas;

public static class VacinasEndpoints
{
    public static IEndpointRouteBuilder MapVacinasEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("posto/{id:int}", GetVacinas.GetPostoVacinas);
        builder.MapGet("{id:int}", GetVacinas.GetVacinasById);
        builder.MapGet("lote/{lote:required}", GetVacinas.GetVacinasByLote);

        builder.MapPost("/", PostVacinas.PostVacina);
        builder.MapPut("/", PutVacinas.PutVacinaById);
        
        builder.MapDelete("/{id:int}", DeleteVacinas.DeleteVacinaById);
        builder.MapDelete("/lote/{lote:required}", DeleteVacinas.DeleteVacinaByLote);
        
        return builder;
    }
}
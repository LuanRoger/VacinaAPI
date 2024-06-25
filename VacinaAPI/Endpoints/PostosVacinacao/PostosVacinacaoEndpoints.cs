namespace VacinaAPI.Endpoints.PostosVacinacao;

public static class PostosVacinacaoEndpoints
{
    public static IEndpointRouteBuilder MapPostosVacinacaoEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", GetPostoVacinacao.GetAllPostos);
        builder.MapGet("/id/{id:int}", GetPostoVacinacao.GetPostoById);

        builder.MapPost("/", PostPostoVacinacao.PostPosto);
        
        builder.MapPut("/", PutPostoVacinacao.PutPosto);
        
        builder.MapDelete("/{id:int}", DeletePostoVacinacao.DeletePostoById);
        builder.MapDelete("/nome/{name:required}", DeletePostoVacinacao.DeletePostoByName);
        
        return builder;
    }
}
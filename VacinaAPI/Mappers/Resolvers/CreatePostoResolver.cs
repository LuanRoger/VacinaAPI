using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.PostoVacinacao.Entities;

namespace VacinaAPI.Mappers.Resolvers;

public class CreatePostoResolver : ITypeConverter<CreatePostoVacinacaoRequest, PostoVacinacaoModel>
{
    public PostoVacinacaoModel Convert(CreatePostoVacinacaoRequest source, PostoVacinacaoModel destination,
        ResolutionContext context)
    {
        return new()
        {
            name = source.nome
        };
    }
}
using Application.PostoVacinacao.Entities;
using AutoMapper;
using Infrastructure.Models;

namespace Application.PostoVacinacao.Mappers.Resolvers;

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
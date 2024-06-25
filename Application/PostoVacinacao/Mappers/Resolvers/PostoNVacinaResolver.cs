using Application.PostoVacinacao.Entities;
using AutoMapper;
using Infrastructure.Models;

namespace Application.PostoVacinacao.Mappers.Resolvers;

public class PostoNVacinaResolver : ITypeConverter<PostoVacinacaoModel, PostoNVacina>
{
    public PostoNVacina Convert(PostoVacinacaoModel source, PostoNVacina destination, ResolutionContext context)
    {
        return new(source.id, source.name);
    }
}
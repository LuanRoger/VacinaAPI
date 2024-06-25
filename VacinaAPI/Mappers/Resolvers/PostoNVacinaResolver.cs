using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.PostoVacinacao.Entities;

namespace VacinaAPI.Mappers.Resolvers;

public class PostoNVacinaResolver : ITypeConverter<PostoVacinacaoModel, PostoNVacina>
{
    public PostoNVacina Convert(PostoVacinacaoModel source, PostoNVacina destination, ResolutionContext context)
    {
        return new(source.id, source.name);
    }
}
using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.Mappers.Resolvers;

namespace VacinaAPI.Mappers;

public class PostoVacinacaoModelMapper : Profile
{
    public PostoVacinacaoModelMapper()
    {
        CreateMap<PostoVacinacaoModel, PostoVacinacao.Entities.PostoVacinacao>()
            .ConvertUsing<PostoVacinacaoResolver>();
    }
}
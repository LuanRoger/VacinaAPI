using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.Mappers.Resolvers;
using VacinaAPI.PostoVacinacao.Entities;

namespace VacinaAPI.Mappers;

public class PostoVacinacaoModelMapper : Profile
{
    public PostoVacinacaoModelMapper()
    {
        CreateMap<PostoVacinacaoModel, PostoVacinacao.Entities.PostoVacinacao>()
            .ConvertUsing<PostoVacinacaoResolver>();
        CreateMap<PostoVacinacaoModel, PostoNVacina>()
            .ConvertUsing<PostoNVacinaResolver>();
    }
}
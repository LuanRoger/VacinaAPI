using Application.PostoVacinacao.Entities;
using Application.PostoVacinacao.Mappers.Resolvers;
using AutoMapper;
using Infrastructure.Models;

namespace Application.PostoVacinacao.Mappers;

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
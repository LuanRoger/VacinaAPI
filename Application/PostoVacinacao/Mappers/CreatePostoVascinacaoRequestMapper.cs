using Application.PostoVacinacao.Entities;
using Application.PostoVacinacao.Mappers.Resolvers;
using AutoMapper;

namespace Application.PostoVacinacao.Mappers;

public class CreatePostoVascinacaoRequestMapper : Profile
{
    public CreatePostoVascinacaoRequestMapper()
    {
        CreateMap<CreatePostoVacinacaoRequest, Infrastructure.Models.PostoVacinacaoModel>()
            .ConvertUsing<CreatePostoResolver>();
    }
}
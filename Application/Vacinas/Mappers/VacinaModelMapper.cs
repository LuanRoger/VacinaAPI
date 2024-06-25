using Application.Vacinas.Entities;
using Application.Vacinas.Mappers.Resolvers;
using AutoMapper;
using Infrastructure.Models;

namespace Application.Vacinas.Mappers;

public class VacinaModelMapper : Profile
{
    public VacinaModelMapper()
    {
        CreateMap<VacinaModel, Vacina>()
            .ConvertUsing<VacinaModelResolver>();
    }
}
using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.Mappers.Resolvers;
using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.Mappers;

public class VacinaModelMapper : Profile
{
    public VacinaModelMapper()
    {
        CreateMap<VacinaModel, Vacina>()
            .ConvertUsing<VacinaModelResolver>();
    }
}
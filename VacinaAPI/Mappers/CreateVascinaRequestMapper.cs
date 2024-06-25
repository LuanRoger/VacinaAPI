using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.Mappers.Resolvers;
using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.Mappers;

public class CreateVascinaRequestMapper : Profile
{
    public CreateVascinaRequestMapper()
    {
        CreateMap<CreateVacinaRequest, VacinaModel>()
            .ConvertUsing<CreateVacinaResolver>();
    }
}
using Application.Vacinas.Entities;
using Application.Vacinas.Mappers.Resolvers;
using AutoMapper;
using Infrastructure.Models;

namespace Application.Vacinas.Mappers;

public class CreateVascinaRequestMapper : Profile
{
    public CreateVascinaRequestMapper()
    {
        CreateMap<CreateVacinaRequest, VacinaModel>()
            .ConvertUsing<CreateVacinaResolver>();
    }
}
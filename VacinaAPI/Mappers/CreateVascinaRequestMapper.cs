using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.Mappers;

public class CreateVascinaRequestMapper : Profile
{
    public CreateVascinaRequestMapper()
    {
        CreateMap<CreateVacinaRequest, VacinaModel>()
            .ForMember(f => f.postoVacinacaoId,
                m => m
                    .MapFrom(x => x.idPosto));
    }
}
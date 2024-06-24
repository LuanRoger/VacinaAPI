using AutoMapper;
using Infrastructure.Models;
using VacinaAPI2.Vacinas.Entities;

namespace VacinaAPI2.Mappers;

public class VacinaModelMapper : Profile
{
    public VacinaModelMapper()
    {
        CreateMap<VacinaModel, Vacina>();
    }
}
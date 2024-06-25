using AutoMapper;
using Infrastructure.Models;
using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.Mappers;

public class VacinaModelMapper : Profile
{
    public VacinaModelMapper()
    {
        CreateMap<VacinaModel, Vacina>();
        CreateMap<Vacina, VacinaModel>();
    }
}
using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.Vacinas;

public class GetVacinasHandlers
{
    private readonly IVacinasRepository _vacinasRepository;
    private readonly IMapper _mapper;
    
    public GetVacinasHandlers(IVacinasRepository vacinasRepository, IMapper mapper)
    {
        _vacinasRepository = vacinasRepository;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyList<Vacina>?> GetPostoVacinas(int id)
    {
        var vacinas = await _vacinasRepository.GetPostoVacinas(id);
        if (vacinas is null)
            return null;
        
        var vacinasRead = vacinas.Select(_mapper.Map<Vacina>)
            .ToList();
        return vacinasRead;
    }
    
    public async Task<Vacina?> GetVacinaById(int id)
    {
        VacinaModel? vacina = await _vacinasRepository.GetVacinaById(id);

        if (vacina is null)
            return null;
        
        return _mapper.Map<Vacina>(vacina);
    }
}
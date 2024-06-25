using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.Vacinas.Handlers;

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
        
        Vacina vacinaRead = _mapper.Map<Vacina>(vacina);
        return vacinaRead;
    }

    public async Task<IReadOnlyList<Vacina>?> GetVacinasByFabricante(string fabricante)
    {
        var vacinas = await _vacinasRepository.GetVacinasByFabricante(fabricante);
        if (vacinas is null)
            return null;
        
        var vacinasRead = vacinas.Select(_mapper.Map<Vacina>)
            .ToList();
        return vacinasRead;
    }

    public async Task<Vacina?> GetVacinasByLote(string lote)
    {
        VacinaModel? vacina = await _vacinasRepository.GetVacinaByLote(lote);
        if (vacina is null)
            return null;
        
        Vacina? vacinaRead = _mapper.Map<Vacina>(vacina);
        return vacinaRead;
    }
}
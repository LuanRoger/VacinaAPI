using AutoMapper;
using Infrastructure.Repositories;

namespace VacinaAPI.Vacinas.Handlers;

public class DeleteVacinasHandlers
{
    private readonly IVacinasRepository _vacinasRepository;
    private readonly IMapper _mapper;

    public DeleteVacinasHandlers(IVacinasRepository vacinasRepository, IMapper mapper)
    {
        _vacinasRepository = vacinasRepository;
        _mapper = mapper;
    }
    
    public async Task<int?> DeleteVacinaById(int id)
    {
        int? deletedVacina = await _vacinasRepository.DeleteVacinaById(id);
        if (deletedVacina is null)
            return null;
        
        await _vacinasRepository.FlushChanges();
        return deletedVacina.Value;
    }
    
    public async Task<string?> DeleteVacinaByLote(string lote)
    {
        string? deletedVacina = await _vacinasRepository.DeleteVacinaByLote(lote);
        if (deletedVacina is null)
            return null;
        
        await _vacinasRepository.FlushChanges();
        return deletedVacina;
    }
}
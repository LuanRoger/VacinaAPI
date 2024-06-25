using Infrastructure.Repositories;

namespace Application.Vacinas.Handlers;

public class DeleteVacinasHandlers
{
    private readonly IVacinasRepository _vacinasRepository;

    public DeleteVacinasHandlers(IVacinasRepository vacinasRepository)
    {
        _vacinasRepository = vacinasRepository;
    }
    
    public async Task<int?> DeleteVacinaById(int id)
    {
        int? deletedVacina = await _vacinasRepository.DeleteVacinaById(id);
        if (deletedVacina is null)
            return null;
        
        await _vacinasRepository.FlushChanges();
        return deletedVacina.Value;
    }
    
    public async Task<int?> DeleteVacinaByLote(string lote)
    {
        int? deletedVacina = await _vacinasRepository.DeleteVacinaByLote(lote);
        if (deletedVacina is null)
            return null;
        
        await _vacinasRepository.FlushChanges();
        return deletedVacina;
    }
}
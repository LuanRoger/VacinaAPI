using Infrastructure.Repositories;
using VacinaAPI.Exceptions;

namespace VacinaAPI.PostoVacinacao.Handlers;

public class DeletePostoVacinacaoHandler
{
    private readonly IPostosRepository _postosRepository;
    
    public DeletePostoVacinacaoHandler(IPostosRepository postosRepository)
    {
        _postosRepository = postosRepository;
    }
    
    public async Task<int?> DeletePostoById(int id)
    {
        bool hasVacinas = await _postosRepository.HasVacinasRelatedById(id);
        if (hasVacinas)
            throw new CantDeleteRelationException("Posto", "Vacina");
        
        int? deletedId = await _postosRepository.DeletePostoById(id);
        await _postosRepository.FlushChanges();
        
        return deletedId;
    }
    
    public async Task<int?> DeletePostoByName(string name)
    {
        bool hasVacinas = await _postosRepository.HasVacinasRelatedByName(name);
        if (hasVacinas)
            throw new CantDeleteRelationException("Posto", "Vacina");
        
        int? deletedId = await _postosRepository.DeletePostoByName(name);
        await _postosRepository.FlushChanges();
        
        return deletedId;
    }
}
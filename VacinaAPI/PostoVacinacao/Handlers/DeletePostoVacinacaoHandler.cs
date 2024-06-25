using AutoMapper;
using Infrastructure.Repositories;

namespace VacinaAPI.PostoVacinacao.Handlers;

public class DeletePostoVacinacaoHandler
{
    private readonly IPostosRepository _postosRepository;
    private readonly IMapper _mapper;
    
    public DeletePostoVacinacaoHandler(IPostosRepository postosRepository, IMapper mapper)
    {
        _postosRepository = postosRepository;
        _mapper = mapper;
    }
    
    public async Task<int?> DeletePostoById(int id)
    {
        int? deletedId = await _postosRepository.DeletePostoById(id);
        await _postosRepository.FlushChanges();
        
        return deletedId;
    }
    
    public async Task<int?> DeletePostoByName(string name)
    {
        int? deletedId = await _postosRepository.DeletePostoByName(name);
        await _postosRepository.FlushChanges();
        
        return deletedId;
    }
}
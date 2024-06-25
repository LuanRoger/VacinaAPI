using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.PostoVacinacao.Entities;

namespace VacinaAPI.PostoVacinacao.Handlers;

public class PutPostosVacinacaoHandler
{
    private readonly IPostosRepository _postosRepository;
    private readonly IMapper _mapper;
    
    public PutPostosVacinacaoHandler(IPostosRepository postosRepository, IMapper mapper)
    {
        _postosRepository = postosRepository;
        _mapper = mapper;
    }

    public async Task<Entities.PostoVacinacao?> PutPosto(UpdatePostoVacinacaoRequest request)
    {
        //TODO: Validate
        
        PostoVacinacaoModel? posto = await _postosRepository.GetPostoById(request.id);
        if (posto is null)
            return null;

        bool updated = false;
        if (request.nome is not null)
        {
            //TODO: Ensure that the posto name no exists
            posto.name = request.nome;
            updated = true;
        }
        
        if(updated)
            await _postosRepository.FlushChanges();
        
        Entities.PostoVacinacao postoRead = _mapper.Map<Entities.PostoVacinacao>(posto);
        return postoRead;
    }
}
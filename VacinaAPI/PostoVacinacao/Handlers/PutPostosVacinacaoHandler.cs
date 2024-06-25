using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.Exceptions;
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

    public async Task<PostoNVacina?> PutPosto(UpdatePostoVacinacaoRequest request)
    {
        //TODO: Validate
        
        PostoVacinacaoModel? posto = await _postosRepository.GetPostoById(request.id);
        if (posto is null)
            return null;

        bool updated = false;
        if (request.nome is not null)
        {
            PostoVacinacaoModel? postoWithName = await _postosRepository.GetPostoByName(request.nome);
            if (postoWithName is not null)
                throw new SameNameException(request.nome, "Posto");
            
            posto.name = request.nome;
            updated = true;
        }
        
        if(updated)
            await _postosRepository.FlushChanges();
        
        PostoNVacina postoRead = _mapper.Map<PostoNVacina>(posto);
        return postoRead;
    }
}
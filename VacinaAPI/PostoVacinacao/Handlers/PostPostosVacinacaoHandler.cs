using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.PostoVacinacao.Entities;

namespace VacinaAPI.PostoVacinacao.Handlers;

public class PostPostosVacinacaoHandler
{
    private readonly IPostosRepository _postosRepository;
    private readonly IMapper _mapper;
    
    public PostPostosVacinacaoHandler(IPostosRepository postosRepository, IMapper mapper)
    {
        _postosRepository = postosRepository;
        _mapper = mapper;
    }
    
    public async Task<Entities.PostoVacinacao> PostPosto(CreatePostoVacinacaoRequest request)
    {
        //TODO: valdiate
        
        PostoVacinacaoModel postoModel = _mapper
            .Map<PostoVacinacaoModel>(request);
        PostoVacinacaoModel newPosto = await _postosRepository.CreatePosto(postoModel);
        await _postosRepository.FlushChanges();
        
        Entities.PostoVacinacao postoRead = _mapper.Map<Entities.PostoVacinacao>(newPosto);
        return postoRead;
    }
}
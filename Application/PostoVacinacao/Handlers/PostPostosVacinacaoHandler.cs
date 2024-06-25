using Application.PostoVacinacao.Entities;
using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.Exceptions;

namespace Application.PostoVacinacao.Handlers;

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
        PostoVacinacaoModel? postoWithName = await _postosRepository.GetPostoByName(request.nome);

        if (postoWithName is not null)
            throw new SameNameException(request.nome, "Posto");
        
        PostoVacinacaoModel newPosto = await _postosRepository.CreatePosto(postoModel);
        await _postosRepository.FlushChanges();
        
        Entities.PostoVacinacao postoRead = _mapper.Map<Entities.PostoVacinacao>(newPosto);
        return postoRead;
    }
}
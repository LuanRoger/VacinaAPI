using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace VacinaAPI.PostoVacinacao.Handlers;

public class GetPostosVacinacaoHandler
{
    private readonly IPostosRepository _postosRepository;
    private readonly IMapper _mapper;
    
    public GetPostosVacinacaoHandler(IPostosRepository postosRepository, IMapper mapper)
    {
        _postosRepository = postosRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<Entities.PostoNVacina>> GetAllPostos()
    {
        var postos = await _postosRepository.GetPostos();
        var readPostos = postos
            .Select(_mapper.Map<Entities.PostoNVacina>)
            .ToList();
        
        return readPostos;
    }
    
    public async Task<Entities.PostoVacinacao?> GetPostoById(int id)
    {
        PostoVacinacaoModel? postoModel = await _postosRepository.GetPostoById(id);
        if (postoModel is null)
            return null;

        Entities.PostoVacinacao? postoRead = _mapper.Map<Entities.PostoVacinacao>(postoModel);
        return postoRead;
    }

    public async Task<Entities.PostoVacinacao?> GetPostoByName(string name)
    {
        PostoVacinacaoModel? postoModel = await _postosRepository.GetPostoByName(name);
        if (postoModel is null)
            return null;

        Entities.PostoVacinacao postoRead = _mapper.Map<Entities.PostoVacinacao>(postoModel);
        return postoRead;
    }
}
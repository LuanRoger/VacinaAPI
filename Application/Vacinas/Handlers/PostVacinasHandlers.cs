using Application.Vacinas.Entities;
using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Application.Vacinas.Handlers;

public class PostVacinasHandlers
{
    private readonly IVacinasRepository _vacinasRepository;
    private readonly IMapper _mapper;

    public PostVacinasHandlers(IVacinasRepository vacinasRepository, IMapper mapper)
    {
        _vacinasRepository = vacinasRepository;
        _mapper = mapper;
    }
    
    public async Task<Vacina> PostVacina(CreateVacinaRequest request)
    {
        //TODO: Validate request
        //TODO: Ver se o posto existe
        //TODO: Ver conflito de lote
        
        VacinaModel vacinaModel = _mapper.Map<VacinaModel>(request);
        VacinaModel createdVacina = await _vacinasRepository.CreateVacina(vacinaModel);
        
        await _vacinasRepository.FlushChanges();
        Vacina? vacinaRead = _mapper.Map<Vacina>(createdVacina);
        return vacinaRead;
    }
}
using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.Vacinas.Handlers;

public class PutVacinasHandlers
{
    private readonly IVacinasRepository _vacinasRepository;
    private readonly IMapper _mapper;

    public PutVacinasHandlers(IVacinasRepository vacinasRepository, IMapper mapper)
    {
        _vacinasRepository = vacinasRepository;
        _mapper = mapper;
    }
    
    public async Task<Vacina?> UpdateVacinaById(UpdateVacinaByIdRequest request)
    {
        //TODO: Validate request
        VacinaModel? vacina = await _vacinasRepository.GetVacinaById(request.id);
        if (vacina is null)
            return null;
        
        bool updated = false;

        if (request.quantidade.HasValue)
        {
            vacina.quantidade = request.quantidade.Value;
            updated = true;
        }
        
        
        if(updated)
            await _vacinasRepository.FlushChanges();

        Vacina vacinaRead = _mapper.Map<Vacina>(vacina);
        return vacinaRead;
    }
}
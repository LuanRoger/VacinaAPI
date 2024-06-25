using Application.Vacinas.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Models;
using Infrastructure.Repositories;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Vacinas.Handlers;

public class PutVacinasHandlers
{
    private readonly IVacinasRepository _vacinasRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateVacinaByIdRequest> _updateVacinaByIdValidator;

    public PutVacinasHandlers(IVacinasRepository vacinasRepository, IMapper mapper,
        IValidator<UpdateVacinaByIdRequest> updateVacinaByIdValidator)
    {
        _vacinasRepository = vacinasRepository;
        _mapper = mapper;
        _updateVacinaByIdValidator = updateVacinaByIdValidator;
    }
    
    public async Task<Vacina?> UpdateVacinaById(UpdateVacinaByIdRequest request)
    {
        ValidationResult? result = await _updateVacinaByIdValidator.ValidateAsync(request);
        if (!result.IsValid)
        {
            ValidationException exception = new(result.Errors.Select(f => f.ErrorMessage));
            throw exception;
        }
        
        VacinaModel? vacina = await _vacinasRepository.GetVacinaById(request.id);
        if (vacina is null)
            return null;
        
        bool updated = false;

        if (request.nome is not null)
        {
            vacina.nome = request.nome;
            updated = true;
        }
        if (request.fabricante is not null)
        {
            vacina.fabricante = request.fabricante;
            updated = true;
        }
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
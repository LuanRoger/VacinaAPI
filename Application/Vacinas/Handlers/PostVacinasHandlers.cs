using Application.Exceptions;
using Application.Vacinas.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Models;
using Infrastructure.Repositories;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Vacinas.Handlers;

public class PostVacinasHandlers
{
    private readonly IVacinasRepository _vacinasRepository;
    private readonly IPostosRepository _postosRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateVacinaRequest> _createVacinaValidator;

    public PostVacinasHandlers(IVacinasRepository vacinasRepository, IPostosRepository postosRepository, 
        IMapper mapper, IValidator<CreateVacinaRequest> createVacinaValidator)
    {
        _vacinasRepository = vacinasRepository;
        _postosRepository = postosRepository;
        _mapper = mapper;
        _createVacinaValidator = createVacinaValidator;
    }
    
    public async Task<Vacina> PostVacina(CreateVacinaRequest request)
    {
        ValidationResult? result = await _createVacinaValidator.ValidateAsync(request);
        if (!result.IsValid)
        {
            ValidationException exception = new(result.Errors.Select(f => f.ErrorMessage));
            throw exception;
        }

        PostoVacinacaoModel? posto = await _postosRepository.GetPostoById(request.idPosto);
        if (posto is null)
        {
            NotFoundException exception = new("Posto", nameof(request.idPosto), 
                request.idPosto.ToString());

            throw exception;
        }

        VacinaModel? vacinaLote = await _vacinasRepository.GetVacinaByLote(request.lote);
        if (vacinaLote is not null)
        {
            ResourceConflictException exception = new("lote", request.lote);
            throw exception;
        }
        
        VacinaModel vacinaModel = _mapper.Map<VacinaModel>(request);
        VacinaModel createdVacina = await _vacinasRepository.CreateVacina(vacinaModel);
        
        await _vacinasRepository.FlushChanges();
        Vacina? vacinaRead = _mapper.Map<Vacina>(createdVacina);
        return vacinaRead;
    }
}
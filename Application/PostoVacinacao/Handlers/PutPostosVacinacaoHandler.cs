using Application.PostoVacinacao.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.Exceptions;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.PostoVacinacao.Handlers;

public class PutPostosVacinacaoHandler
{
    private readonly IPostosRepository _postosRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdatePostoVacinacaoRequest> _updatePostoVacinacaoValidator;
    
    public PutPostosVacinacaoHandler(IPostosRepository postosRepository, IMapper mapper,
        IValidator<UpdatePostoVacinacaoRequest> updatePostoVacinacaoValidator)
    {
        _postosRepository = postosRepository;
        _mapper = mapper;
        _updatePostoVacinacaoValidator = updatePostoVacinacaoValidator;
    }

    public async Task<PostoNVacina?> PutPosto(UpdatePostoVacinacaoRequest request)
    {
        ValidationResult? result = await _updatePostoVacinacaoValidator.ValidateAsync(request);
        if (!result.IsValid)
        {
            ValidationException exception = new(result.Errors.Select(f => f.ErrorMessage));
            throw exception;
        }
        
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
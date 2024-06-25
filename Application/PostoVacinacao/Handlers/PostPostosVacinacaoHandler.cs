using Application.PostoVacinacao.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Models;
using Infrastructure.Repositories;
using VacinaAPI.Exceptions;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.PostoVacinacao.Handlers;

public class PostPostosVacinacaoHandler
{
    private readonly IPostosRepository _postosRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreatePostoVacinacaoRequest> _createPostoVacinacaoValidator;
    
    public PostPostosVacinacaoHandler(IPostosRepository postosRepository, IMapper mapper,
        IValidator<CreatePostoVacinacaoRequest> createPostoVacinacaoValidator)
    {
        _postosRepository = postosRepository;
        _mapper = mapper;
        _createPostoVacinacaoValidator = createPostoVacinacaoValidator;
    }
    
    public async Task<Entities.PostoVacinacao> PostPosto(CreatePostoVacinacaoRequest request)
    {
        ValidationResult? result = await _createPostoVacinacaoValidator.ValidateAsync(request);
        if (!result.IsValid)
        {
            ValidationException exception = new(result.Errors.Select(f => f.ErrorMessage));
            throw exception;
        }
        
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
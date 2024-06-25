using Application.PostoVacinacao.Entities;
using FluentValidation;

namespace Application.PostoVacinacao.Validations;

public class CreatePostoVacinacaoRequestValidator : AbstractValidator<CreatePostoVacinacaoRequest>
{
    public CreatePostoVacinacaoRequestValidator()
    {
        RuleFor(x => x.nome)
            .NotNull()
            .NotEmpty();
    }
}
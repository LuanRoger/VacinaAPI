using Application.PostoVacinacao.Entities;
using FluentValidation;

namespace Application.PostoVacinacao.Validations;

public class UpdatePostoVacinacaoRequestValidator : AbstractValidator<UpdatePostoVacinacaoRequest>
{
    public UpdatePostoVacinacaoRequestValidator()
    {
        RuleFor(f => f.id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(f => f.nome)
            .NotEmpty()
            .When(f => f.nome is not null);
    }
}
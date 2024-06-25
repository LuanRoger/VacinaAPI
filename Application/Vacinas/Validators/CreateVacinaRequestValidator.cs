using Application.Vacinas.Entities;
using FluentValidation;

namespace Application.Vacinas.Validators;

public class CreateVacinaRequestValidator : AbstractValidator<CreateVacinaRequest>
{
    public CreateVacinaRequestValidator()
    {
        RuleFor(f => f.nome)
            .NotNull()
            .NotEmpty();
        
        RuleFor(f => f.fabricante)
            .NotNull()
            .NotEmpty();

        RuleFor(f => f.quantidade)
            .NotNull()
            .GreaterThan(0);

        RuleFor(f => f.lote)
            .NotNull()
            .NotEmpty();

        RuleFor(f => f.dataValidade)
            .NotNull()
            .GreaterThan(DateTime.Now);

        RuleFor(f => f.idPosto)
            .NotNull()
            .GreaterThan(0);
    }
}
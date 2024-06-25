using Application.Vacinas.Entities;
using FluentValidation;

namespace Application.Vacinas.Validators;

public class UpdateVacinaByIdRequestValidator : AbstractValidator<UpdateVacinaByIdRequest>
{
    public UpdateVacinaByIdRequestValidator()
    {
        RuleFor(f => f.id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(f => f.nome)
            .NotEmpty()
            .When(f => f.nome is not null);
        
        RuleFor(f => f.fabricante)
            .NotEmpty()
            .When(f => f.fabricante is not null);
        
        RuleFor(f => f.quantidade)
            .GreaterThan(0)
            .When(f => f.nome is not null);
    }
}
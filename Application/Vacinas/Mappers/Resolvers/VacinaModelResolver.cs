using Application.Vacinas.Entities;
using AutoMapper;
using Infrastructure.Models;

namespace Application.Vacinas.Mappers.Resolvers;

public class VacinaModelResolver : ITypeConverter<VacinaModel, Vacina>
{
    public Vacina Convert(VacinaModel source, Vacina destination, ResolutionContext context)
    {
        PostoVacinacaoModel? sourcePosto = source.postoVacinacao;
        PostoVacina? posto = sourcePosto is not null ? new(sourcePosto.id, sourcePosto.name) : null;
        
        return new(source.id, source.nome, source.fabricante, source.quantidade, 
            source.lote, source.dataValidade, posto);
    }
}
using Application.Vacinas.Entities;
using AutoMapper;
using Infrastructure.Models;

namespace Application.Vacinas.Mappers.Resolvers;

public class CreateVacinaResolver : ITypeConverter<CreateVacinaRequest, VacinaModel>
{
    public VacinaModel Convert(CreateVacinaRequest source, VacinaModel destination, ResolutionContext context)
    {
        return new()
        {
            nome = source.nome,
            fabricante = source.fabricante,
            quantidade = source.quantidade,
            lote = source.lote,
            dataValidade = source.dataValidade,
            postoVacinacaoId = source.idPosto
        };
    }
}
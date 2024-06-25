using Application.PostoVacinacao.Entities;
using AutoMapper;
using Infrastructure.Models;

namespace Application.PostoVacinacao.Mappers.Resolvers;

public class PostoVacinacaoResolver : ITypeConverter<PostoVacinacaoModel, PostoVacinacao.Entities.PostoVacinacao>
{
    public PostoVacinacao.Entities.PostoVacinacao Convert(PostoVacinacaoModel source, 
        PostoVacinacao.Entities.PostoVacinacao destination, 
        ResolutionContext context)
    {
        var vacinas = source.vacinas
            .Select(f => 
                new VacinaPosto(f.id, f.nome, f.fabricante, 
                    f.quantidade, f.lote, f.dataValidade))
            .ToList();
        
        return new(source.id, source.name, vacinas);
    }
}
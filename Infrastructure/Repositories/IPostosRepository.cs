using Infrastructure.Models;

namespace Infrastructure.Repositories;

public interface IPostosRepository
{
    public Task<IReadOnlyCollection<PostoVacinacaoModel>> GetPostos();
    public Task<PostoVacinacaoModel?> GetPostoById(int id);
    public Task<PostoVacinacaoModel?> GetPostoByName(string name);
    public Task<bool> HasVacinasRelatedById(int id);
    public Task<bool> HasVacinasRelatedByName(string name);
    public Task<PostoVacinacaoModel> CreatePosto(PostoVacinacaoModel posto);
    public Task<int?> DeletePostoById(int id);
    public Task<int?> DeletePostoByName(string name);

    public Task FlushChanges();
}
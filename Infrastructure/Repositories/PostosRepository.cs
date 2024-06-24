using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PostosRepository : IPostosRepository
{
    private readonly AppDbContext _dbDbContext;
    
    public PostosRepository(AppDbContext dbDbContext)
    {
        _dbDbContext = dbDbContext;
    }

    public async Task<IReadOnlyCollection<PostoVacinacaoModel>> GetPostos() =>
        await _dbDbContext.postosVacinacao
            .AsNoTracking()
            .ToListAsync();

    public async Task<PostoVacinacaoModel?> GetPostoById(int id) =>
        await _dbDbContext.postosVacinacao.FindAsync(id);

    public async Task<PostoVacinacaoModel?> GetPostoByName(string name) =>
        await _dbDbContext.postosVacinacao.FirstOrDefaultAsync(f => f.name == name);

    public async Task<PostoVacinacaoModel> CreatePosto(PostoVacinacaoModel posto)
    {
        var newPostoEntity = await _dbDbContext.AddAsync(posto);
        PostoVacinacaoModel newPosto = newPostoEntity.Entity;
        return newPosto;
    }

    public async Task<int?> DeletePostoById(int id)
    {
        PostoVacinacaoModel? posto = await _dbDbContext.postosVacinacao.FindAsync(id);
        if (posto is null)
            return null;
        
        _dbDbContext.postosVacinacao.Remove(posto);
        return id;
    }

    public async Task<int?> DeletePostoByName(string name)
    {
        PostoVacinacaoModel? posto = await GetPostoByName(name);

        if (posto is null)
            return null;

        _dbDbContext.postosVacinacao.Remove(posto);
        return posto.id;
    }

    public Task FlushChanges() => _dbDbContext.SaveChangesAsync();
}
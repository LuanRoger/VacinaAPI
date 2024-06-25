using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class VacinasRepository : IVacinasRepository
{
    private readonly AppDbContext _dbDbContext;

    public VacinasRepository(AppDbContext dbDbContext)
    {
        _dbDbContext = dbDbContext;
    }
    
    public async Task<IReadOnlyList<VacinaModel>?> GetPostoVacinas(int id)
    {
        PostoVacinacaoModel? posto = await _dbDbContext.postosVacinacao
            .FindAsync(id);

        var vacinas = posto?.vacinas.ToList();
        
        return vacinas;
    }

    public async Task<VacinaModel?> GetVacinaById(int id) =>
        await _dbDbContext.vacinas.FindAsync(id);

    public async Task<IReadOnlyList<VacinaModel>?> GetVacinasByFabricante(string fabricante)
    {
        var vacinas = await _dbDbContext.vacinas
            .AsNoTracking()
            .Where(f => f.fabricante == fabricante)
            .ToListAsync();
        
        return vacinas.Count == 0 ? null : vacinas;

    }

    public async Task<VacinaModel?> GetVacinaByLote(string lote)
    {
        VacinaModel? vacinas = await _dbDbContext.vacinas
            .AsNoTracking()
            .Include(f => f.postoVacinacao)
            .FirstOrDefaultAsync(f => f.lote == lote);

        return vacinas ?? null;

    }

    public async Task<VacinaModel> CreateVacina(VacinaModel vacina)
    {
        var newVacinaEntity = await _dbDbContext.vacinas.AddAsync(vacina);
        VacinaModel newVacina = newVacinaEntity.Entity;

        return newVacina;
    }

    public async Task<int?> DeleteVacinaById(int id)
    {
        VacinaModel? vacinaToDelete = await GetVacinaById(id);
        if(vacinaToDelete is null)
            return null;
        
        _dbDbContext.vacinas.Remove(vacinaToDelete);
        return id;
    }

    public async Task<int?> DeleteVacinaByLote(string lote)
    {
        VacinaModel? vacina = await GetVacinaByLote(lote);

        if (vacina is null)
            return null;
        
        _dbDbContext.vacinas.Remove(vacina);
        return vacina.id;
    }

    public Task FlushChanges() => _dbDbContext.SaveChangesAsync();
}
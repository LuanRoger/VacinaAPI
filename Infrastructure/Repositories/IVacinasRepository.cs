using Infrastructure.Models;

namespace Infrastructure.Repositories;

public interface IVacinasRepository
{
    public Task<IReadOnlyList<VacinaModel>?> GetPostoVacinas(int id);
    public Task<IReadOnlyList<VacinaModel>?> GetVacinasByFabricante(string fabricante);
    public Task<VacinaModel?> GetVacinaByLote(string lote);
    public Task<VacinaModel?> GetVacinaById(int id);
    public Task<VacinaModel> CreateVacina(VacinaModel vacina);
    public Task<int?> DeleteVacinaById(int id);
    public Task<string?> DeleteVacinaByLote(string lote);
    public Task FlushChanges();
}
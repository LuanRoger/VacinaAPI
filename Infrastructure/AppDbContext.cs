using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<VacinaModel> vacinas { get; set; }
    public DbSet<PostoVacinacaoModel> postosVacinacao { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostoVacinacaoModel>().HasData([
        new()
        {
            id = 1,
            name = "Posto Russas",
        },
        new()
        {
            id = 2,
            name = "Posto Fortaleza",
        }
        ]);

        modelBuilder.Entity<VacinaModel>().HasData([
            new()
            {
                id = 1,
                nome = "Contra COVID-19",
                fabricante = "Pfizer",
                quantidade = 100,
                lote = "123",
                dataValidade = DateTime.Now.AddMonths(6),
                postoVacinacaoId = 1
            },
            new()
            {
                id = 2,
                nome = "Contra Febre Amarela",
                fabricante = "Fiocruz",
                quantidade = 423,
                lote = "694",
                dataValidade = DateTime.Now.AddMonths(6),
                postoVacinacaoId = 1
            },
            new()
            {
                id = 3,
                nome = "Hepatite A",
                fabricante = "Instituto Butantan",
                quantidade = 231,
                lote = "593",
                dataValidade = DateTime.Now.AddMonths(6),
                postoVacinacaoId = 2
            },
            new()
            {
                id = 4,
                nome = "Hepatite B",
                fabricante = "Instituto Butantan",
                quantidade = 432,
                lote = "612",
                dataValidade = DateTime.Now.AddMonths(6),
                postoVacinacaoId = 2
            }
        ]);
    }
}
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<VacinaModel> vacinas { get; set; }
    public DbSet<PostoVacinacaoModel> postosVacinacao { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Vacinas")]
[Index(nameof(lote), IsUnique = true)]
public class VacinaModel
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int id { get; set; }
    
    [Required]
    [Column("nome")]
    public string nome { get; set; }
    
    [Required]
    [Column("fabricante")]
    public string fabricante { get; set; }
    
    [Required]
    [Column("quantidade")]
    public int quantidade { get; set; }
    
    [Required]
    [MinLength(3)]
    [Column("lote")]
    public string lote { get; set; }
    
    [Required]
    [Column("data_validade")]
    public DateTime dataValidade { get; set; }
    
    [Required]
    [Column("fk_posto_vacinacao")]
    [ForeignKey(nameof(PostoVacinacaoModel))]
    public int postoVacinacaoId { get; set; }

    public PostoVacinacaoModel postoVacinacao { get; set; } = null!;
}
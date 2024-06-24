using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models;

[Table("Postos")]
public class PostoVacinacaoModel
{
    [Key]
    [Required]
    [Column("id")]
    public int id { get; set; }
    
    [Required]
    [Column("name")]
    public string name { get; set; }
    
    public ICollection<VacinaModel> vacinas { get; set; } = new List<VacinaModel>();
}
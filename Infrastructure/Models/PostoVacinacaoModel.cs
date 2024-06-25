using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("postos")]
[Index(nameof(name), IsUnique = true)]
public class PostoVacinacaoModel
{
    [Key]
    [Required]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    [Column("name")]
    public string name { get; set; }
    
    public ICollection<VacinaModel> vacinas { get; set; } = new List<VacinaModel>();
}
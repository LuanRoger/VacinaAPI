namespace VacinaAPI.Vacinas.Entities;

public class CreateVacinaRequest
{
    public string name { get; set; }
    public string fabricante { get; set; }
    public int quantidade { get; set; }
    public string lote { get; set; }
    public DateTime dataValidade { get; set; }
    public int idPosto { get; set; }
}
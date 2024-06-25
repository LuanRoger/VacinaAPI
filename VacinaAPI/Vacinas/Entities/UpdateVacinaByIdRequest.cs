namespace VacinaAPI.Vacinas.Entities;

public class UpdateVacinaByIdRequest
{
    public int id { get; set; }
    public string? nome { get; set; }
    public string? fabricante { get; set; }
    public int? quantidade { get; set; }
}
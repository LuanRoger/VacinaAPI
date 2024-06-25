namespace VacinaAPI.Vacinas.Entities;

public class UpdateVacinaByIdRequest
{
    public int id { get; set; }
    public int? quantidade { get; set; }
}
namespace VacinaAPI.Vacinas.Entities;

public record PostoVacinacao(int id, string nome, List<Vacina> vacinas);
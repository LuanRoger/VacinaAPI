using VacinaAPI.Vacinas.Entities;

namespace VacinaAPI.PostoVacinacao.Entities;

public record PostoVacinacao(int id, string nome, List<VacinaPosto> vacinas);
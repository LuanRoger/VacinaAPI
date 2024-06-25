namespace Application.PostoVacinacao.Entities;

public record PostoVacinacao(int id, string nome, List<VacinaPosto> vacinas);
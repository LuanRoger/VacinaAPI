namespace VacinaAPI.PostoVacinacao.Entities;

public record VacinaPosto(int id, string nome, string fabricante, 
    int quantidade, string lote, DateTime dataValidade);
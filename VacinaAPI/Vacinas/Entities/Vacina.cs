namespace VacinaAPI.Vacinas.Entities;

public record Vacina(int id, string nome, string fabricante, int quantidade, string lote, 
    DateTime dataValidade, PostoVacinacao postoVacinacao);
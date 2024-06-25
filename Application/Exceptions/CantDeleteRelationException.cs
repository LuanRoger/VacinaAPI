namespace VacinaAPI.Exceptions;

public class CantDeleteRelationException(string source, string with) : 
    Exception(string.Format(MESSAGE, source, with))
{
    private const string MESSAGE = "{0} não pode ser excluido, pois possui {1} relacionados";
}
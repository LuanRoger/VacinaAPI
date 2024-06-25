namespace VacinaAPI.Exceptions;

public class SameNameException(string name, string record) : Exception(string.Format(MESSAGE, record, name))
{
    private const string MESSAGE = "Um {0} com o nome {1} já existe.";
}
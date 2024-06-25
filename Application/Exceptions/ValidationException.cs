using Application.Utils;

namespace Application.Exceptions;

public class ValidationException : Exception
{
    private const string MESSAGE = "Problemas de validação: {0}";

    public ValidationException(IEnumerable<string> errors) : 
        base(string.Format(MESSAGE, errors.ToSeparatedString())) { }
    public ValidationException(string error) : 
        base(string.Format(MESSAGE, error)) { }
}
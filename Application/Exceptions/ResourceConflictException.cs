namespace Application.Exceptions;

public class ResourceConflictException(string resource, string value) : 
    Exception(string.Format(MESSAGE, resource, value))
{
    private const string MESSAGE = "Um {0} {1} já existe.";
}
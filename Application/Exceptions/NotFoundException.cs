namespace Application.Exceptions;

public class NotFoundException(string entity, string propertyName, string propertyValue) : 
    Exception(string.Format(MESSAGE, entity, propertyName, propertyValue))
{
    private const string MESSAGE = "O {0} não foi encontrado com o [{1}]{2}.";
}
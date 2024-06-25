namespace Application.Utils;

public static class EnumerableExtensions
{
    public static string ToSeparatedString(this IEnumerable<string> enumerable, char separator = ' ') => 
        string.Join(separator, enumerable);
}
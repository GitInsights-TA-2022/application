namespace infrastructure;
public static class Utilities
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
    {
        foreach (var i in items)
            foreach (var x in i)
                yield return x;
    }
}
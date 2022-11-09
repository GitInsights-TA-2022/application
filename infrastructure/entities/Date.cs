namespace infrastructure.entities;
public class Date : IComparable
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }
}
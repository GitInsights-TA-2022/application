namespace infrastructure;
public class Commit
{
    public int Id { get; set; }
    public string Author { get; set; } = null!;
    public DateTimeOffset Timestamp { get; set; }
}
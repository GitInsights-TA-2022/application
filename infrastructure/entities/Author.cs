namespace infrastructure.entities;
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Dictionary<DateTime, int> Frequency { get; set; } = new Dictionary<DateTime, int>();
    public Analysis Parent { get; set; } = null!;
    public int TotalCommits { get => this.Frequency.Select(f => f.Value).Sum(); }
    public DateTime LastCommit { get; set; }
}
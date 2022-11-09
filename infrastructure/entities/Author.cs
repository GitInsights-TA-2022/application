namespace infrastructure.entities;
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Dictionary<Date, int> Frequency { get; set; } = new Dictionary<Date, int>();
    public int TotalCommits { get => this.Frequency.Select(f => f.Value).Sum(); }
    public Analysis Analysis { get; set; } = null!;
}
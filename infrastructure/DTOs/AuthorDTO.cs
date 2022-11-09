namespace infrastructure.DTOs;
public record AuthorDTO
{
    public int? Id { get; }
    public string Name { get; } = null!;
    public Dictionary<DateTime, int> Frequency { get; } = new Dictionary<DateTime, int>();
    public int TotalCommits { get => this.Frequency.Select(f => f.Value).Sum(); }
    public DateTime LastCommit { get => this.Frequency.Keys.OrderByDescending(date => date).FirstOrDefault(); }
    public AuthorDTO(Author entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Frequency = entity.Frequency;
    }
}
namespace infrastructure.DTOs;
public record AuthorDTO
{
    public int? Id { get; set; }
    public string Name { get; set; } = null!;
    public Dictionary<DateDTO, int> Frequency { get; set; } = new Dictionary<DateDTO, int>();
    public int TotalCommits { get => this.Frequency.Select(f => f.Value).Sum(); }
    public AuthorDTO(Author entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Frequency = (Dictionary<DateDTO, int>)entity.Frequency.Select(f =>
            (new DateDTO(f.Key), f.Value));
    }
}
namespace infrastructure.DTOs;
public record AnalysisDTO : AnalysisCreateDTO
{
    public int? Id { get; set; }
    public int TotalCommits { get => this.Authors.Select(a => a.TotalCommits).Sum(); }
    public AnalysisDTO(Analysis entity)
    {
        Id = entity.Id;
        RemoteUrl = entity.RemoteUrl;
        LastCommit = entity.LastCommit;
        Authors = entity.Authors.Select(a => new AuthorDTO(a));
    }
}
public record AnalysisCreateDTO
{
    public string RemoteUrl { get; set; } = null!;
    public DateTimeOffset? LastCommit { get; set; }
    public IEnumerable<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();
}
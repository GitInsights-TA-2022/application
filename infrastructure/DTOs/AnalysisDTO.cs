namespace infrastructure.DTOs;
public record AnalysisDTO : AnalysisCreateDTO
{
    public int? Id { get; }
    public int TotalCommits { get => this.Authors.Select(a => a.TotalCommits).Sum(); }

    public AnalysisDTO(Analysis entity) : base(entity)
    {
        Id = entity.Id;
    }
}
public record AnalysisCreateDTO
{
    public string RemoteUrl { get; } = null!;
    public DateTimeOffset? LastCommit { get; }
    public IEnumerable<AuthorDTO> Authors { get; } = new List<AuthorDTO>();

    public AnalysisCreateDTO(Analysis entity)
    {
        RemoteUrl = entity.RemoteUrl;
        LastCommit = entity.LastCommit;
        Authors = entity.Authors.Select(a => new AuthorDTO(a));
    }

    public AnalysisCreateDTO(Repository repository)
    {
        // #TODO: this
    }
}
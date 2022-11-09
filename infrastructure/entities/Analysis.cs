namespace infrastructure.entities;
public class Analysis
{
    public int Id { get; set; }
    public string RemoteUrl { get; set; } = null!;
    public DateTimeOffset? LastCommit { get; set; }
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();
}
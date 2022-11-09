
namespace infrastructure.test;

public class CommitRepositoryTests : IDisposable
{
    private readonly GitInsightContext _context = null!;
    private readonly AnalysisRepository _repo = null!;

    public CommitRepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<GitInsightContext>();
        builder.UseSqlite(connection);
        _context = new GitInsightContext(builder.Options);
        _context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    [Fact]
    public void Test1() { }
}

namespace infrastructure.test;

public class CommitRepositoryTests : IDisposable
{
    private readonly AnalysisContext _context = null!;
    private readonly CommitRepository _repo = null!;

    public CommitRepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<AnalysisContext>();
        builder.UseSqlite(connection);
        _context = new AnalysisContext(builder.Options);
        _context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    [Fact]
    public void Test1() { }
}
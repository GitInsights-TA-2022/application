namespace infrastructure;
public class CommitRepository : ICommitRepository
{
    private readonly AnalysisContext _context = null!;

    public CommitRepository(AnalysisContext context)
    {
        _context = context;
    }
}
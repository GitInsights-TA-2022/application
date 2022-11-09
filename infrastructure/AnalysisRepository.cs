namespace infrastructure;
public class AnalysisRepository : IAnalysisRepository
{
    private readonly GitInsightContext _context = null!;

    public AnalysisRepository(GitInsightContext context)
    {
        _context = context;
    }

    public async Task<Status> Create(AnalysisCreateDTO analysis)
    {
        var entity = await _context.Analyses.FindAsync(analysis.RemoteUrl);
        if (entity is not null) return Status.Conflict;
        entity = new Analysis
        {
            RemoteUrl = analysis.RemoteUrl,
            LastCommit = analysis.LastCommit,
        };
        await _context.Analyses.AddAsync(entity);
        entity.Authors = analysis.Authors
            .Select(a => new Author
            {
                Name = a.Name,
                Frequency = a.Frequency,
                Parent = entity,
            });
        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<AnalysisDTO?> Read(string remoteUrl)
    {
        var entity = await _context.Analyses.FindAsync(remoteUrl);
        if (entity is null) return null;
        return new AnalysisDTO(entity);
    }

    public async Task<(Status, AnalysisDTO?)> Update(AnalysisDTO analysis)
    {
        var entity = await _context.Analyses.FindAsync(analysis.RemoteUrl);
        if (entity is null) return (Status.NotFound, null);
        if (analysis.LastCommit is null)
            entity.Authors = analysis.Authors
                .Select(a => new Author
                {
                    Name = a.Name,
                    Frequency = a.Frequency,
                    Parent = entity,
                });
        else
            entity.Authors = analysis.Authors
                .Select(a => new Author
                {
                    Name = a.Name,
                    Frequency = a.Frequency,
                    Parent = entity,
                })
                .Where(a => a.LastCommit > entity.LastCommit);
        entity.LastCommit = analysis.Authors
            .OrderByDescending(a => a.LastCommit)
            .First()
            .LastCommit;
        await _context.Analyses.AddAsync(entity);
        await _context.SaveChangesAsync();
        return (Status.Success, new AnalysisDTO(entity));
    }

}
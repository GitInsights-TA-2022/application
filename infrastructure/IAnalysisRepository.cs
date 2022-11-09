namespace infrastructure;
public interface IAnalysisRepository
{
    Task<Status> Create(AnalysisCreateDTO analysis);
    Task<AnalysisDTO?> Read(string remoteUrl);
    Task<(Status, AnalysisDTO?)> Update(AnalysisDTO analysis);
}
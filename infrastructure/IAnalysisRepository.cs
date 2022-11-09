namespace infrastructure;
public interface IAnalysisRepository
{
    Task<Status> Create(AnalysisCreateDTO analysis);
    Task<AnalysisDTO?> Read(string remoteUrl);
    Task<Status> Update(AnalysisDTO analysis);
}
public class CommitFrequencyHandler : AbstractHandler
{
    public override int Handle(BaseModel model)
    {
        var repo = new Repository(model.RepositoryPath);
        foreach (var c in repo.Commits)
        {
            System.Console.WriteLine(c.Author.When.ToString());
        }
        return 1;
    }
}
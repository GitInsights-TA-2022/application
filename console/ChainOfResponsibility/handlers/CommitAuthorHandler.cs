public class CommitAuthorHandler : AbstractHandler
{
    public override int Handle(BaseModel model)
    {
        var repo = new Repository(model.RepositoryPath);
        foreach (var c in repo.Commits)
        {
            System.Console.WriteLine("blob");
            System.Console.WriteLine(c.Author.When.ToString());
        }
        return 1;
    }
}
public class CommitFrequencyHandler : AbstractHandler
{
    public override int Handle(BaseModel model)
    {
        var repo = new Repository(model.RepositoryPath);
        var result = repo.Commits
                            .GroupBy(c => c.Author.When.Date)
                            .Select(c => new
                            {
                                Count = c.Count(),
                                Day = c.First().Author.When.Date
                            })
                            .ToList();

        foreach (var item in result)
        {
            System.Console.WriteLine($"  {item.Day} : {item.Count}");
        }
        foreach (var c in repo.Commits)
        {
            System.Console.WriteLine(c.Author.When.ToString());
        }
        return 1;
    }
}
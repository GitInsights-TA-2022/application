public class CommitFrequencyHandler : AbstractHandler
{
    public override int Handle(BaseModel model)
    {
        var repo = new Repository(model.RepositoryPath);
        repo.Commits
            .GroupBy(c => c.Author.When.Date)
            .Select(c => new
            {
                Count = c.Count(),
                Day = c.First().Author.When.Date
            })
            .ToList()
            .ForEach(item => WriteLine($"  {item.Day.ToShortDateString()} : {item.Count}"));

        return 1;
    }
}
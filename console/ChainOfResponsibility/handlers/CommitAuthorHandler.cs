namespace console.COR.handlers;
public class CommitAuthorHandler : AbstractHandler
{
    public override int Handle(BaseModel model)
    {
        var repo = new Repository(model.RepositoryPath);
        repo.Commits
            .GroupBy(c => c.Author.Name,
                (signature, commits) => new
                {
                    Author = signature,
                    Commits = commits
                              .AsQueryable()
                              .GroupBy(c => c.Author.When.Date)
                              .AsEnumerable()
                              .Select(c => (c.Count(), c.First().Author.When.Date))
                              .ToList(),
                })
            .ToList()
            .ForEach(item =>
            {
                WriteLine($" {item.Author}");
                WriteLine($"{item.Commits.Aggregate("", (acc, next) => acc + $"\t{next.Date.ToShortDateString()} : {next.Item1}\n")}");
            });

        return 1;
    }
}
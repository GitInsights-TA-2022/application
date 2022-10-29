namespace console.model;

// #nullable disable warnings
public class BaseModel
{
    [Value(1, MetaName = "path/to/git/repo", Required = true, HelpText = "The path to the local git repository")]
    public string RepositoryPath { get; init; } = default!;
}

[Verb("-cf", HelpText = "List the number of commits per day")]
public class FrequencyOptions : BaseModel { }

[Verb("-ca", HelpText = "List the number of commits per day per author")]
public class AuthorOptions : BaseModel { }
namespace console;
public class Program
{
    public static void Main(string[] args)
    {
        CommandLine.Parser.Default.ParseArguments<FrequencyOptions, AuthorOptions>(args)
            .MapResult
            (
                (FrequencyOptions opts) => RunWithFreqOptions(opts),
                (AuthorOptions opts) => RunWithAuthorOptions(opts),
                e => -1
            );
    }

    static int RunWithFreqOptions(FrequencyOptions opts)
    {
        var dirHandler = new PathValidationHandler();
        var repoHandler = new RepoValidationHandler();
        var commitFreqHandler = new CommitFrequencyHandler();
        dirHandler.SetNext(repoHandler).SetNext(commitFreqHandler);
        return dirHandler.Handle(opts);
    }

    static int RunWithAuthorOptions(AuthorOptions opts)
    {
        var dirHandler = new PathValidationHandler();
        var repoHandler = new RepoValidationHandler();
        var commitFreqHandler = new CommitAuthorHandler();
        dirHandler.SetNext(repoHandler).SetNext(commitFreqHandler);
        return dirHandler.Handle(opts);
    }
}
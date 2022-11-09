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

    static int RunWithFreqOptions(FrequencyOptions opts) =>
        SetupBaselineHandlersWith(new CommitFrequencyHandler(), opts);

    static int RunWithAuthorOptions(AuthorOptions opts) =>
        SetupBaselineHandlersWith(new CommitAuthorHandler(), opts);

    static int SetupBaselineHandlersWith(IHandler mode, BaseModel opts) =>
        new PathValidationHandler()
            .SetNext(new RepoValidationHandler())
            .SetNext(mode)
            .Handle(opts);
}
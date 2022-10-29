namespace console;

public class Program
{
    public static void Main(string[] args)
    {
        CommandLine.Parser.Default.ParseArguments<FrequencyOptions, AuthorOptions>(args)
            .MapResult
            (
                (FrequencyOptions opts) => HandleFreqOptions(opts),
                (AuthorOptions opts) => HandleAuthOptions(opts),
                e => -1
            );
    }

    static int HandleFreqOptions(FrequencyOptions opts)
    {
        return 1;
    }

    static int HandleAuthOptions(AuthorOptions opts)
    {
        return 1;
    }
}
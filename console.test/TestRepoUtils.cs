namespace console.test;

// kudos to Mikkel [lipp@itu.dk] for a decent and simple way to setup a local repo for unit testing 
public class TestRepoUtils
{

    const string REPO_PATH = "./testrepo/";

    public static Repository CreateEmptyLocalRepository()
    {
        // initialize a local git repo
        var path = Repository.Init(REPO_PATH);

        // instantiate a Repository object from that directory
        return new Repository(path);
    }

    public static void TearDownLocalRepository(Repository repo)
    {
        // clean up after the test by disposing the Repository object and
        // deleting the created folder with the git repo
        Directory.Delete(repo.Info.Path, recursive: true);
        repo.Dispose();
    }
}
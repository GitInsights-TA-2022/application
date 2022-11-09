namespace console.test;
// This abstract base class provides an empty test repository for each unit test in inherited test classes 
// with this setup, each unit test will have its own empty local repo to work with in isolation
public abstract class TestBase : IDisposable
{
    protected Repository TestRepository;

    // This is the 'setup' method, which is run before each test
    protected TestBase()
    {
        TestRepository = TestRepoUtils.CreateEmptyLocalRepository();
    }

    // This is the 'tearDown' method, which is run after each test
    public void Dispose()
    {
        TestRepoUtils.TearDownLocalRepository(TestRepository);
    }
}
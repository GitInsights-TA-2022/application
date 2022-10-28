namespace console.test;

public class LocalRepoTest : TestBase
{
    [Fact]
    public void Given_blob_blib_blab()
    {
        // now add some test data ...
        // each commit needs a signature where we can set author and datetime
        var signature = new Signature(
            "lipp",
            "lipp@itu.dk",
            new DateTimeOffset(new DateTime(2022, 10, 25))
        );

        // create the commits to our test repo
        // we have to include the CommitOptions with AllowEmptyCommit = true,
        // otherwise libgit2sharp will complain that no changes have been made
        // to the repo and throw an exception when calling Commit()
        TestRepository.Commit(
            "commit one", signature, signature,
            new CommitOptions() { AllowEmptyCommit = true }
        );
        TestRepository.Commit(
            "commit two", signature, signature,
            new CommitOptions() { AllowEmptyCommit = true }
        );
        TestRepository.Commit(
            "commit three", signature, signature,
            new CommitOptions() { AllowEmptyCommit = true }
        );

        Assert.Equal(TestRepository.Commits.Count(), 3);
    }

    [Fact]
    public void TestName()
    {
        Assert.Equal(TestRepository.Commits.Count(), 0);
    }
}
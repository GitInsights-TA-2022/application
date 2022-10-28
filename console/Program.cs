// See https://aka.ms/new-console-template for more information

using LibGit2Sharp;

var path = Repository.Init("./empty_repo/");
var repo = new Repository(path);
Console.WriteLine("Hello, World!");
Console.WriteLine(repo.Commits.Count());

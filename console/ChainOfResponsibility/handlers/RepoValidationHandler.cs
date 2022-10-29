public class RepoValidationHandler : AbstractHandler
{
    public override int Handle(BaseModel model)
    {
        if (Repository.IsValid(model.RepositoryPath))
        {
            return base.Handle(model);
        }
        else
        {
            System.Console.WriteLine("The provided path does not contain a valid git repository");
            return -1;
        }
    }
}
namespace console.COR.handlers;
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
            WriteLine("The provided path does not contain a valid git repository");
            return -1;
        }
    }
}
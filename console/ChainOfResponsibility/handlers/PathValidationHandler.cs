namespace console.COR.handlers;
public class PathValidationHandler : AbstractHandler
{
    public override int Handle(BaseModel model)
    {
        if (Directory.Exists(model.RepositoryPath))
        {
            return base.Handle(model);
        }
        else
        {
            WriteLine("The provided path is not a valid directory");
            return -1;
        }
    }
}
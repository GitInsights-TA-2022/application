namespace console.COR;
public interface IHandler 
{
    IHandler SetNext(IHandler handler);
    int Handle(BaseModel model);
}
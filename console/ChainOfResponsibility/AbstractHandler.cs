public abstract class AbstractHandler : IHandler
{
    private IHandler? _nextHandler;
    public IHandler SetNext(IHandler handler)
    {
        this._nextHandler = handler;
        return handler;
    }

    public virtual int Handle(BaseModel model) => this._nextHandler != null ? this._nextHandler.Handle(model) : -1;
}
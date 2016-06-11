namespace Voyage.Integration.Application.Interfaces
{
    public interface ICommand<out TReturn, in TParams>
    {
        TReturn Execute(TParams parameters);
    }
}

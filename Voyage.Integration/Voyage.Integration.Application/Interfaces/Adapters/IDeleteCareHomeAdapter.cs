namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IDeleteCareHomeAdapter
    {
        bool DeleteHome(int careHomeId, string executingUser);
    }
}

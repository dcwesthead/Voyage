
namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IUpdateCareHomeAdapter
    {
        int UpdateHome(int homeId, string homeName, string executingUser);
    }
}


namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IUpdateCareHomeAdapter
    {
        int Update(int homeId, string homeName, string executingUser);
    }
}

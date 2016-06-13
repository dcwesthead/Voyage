using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Repositories
{
    public interface IHomeRepository
    {
        int CreateHome(string homeName, string executingUser);
        int UpdateHome(int homeId, string homeName, string executingUser);
        bool DeleteHome(int homeId, string executingUser);
        CareHomeDto GetHome(int homeId);
    }
}

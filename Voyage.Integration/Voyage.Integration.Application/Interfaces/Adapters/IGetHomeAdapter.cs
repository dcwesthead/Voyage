using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IGetHomeAdapter
    {
        HomeDto GetHome(int homeId);
    }
}

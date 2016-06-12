using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IGetCareHomeAdapter
    {
        CareHomeDto GetHome(int homeId);
    }
}

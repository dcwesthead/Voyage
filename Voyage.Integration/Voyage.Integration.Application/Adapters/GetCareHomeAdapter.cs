using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Adapters
{
    public class GetCareHomeAdapter : IGetCareHomeAdapter
    {
        IHomeRepository _homeRepository;

        public GetCareHomeAdapter(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public CareHomeDto GetHome(int homeId)
        {
            var response = _homeRepository.GetHomeName(homeId);

            var dto = new CareHomeDto
            {
                Id = homeId,
                Name = response
            };

            return dto;
        }
    }
}

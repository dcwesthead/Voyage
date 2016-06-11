using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Adapters
{
    public class GetHomeAdapter : IGetHomeAdapter
    {
        IHomeRepository _homeRepository;

        public GetHomeAdapter(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public HomeDto GetHome(int homeId)
        {
            var response = _homeRepository.GetHomeName(homeId);

            var dto = new HomeDto
            {
                Id = homeId,
                Name = response
            };

            return dto;
        }
    }
}

using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;

namespace Voyage.Integration.Application.Adapters
{
    public class UpdateCareHomeAdapter : IUpdateCareHomeAdapter
    {
        IHomeRepository _homeRepository;

        public UpdateCareHomeAdapter(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public int Update(int homeId, string homeName, string executingUser)
        {
            return _homeRepository.UpdateHome(homeId, homeName, executingUser);
        }
    }
}

using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;

namespace Voyage.Integration.Application.Adapters
{
    public class DeleteCareHomeAdapter : IDeleteCareHomeAdapter
    {
        IHomeRepository _homeRepository;

        public DeleteCareHomeAdapter(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public bool DeleteHome(int homeId, string executingUser)
        {
            return _homeRepository.DeleteHome(homeId, executingUser);
        }
    }
}

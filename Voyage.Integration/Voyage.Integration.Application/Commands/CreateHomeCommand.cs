using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Commands
{
    public class CreateHomeCommand : ICommand<CreateHomeResponse, CreateHomeRequest>
    {
        private ICreateHomeAdapter _createHomeAdapter;
        private IHomeRepository _homeRepository;

        public CreateHomeCommand(ICreateHomeAdapter adapter, IHomeRepository repository)
        {
            _createHomeAdapter = adapter;
            _homeRepository = repository;
        }

        public CreateHomeResponse Execute(CreateHomeRequest request)
        {
            var homeId = _createHomeAdapter.CreateHome(request.Name,request.ExecutingUser);

            var response = new CreateHomeResponse()
            {
                HomeId = homeId,
                Success = homeId > 0
            };

            return response;
        }
    }
}

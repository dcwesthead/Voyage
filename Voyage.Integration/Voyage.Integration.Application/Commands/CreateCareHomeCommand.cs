using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Commands
{
    public class CreateCareHomeCommand : ICommand<CreateCareHomeResponse, CreateCareHomeRequest>
    {
        private ICreateCareHomeAdapter _createHomeAdapter;
        private IHomeRepository _homeRepository;

        public CreateCareHomeCommand(ICreateCareHomeAdapter adapter, IHomeRepository repository)
        {
            _createHomeAdapter = adapter;
            _homeRepository = repository;
        }

        public CreateCareHomeResponse Execute(CreateCareHomeRequest request)
        {
            var homeId = _createHomeAdapter.CreateHome(request.Name,request.ExecutingUser);

            var response = new CreateCareHomeResponse()
            {
                HomeId = homeId,
                Success = homeId > 0
            };

            return response;
        }
    }
}

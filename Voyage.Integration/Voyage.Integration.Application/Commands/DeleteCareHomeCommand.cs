using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Commands
{
    public class DeleteCareHomeCommand : ICommand<ServiceResponse, DeleteCareHomeRequest>
    {
        private IDeleteCareHomeAdapter _DeleteHomeAdapter;
        private IHomeRepository _homeRepository;

        public DeleteCareHomeCommand(IDeleteCareHomeAdapter adapter, IHomeRepository repository)
        {
            _DeleteHomeAdapter = adapter;
            _homeRepository = repository;
        }

        public ServiceResponse Execute(DeleteCareHomeRequest request)
        {
            var success = _DeleteHomeAdapter.DeleteHome(request.CareHomeId, request.ExecutingUser);

            var response = new ServiceResponse()
            {
                Success = success
            };

            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Commands
{
    public class UpdateCareHomeCommand : ICommand<UpdateCareHomeResponse, UpdateCareHomeRequest>
    {
        private IUpdateCareHomeAdapter _UpdateHomeAdapter;
        private IHomeRepository _homeRepository;

        public UpdateCareHomeCommand(IUpdateCareHomeAdapter adapter, IHomeRepository repository)
        {
            _UpdateHomeAdapter = adapter;
            _homeRepository = repository;
        }

        public UpdateCareHomeResponse Execute(UpdateCareHomeRequest request)
        {
            var homeId = _UpdateHomeAdapter.UpdateHome(request.CareHomeId, request.Name,request.ExecutingUser);

            var response = new UpdateCareHomeResponse()
            {
                CareHomeId = homeId,
                Success = homeId == request.CareHomeId
            };

            return response;
        }
    }
}

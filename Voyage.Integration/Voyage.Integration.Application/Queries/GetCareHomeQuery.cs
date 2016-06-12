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

namespace Voyage.Integration.Application.Queries
{
    public class GetCareHomeQuery : ICommand<GetCareHomeResponse, GetCareHomeRequest>
    {
        private IGetCareHomeAdapter _getHomeAdapter;
        private IHomeRepository _homeRepository;

        public GetCareHomeQuery(IGetCareHomeAdapter adapter, IHomeRepository repository)
        {
            _getHomeAdapter = adapter;
            _homeRepository = repository;
        }

        public GetCareHomeResponse Execute(GetCareHomeRequest parameters)
        {
            throw new NotImplementedException();
        }
    }
}

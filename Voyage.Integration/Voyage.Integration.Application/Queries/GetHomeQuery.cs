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
    public class GetHomeQuery : ICommand<GetHomeResponse, GetHomeRequest>
    {
        private IGetHomeAdapter _getHomeAdapter;
        private IHomeRepository _homeRepository;

        public GetHomeQuery(IGetHomeAdapter adapter, IHomeRepository repository)
        {
            _getHomeAdapter = adapter;
            _homeRepository = repository;
        }

        public GetHomeResponse Execute(GetHomeRequest parameters)
        {
            throw new NotImplementedException();
        }
    }
}

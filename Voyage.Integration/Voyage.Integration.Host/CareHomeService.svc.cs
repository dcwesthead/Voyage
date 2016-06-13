using Voyage.Integration.Application.Adapters;
using Voyage.Integration.Application.Queries;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.ServiceContracts.Dtos;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Services;
using Voyage.Integration.DataAccess;
using System;

namespace Voyage.Integration.Host
{
    public class CareHomeService : ICareHomeService
    {
        public CareHomeDto GetCareHome(int careHomeId)
        {
            var repo = new CareHomeRepository();

            var query = new GetCareHomeQuery(new GetCareHomeAdapter(repo), repo);
            var request = new GetCareHomeRequest
            {
                CareHomeId = careHomeId
            };
            
            var response = query.Execute(request);
            return ConvertToDto(response);
        }

        public int CreateCareHome(CareHomeDto careHome)
        {
            if(careHome.Id != null)
            {
                return 0;
            }

            var repo = new CareHomeRepository();

            var command = new CreateCareHomeCommand(new CreateCareHomeAdapter(repo), repo);
            var request = new CreateCareHomeRequest
            {
                Name = careHome.Name,
                ExecutingUser = Environment.UserName
            };

            var response = command.Execute(request);
            
            if(!response.Success)
            {
                return 0;
            }

            return response.HomeId;
        }

        public int UpdateCareHome(CareHomeDto careHome)
        {
            if (careHome.Id == null)
            {
                return 0;
            }

            var repo = new CareHomeRepository();

            var command = new UpdateCareHomeCommand(new UpdateCareHomeAdapter(repo), repo);
            var request = new UpdateCareHomeRequest
            {
                CareHomeId = careHome.Id,
                Name = careHome.Name,
                ExecutingUser = Environment.UserName
            };

            var response = command.Execute(request);

            if (!response.Success)
            {
                return 0;
            }

            return response.CareHomeId;
        }

        public bool DeleteCareHome(int careHomeId)
        {
            if (careHomeId == null)
            {
                return false;
            }

            var repo = new CareHomeRepository();

            var command = new DeleteCareHomeCommand(new DeleteCareHomeAdapter(repo), repo);
            var request = new DeleteCareHomeRequest
            {
                CareHomeId = careHomeId,
                ExecutingUser = Environment.UserName
            };

            var response = command.Execute(request);

            return response.Success;
        }

        private CareHomeDto ConvertToDto(GetCareHomeResponse response)
        {
            var dto = new CareHomeDto
            {
                Id = response.HomeId,
                Name = response.Name
            };

            return dto;
        }
    }
}

using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Queries
{
    public class GetStaffMemberQuery : ICommand<GetStaffMemberResponse, GetStaffMemberRequest>
    {
        private IGetStaffMemberAdapter _getStaffMemberAdapter;
        private IStaffMemberRepository _staffMemberRepository;

        public GetStaffMemberQuery(IGetStaffMemberAdapter adapter, IStaffMemberRepository repository)
        {
            _getStaffMemberAdapter = adapter;
            _staffMemberRepository = repository;
        }

        public GetStaffMemberResponse Execute(GetStaffMemberRequest request)
        {
            var staffMember = _getStaffMemberAdapter.GetStaffMember(request.StaffMemberId);
            var response = new GetStaffMemberResponse
            {
                StaffMember = staffMember
            };

            return response;
        }
    }
}

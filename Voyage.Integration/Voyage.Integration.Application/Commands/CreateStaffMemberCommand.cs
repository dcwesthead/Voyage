using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Commands
{
    public class CreateStaffMemberCommand : ICommand<StaffMemberResponse, StaffMemberRequest>
    { 
        private ICreateStaffMemberAdapter _createStaffMemberAdapter;
        private IStaffMemberRepository _staffMemberRepository;

        public CreateStaffMemberCommand(ICreateStaffMemberAdapter adapter, IStaffMemberRepository repository)
        {
            _createStaffMemberAdapter = adapter;
            _staffMemberRepository = repository;
        }

        public StaffMemberResponse Execute(StaffMemberRequest request)
        {
            var StaffMemberId = _createStaffMemberAdapter.CreateStaffMember(request.StaffMember,request.ExecutingUser);

            var response = new StaffMemberResponse()
            {
                StaffMemberId = StaffMemberId,
                Success = StaffMemberId > 0
            };

            return response;
        }
    }
}

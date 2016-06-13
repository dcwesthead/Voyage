using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Commands
{
    public class CreateStaffMemberCommand : ICommand<CreateStaffMemberResponse, CreateStaffMemberRequest>
    { 
        private ICreateStaffMemberAdapter _createStaffMemberAdapter;
        private IStaffMemberRepository _staffMemberRepository;

        public CreateStaffMemberCommand(ICreateStaffMemberAdapter adapter, IStaffMemberRepository repository)
        {
            _createStaffMemberAdapter = adapter;
            _staffMemberRepository = repository;
        }

        public CreateStaffMemberResponse Execute(CreateStaffMemberRequest request)
        {
            var StaffMemberId = _createStaffMemberAdapter.CreateStaffMember(request.StaffMember,request.ExecutingUser);

            var response = new CreateStaffMemberResponse()
            {
                StaffMemberId = StaffMemberId,
                Success = StaffMemberId > 0
            };

            return response;
        }
    }
}

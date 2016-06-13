using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Commands
{
    public class DeleteStaffMemberCommand : ICommand<ServiceResponse, DeleteStaffMemberRequest>
    {
        private IDeleteStaffMemberAdapter _deleteStaffMemberAdapter;
        private IStaffMemberRepository _staffMemberRepository;

        public DeleteStaffMemberCommand(IDeleteStaffMemberAdapter adapter, IStaffMemberRepository repository)
        {
            _deleteStaffMemberAdapter = adapter;
            _staffMemberRepository = repository;
        }

        public ServiceResponse Execute(DeleteStaffMemberRequest request)
        {
            var success = _deleteStaffMemberAdapter.DeleteStaffMember(request.StaffMemberId, request.ExecutingUser);

            var response = new ServiceResponse()
            {
                Success = success
            };

            return response;
        }
    }
}

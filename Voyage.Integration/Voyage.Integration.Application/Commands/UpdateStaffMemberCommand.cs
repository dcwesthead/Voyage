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
    public class UpdateStaffMemberCommand : ICommand<StaffMemberResponse, StaffMemberRequest>
    {
        private IUpdateStaffMemberAdapter _UpdateStaffMemberAdapter;
        private IStaffMemberRepository _staffMemberRepository;
        private Interfaces.Adapters.IUpdateStaffMemberAdapter _updateStaffMemberAdapter;

        public UpdateStaffMemberCommand(IUpdateStaffMemberAdapter adapter, IStaffMemberRepository repository)
        {
            _UpdateStaffMemberAdapter = adapter;
            _staffMemberRepository = repository;
        }

        public StaffMemberResponse Execute(StaffMemberRequest request)
        {
            var StaffMemberId = _UpdateStaffMemberAdapter.UpdateStaffMember(request.StaffMember,request.ExecutingUser);

            var response = new StaffMemberResponse()
            {
                StaffMemberId = StaffMemberId,
                Success = StaffMemberId == request.StaffMember.Id
            };

            return response;
        }
    }
}

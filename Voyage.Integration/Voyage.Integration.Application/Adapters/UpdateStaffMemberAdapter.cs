using System;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Adapters
{
    public class UpdateStaffMemberAdapter : IUpdateStaffMemberAdapter
    {
        IStaffMemberRepository _staffMemberRepository;

        public UpdateStaffMemberAdapter(IStaffMemberRepository staffMemberRepository)
        {
            _staffMemberRepository = staffMemberRepository;
        }

        public int UpdateStaffMember(StaffMemberDto staffMember, string executingUser)
        {
            if(string.IsNullOrEmpty(executingUser))
            {
                return UpdateStaffMemberInRepository(staffMember, Environment.UserName);
            }

            return UpdateStaffMemberInRepository(staffMember, executingUser);
        }

        private int UpdateStaffMemberInRepository(StaffMemberDto staffMember, string executingUser)
        {
            return _staffMemberRepository.UpdateStaffMember(staffMember, executingUser);
        }
    }
}

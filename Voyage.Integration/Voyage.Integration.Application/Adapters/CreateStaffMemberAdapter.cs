using System;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Adapters
{
    public class CreateStaffMemberAdapter : ICreateStaffMemberAdapter
    {
        IStaffMemberRepository _staffMemberRepository;

        public CreateStaffMemberAdapter(IStaffMemberRepository staffMemberRepository)
        {
            _staffMemberRepository = staffMemberRepository;
        }

        public int CreateStaffMember(StaffMemberDto staffMember, string executingUser)
        {
            if(string.IsNullOrEmpty(executingUser))
            {
                return CreateStaffMemberInRepository(staffMember, Environment.UserName);
            }

            return CreateStaffMemberInRepository(staffMember, executingUser);
        }

        private int CreateStaffMemberInRepository(StaffMemberDto staffMember, string executingUser)
        {
            return _staffMemberRepository.CreateStaffMember(staffMember, executingUser);
        }
    }
}

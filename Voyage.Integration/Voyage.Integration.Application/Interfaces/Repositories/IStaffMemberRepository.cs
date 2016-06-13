using System;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Repositories
{
    public interface IStaffMemberRepository
    {
        int CreateStaffMember(StaffMemberDto staffMember, string executingUser);
        int UpdateStaffMember(StaffMemberDto staffMember , string executingUser);
        bool DeleteStaffMember(int staffMemberId, string executingUser);
        StaffMemberDto GetStaffMemberName(int StaffMemberId);
    }
}

using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IUpdateStaffMemberAdapter
    {
        int UpdateStaffMember(StaffMemberDto staffMember, string executingUser);
    }
}

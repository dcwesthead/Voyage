using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface ICreateStaffMemberAdapter
    {
        int CreateStaffMember(StaffMemberDto staffMember, string executingUser);
    }
}

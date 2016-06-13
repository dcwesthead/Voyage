using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IGetStaffMemberAdapter
    {
        StaffMemberDto GetStaffMember(int homeId);
    }
}

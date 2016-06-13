namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface IDeleteStaffMemberAdapter
    {
        bool DeleteStaffMember(int staffMemberId, string executingUser);
    }
}

using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;

namespace Voyage.Integration.Application.Adapters
{
    public class DeleteStaffMemberAdapter : IDeleteStaffMemberAdapter
    {
        IStaffMemberRepository _staffMemberRepository;

        public DeleteStaffMemberAdapter(IStaffMemberRepository StaffMemberRepository)
        {
            _staffMemberRepository = StaffMemberRepository;
        }

        public bool DeleteStaffMember(int StaffMemberId, string executingUser)
        {
            return _staffMemberRepository.DeleteStaffMember(StaffMemberId, executingUser);
        }
    }
}

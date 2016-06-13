using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Requests
{
    [DataContract(Namespace = "http://tempuri.org/requests")]
    public class DeleteStaffMemberRequest
    {
        [DataMember]
        public int StaffMemberId { get; set; }

        [DataMember]
        public string ExecutingUser { get; set; }
    }
}

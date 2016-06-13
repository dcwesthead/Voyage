using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Requests
{
    [DataContract(Namespace = "http://tempuri.org/requests")]
    public class GetStaffMemberRequest
    {
        [DataMember]
        public int StaffMemberId { get; set; }
    }
}

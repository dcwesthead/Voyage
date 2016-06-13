using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace = "http://tempuri.org/responses")]
    public class CreateStaffMemberResponse : ServiceResponse
    {
        [DataMember]
        public int StaffMemberId { get; set; }
    }
}

using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace = "http://tempuri.org/responses")]
    public class StaffMemberResponse : ServiceResponse
    {
        [DataMember]
        public int StaffMemberId { get; set; }
    }
}

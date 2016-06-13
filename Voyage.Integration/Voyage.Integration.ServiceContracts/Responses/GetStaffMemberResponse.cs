using System.Runtime.Serialization;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace = "http://tempuri.org/responses")]
    public class GetStaffMemberResponse
    {
        [DataMember]
        public StaffMemberDto StaffMember { get; set; }
    }
}

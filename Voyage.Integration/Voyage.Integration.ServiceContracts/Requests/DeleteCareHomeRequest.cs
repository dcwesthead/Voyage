using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Requests
{
    [DataContract(Namespace = "http://tempuri.org/requests")]
    public class DeleteCareHomeRequest
    {
        [DataMember]
        public int CareHomeId { get; set; }

        [DataMember]
        public string ExecutingUser { get; set; }
    }
}

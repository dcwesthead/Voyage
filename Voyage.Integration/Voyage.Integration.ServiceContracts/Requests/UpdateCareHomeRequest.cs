using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Requests
{
    [DataContract(Namespace = "http://tempuri.org/requests")]
    public class UpdateCareHomeRequest
    {
        [DataMember]
        public int CareHomeId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ExecutingUser { get; set; }
    }
}

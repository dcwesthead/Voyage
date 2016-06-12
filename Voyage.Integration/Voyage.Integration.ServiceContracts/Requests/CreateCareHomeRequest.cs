using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Requests
{
    [DataContract(Namespace="http://tempuri.org/requests")]
    public class CreateCareHomeRequest 
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ExecutingUser { get; set; }
    }
}

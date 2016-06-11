using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace = "http://tempuri.org/responses")]
    public class GetHomeResponse
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string HomeId { get; set; }
    }
}

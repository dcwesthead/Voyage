using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace = "http://tempuri.org/responses")]
    public class GetCareHomeResponse
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int HomeId { get; set; }
    }
}

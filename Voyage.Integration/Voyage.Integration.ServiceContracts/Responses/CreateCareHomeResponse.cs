using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace="http://tempuri.org/responses")]
    public class CreateCareHomeResponse : ServiceResponse
    {
        [DataMember]
        public int HomeId { get; set; }
    }
}

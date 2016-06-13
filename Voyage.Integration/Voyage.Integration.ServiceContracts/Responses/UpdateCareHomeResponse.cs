using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace="http://tempuri.org/responses")]
    public class UpdateCareHomeResponse : ServiceResponse
    {
        [DataMember]
        public int CareHomeId { get; set; }
    }
}

using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace="http://tempuri.org/responses")]
    public class ServiceResponse
    {
        [DataMember]
        public virtual bool Success { get; set; }
    }
}

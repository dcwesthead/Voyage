using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Responses
{
    [DataContract(Namespace = "http://tempuri.org/responses")]
    public class CreateQualificationResponse : ServiceResponse
    {
        [DataMember]
        public int QualificationId { get; set; }
    }
}

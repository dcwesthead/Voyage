using System.Runtime.Serialization;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.ServiceContracts.Requests
{
    [DataContract(Namespace = "http://tempuri.org/requests")]
    public class CreateQualificationRequest
    {
        [DataMember]
        public QualificationDto Qualification { get; set; }

        [DataMember]
        public string ExecutingUser { get; set; }
    }
}

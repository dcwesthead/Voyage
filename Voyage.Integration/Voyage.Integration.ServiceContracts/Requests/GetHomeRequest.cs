using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Requests
{
    [DataContract(Namespace = "http://tempuri.org/requests")]
    public class GetHomeRequest
    {
        [DataMember]
        public int HomeId { get; set; }
    }
}

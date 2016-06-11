using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Dtos
{
    [DataContract(Namespace = "http://tempuri.org/dtos")]
    public class HomeDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}

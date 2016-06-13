using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Dtos
{
    [DataContract(Namespace = "http://tempuri.org/dtos")]
    public class QualificationDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}

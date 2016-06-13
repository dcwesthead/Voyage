using System;
using System.Runtime.Serialization;

namespace Voyage.Integration.ServiceContracts.Dtos
{
    [DataContract(Namespace = "http://tempuri.org/dtos")]
    public class StaffMemberDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Forename { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }
    }
}

using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Adapters
{
    public interface ICreateQualificationAdapter
    {
        int CreateQualification(QualificationDto qualification, string executingUser);
    }
}

using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Interfaces.Repositories
{
    public interface IQualificationRepository
    {
        int CreateQualification(QualificationDto qualification, string executingUser);
        int UpdateQualification(QualificationDto qualification, string executingUser);
        bool DeleteQualification(int qualificationId, string executingUser);
        QualificationDto GetQualification(int qualificationId);
    }
}

using System;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Application.Adapters
{
    public class CreateQualificationAdapter :ICreateQualificationAdapter
    {
        IQualificationRepository _QualificationRepository;

        public CreateQualificationAdapter(IQualificationRepository QualificationRepository)
        {
            _QualificationRepository = QualificationRepository;
        }

        public int CreateQualification(QualificationDto qualification, string executingUser)
        {
            if(string.IsNullOrEmpty(executingUser))
            {
                return CreateQualificationInRepository(qualification, Environment.UserName);
            }

            return CreateQualificationInRepository(qualification, executingUser);
        }

        private int CreateQualificationInRepository(QualificationDto qualification, string executingUser)
        {
            return _QualificationRepository.CreateQualification(qualification, executingUser);
        }
    }
}

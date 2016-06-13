using Voyage.Integration.Application.Interfaces;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.Commands
{
    public class CreateQualificationCommand : ICommand<CreateQualificationResponse, CreateQualificationRequest>
    {
        private ICreateQualificationAdapter _createQualificationAdapter;
        private IQualificationRepository _QualificationRepository;

        public CreateQualificationCommand(ICreateQualificationAdapter adapter, IQualificationRepository repository)
        {
            _createQualificationAdapter = adapter;
            _QualificationRepository = repository;
        }

        public CreateQualificationResponse Execute(CreateQualificationRequest request)
        {
            var qualificationId = _createQualificationAdapter.CreateQualification(request.Qualification, request.ExecutingUser);

            var response = new CreateQualificationResponse()
            {
                QualificationId = qualificationId,
                Success = qualificationId > 0
            };

            return response;
        }
    }
}

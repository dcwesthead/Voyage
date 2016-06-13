using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Application.Interfaces.Repositories;
using NSubstitute;
using Voyage.Integration.ServiceContracts.Dtos;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.Application.Interfaces.Adapters;

namespace Voyage.Integration.Application.UnitTests
{
    [TestClass]
    public class CreateQualificationCommandUnitTests
    {
        private CreateQualificationCommand _command;
        private IQualificationRepository _qualificationRepository;
        private ICreateQualificationAdapter _createQualificationAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _qualificationRepository = Substitute.For<IQualificationRepository>();
            _createQualificationAdapter = Substitute.For<ICreateQualificationAdapter>();
        }

        [TestMethod]
        public void WhenDetailsAreSavedForAQualificationeTheyAreCreatedInDataStorage()
        {
            var expectedName = "Test Qualification";
            var expectedDescription = "Longer description for qualification unit tests";
            var expectedExecutingUser = Environment.UserName;

            var expectedQualificationDto = new QualificationDto
            {
                Name = expectedName,
                Description = expectedDescription,
            };

            var expectedResponse = new CreateQualificationResponse
            {
                QualificationId = 1,
                Success = true
            };

            _createQualificationAdapter.CreateQualification(Arg.Is<QualificationDto>(expectedQualificationDto), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.QualificationId);
            _qualificationRepository.CreateQualification(Arg.Is<QualificationDto>(expectedQualificationDto), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.QualificationId);

            _command = new CreateQualificationCommand(_createQualificationAdapter, _qualificationRepository);

            var request = new CreateQualificationRequest
            {
                Qualification = expectedQualificationDto,
                ExecutingUser = expectedExecutingUser
            };

            var response = _command.Execute(request);

            Assert.AreEqual(expectedResponse.Success, response.Success);
            Assert.AreEqual(expectedResponse.QualificationId, response.QualificationId);
        }
    }
}

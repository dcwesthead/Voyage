using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Domain;
using Voyage.Integration.Application.Adapters;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Requests;

namespace Voyage.Integration.IntegrationTests
{
    [TestClass]
    public class UpdateCareHomeIntegrationTests
    {
        private UpdateCareHomeCommand _command;
        private IHomeRepository _homeRepository;
        private IUpdateCareHomeAdapter _UpdateHomeAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = new CareHomeRepository();
            _UpdateHomeAdapter = new UpdateCareHomeAdapter(_homeRepository);
            _command = new UpdateCareHomeCommand(_UpdateHomeAdapter, _homeRepository);
        }

        [TestMethod]
        public void WhenHomeDetailsAreSavedTheyAreUpdatedInDataStorage()
        {
            var expectedName = "Integration" + Guid.NewGuid().ToString();
            var expectedCareHomeId = 1;
            var expectedExecutingUser = Environment.UserName;
            var expectedResponse = new UpdateCareHomeResponse
            {
                CareHomeId = expectedCareHomeId,
                Success = true
            };

            _command = new UpdateCareHomeCommand(_UpdateHomeAdapter, _homeRepository);

            var request = new UpdateCareHomeRequest
            {
                CareHomeId = expectedCareHomeId,
                Name = expectedName,
                ExecutingUser = expectedExecutingUser
            };

            var response = _command.Execute(request);

            Assert.AreEqual(expectedResponse.Success, response.Success);
            Assert.AreEqual(expectedResponse.CareHomeId, response.CareHomeId);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.DataAccess;
using Voyage.Integration.Application.Adapters;
using Voyage.Integration.Application.Commands;

namespace Voyage.Integration.IntegrationTests
{
    [TestClass]
    public class CreateCareHomeIntegrationTests
    {
        private CreateCareHomeCommand _command;
        private IHomeRepository _homeRepository;
        private ICreateCareHomeAdapter _createHomeAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = new CareHomeRepository();
            _createHomeAdapter = new CreateCareHomeAdapter(_homeRepository);
            _command = new CreateCareHomeCommand(_createHomeAdapter, _homeRepository);
        }

        [TestMethod]
        public void WhenHomeDetailsAreSavedForANewHomeItIsCreatedInDataStorage()
        {
            var expectedName = "Test Home";
            var expectedExecutingUser = Environment.UserName;
            var expectedResponse = new CreateCareHomeResponse
            {
                HomeId = 1,
                Success = true
            };

            _command = new CreateCareHomeCommand(_createHomeAdapter, _homeRepository);

            var request = new CreateCareHomeRequest
            {
                Name = expectedName,
                ExecutingUser = expectedExecutingUser
            };

            var response = _command.Execute(request);

            Assert.AreEqual(expectedResponse.Success, response.Success);
            Assert.AreEqual(expectedResponse.HomeId, response.HomeId);
        }
    }
}

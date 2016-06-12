using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Voyage.Integration.Commands;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.UnitTests
{
    [TestClass]
    public class CreateHomeCommandUnitTests
    {
        private CreateHomeCommand _command;
        private IHomeRepository _homeRepository;
        private ICreateCareHomeAdapter _createHomeAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = Substitute.For<IHomeRepository>();
            _createHomeAdapter = Substitute.For<ICreateCareHomeAdapter>();
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

            _createHomeAdapter.CreateHome(Arg.Is<string>(expectedName), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.HomeId);
            _homeRepository.CreateHome(Arg.Is<string>(expectedName), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.HomeId);
            
            _command = new CreateHomeCommand(_createHomeAdapter, _homeRepository);

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

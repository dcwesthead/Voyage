using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.Application.Interfaces.Adapters;
using NSubstitute;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Requests;

namespace Voyage.Integration.Application.UnitTests
{
    [TestClass]
    public class UpdateCareHomeCommandUnitTests
    {
        private UpdateCareHomeCommand _command;
        private IHomeRepository _homeRepository;
        private IUpdateCareHomeAdapter _UpdateHomeAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = Substitute.For<IHomeRepository>();
            _UpdateHomeAdapter = Substitute.For<IUpdateCareHomeAdapter>();
        }

       
        [TestMethod]
        public void WhenHomeDetailsAreSavedTheyAreUpdatedInDataStorage()
        {
            
            var expectedName = "Test Home";
            var expectedCareHomeId = 1;
            var expectedExecutingUser = Environment.UserName;
            var expectedResponse = new UpdateCareHomeResponse
            {
                CareHomeId = expectedCareHomeId,
                Success = true
            };

            _UpdateHomeAdapter.UpdateHome(Arg.Is<int>(expectedCareHomeId), Arg.Is<string>(expectedName), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.CareHomeId);
            _homeRepository.UpdateHome(Arg.Is<int>(expectedCareHomeId), Arg.Is<string>(expectedName), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.CareHomeId);
            
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.ServiceContracts.Responses;

namespace Voyage.Integration.Application.UnitTests
{
    [TestClass]
    public class DeleteCareHomeCommandUnitTests
    {
        private DeleteCareHomeCommand _command;
        private IHomeRepository _homeRepository;
        private IDeleteCareHomeAdapter _DeleteHomeAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = Substitute.For<IHomeRepository>();
            _DeleteHomeAdapter = Substitute.For<IDeleteCareHomeAdapter>();
        }


        [TestMethod]
        public void WhenHomeDetailsAreRemovedTheyAreDeletedInDataStorage()
        {
            var expectedCareHomeId = 1;
            var expectedExecutingUser = Environment.UserName;
            var expectedResponse = new ServiceResponse
            {
                Success = true
            };

            _DeleteHomeAdapter.DeleteHome(Arg.Is<int>(expectedCareHomeId), Arg.Is<string>(expectedExecutingUser)).Returns<bool>(expectedResponse.Success);
            _homeRepository.DeleteHome(Arg.Is<int>(expectedCareHomeId), Arg.Is<string>(expectedExecutingUser)).Returns<bool>(expectedResponse.Success);

            _command = new DeleteCareHomeCommand(_DeleteHomeAdapter, _homeRepository);

            var request = new DeleteCareHomeRequest
            {
                CareHomeId = expectedCareHomeId,
                ExecutingUser = expectedExecutingUser
            };

            var response = _command.Execute(request);

            Assert.AreEqual(expectedResponse.Success, response.Success);
        }
    }
}

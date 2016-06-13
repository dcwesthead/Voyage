using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.DataAccess;
using Voyage.Integration.Application.Adapters;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Requests;

namespace Voyage.Integration.IntegrationTests
{
    [TestClass]
    public class DeleteCareHomeIntegrationTests
    {
        private DeleteCareHomeCommand _command;
        private IHomeRepository _homeRepository;
        private IDeleteCareHomeAdapter _DeleteHomeAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = new CareHomeRepository();
            _DeleteHomeAdapter = new DeleteCareHomeAdapter(_homeRepository);
            _command = new DeleteCareHomeCommand(_DeleteHomeAdapter, _homeRepository);
        }

        [TestMethod]
        public void WhenHomeDetailsAreRemovedTheyAreDeletedInDataStorage()
        {
            var expectedResponse = new ServiceResponse
            {
                Success = true
            };

            _command = new DeleteCareHomeCommand(_DeleteHomeAdapter, _homeRepository);

            var request = new DeleteCareHomeRequest
            {
                CareHomeId = 1,
                ExecutingUser = Environment.UserName
            };

            var response = _command.Execute(request);

            Assert.AreEqual(expectedResponse.Success, response.Success);
        }
    }
}

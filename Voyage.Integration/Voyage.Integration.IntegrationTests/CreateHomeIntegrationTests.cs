﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.Commands;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Requests;
using Voyage.Integration.Domain;
using Voyage.Integration.Application.Adapters;

namespace Voyage.Integration.IntegrationTests
{
    [TestClass]
    public class CreateHomeIntegrationTests
    {
        private CreateHomeCommand _command;
        private IHomeRepository _homeRepository;
        private ICreateHomeAdapter _createHomeAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = new HomeRepository();
            _createHomeAdapter = new CreateHomeAdapter(_homeRepository);
            _command = new CreateHomeCommand(_createHomeAdapter, _homeRepository);
        }

        [TestMethod]
        public void WhenHomeDetailsAreSavedForANewHomeItIsCreatedInDataStorage()
        {
            var expectedName = "Test Home";
            var expectedExecutingUser = Environment.UserName;
            var expectedResponse = new CreateHomeResponse
            {
                HomeId = 1,
                Success = true
            };

            _command = new CreateHomeCommand(_createHomeAdapter, _homeRepository);

            var request = new CreateHomeRequest
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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Voyage.Integration.Commands;

namespace Voyage.Integration.Application.UnitTests
{
    [TestClass]
    public class CreateHomeCommandUnitTests
    {
        private CreateHomeCommand _command;
        private IHomeRepository _homeRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeRepository = Substitute.For<IHomeRepository>();
        }

        [TestMethod]
        public void WhenHomeDetailsAreSavedForANewHomeItIsCreatedInDataStorage()
        {
            _command = new CreateHomeCommand(_homeRepository);

        }

        
    }
}

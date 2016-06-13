using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Application.Interfaces.Repositories;
using NSubstitute;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Dtos;
using Voyage.Integration.ServiceContracts.Requests;

namespace Voyage.Integration.Application.UnitTests
{
    [TestClass]
    public class DeleteStaffMemberCommandUnitTests
    {
        private DeleteStaffMemberCommand _command;
        private IStaffMemberRepository _staffMemberRepository;
        private IDeleteStaffMemberAdapter _deleteStaffMemberAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _staffMemberRepository = Substitute.For<IStaffMemberRepository>();
            _deleteStaffMemberAdapter = Substitute.For<IDeleteStaffMemberAdapter>();
        }

        [TestMethod]
        public void WhenPersonalDetailsAreRemovedForAStaffMemberTheyAreDeletedInDataStorage()
        {
            var expectedStaffMemberId = 1;
            var expectedExecutingUser = Environment.UserName;
            var expectedResponse = new ServiceResponse
            {
                 Success = true
            };

            _deleteStaffMemberAdapter.DeleteStaffMember(Arg.Is<int>(expectedStaffMemberId), Arg.Is<string>(expectedExecutingUser)).Returns<bool>(expectedResponse.Success);
            _staffMemberRepository.DeleteStaffMember(Arg.Is<int>(expectedStaffMemberId), Arg.Is<string>(expectedExecutingUser)).Returns<bool>(expectedResponse.Success);

            _command = new DeleteStaffMemberCommand(_deleteStaffMemberAdapter, _staffMemberRepository);

            var request = new DeleteStaffMemberRequest
            {
                StaffMemberId = expectedStaffMemberId,
                ExecutingUser = expectedExecutingUser
            };

            var response = _command.Execute(request);

            Assert.AreEqual(expectedResponse.Success, response.Success);
        }
    }
}

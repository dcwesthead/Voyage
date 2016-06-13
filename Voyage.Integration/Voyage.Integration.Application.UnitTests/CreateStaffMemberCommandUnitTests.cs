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
    public class CreateStaffMemberCommandUnitTests
    {
        private CreateStaffMemberCommand _command;
        private IStaffMemberRepository _staffMemberRepository;
        private ICreateStaffMemberAdapter _createStaffMemberAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _staffMemberRepository = Substitute.For<IStaffMemberRepository>();
            _createStaffMemberAdapter = Substitute.For<ICreateStaffMemberAdapter>();
        }

        [TestMethod]
        public void WhenPersonalDetailsAreSavedForAStaffMembereTheyAreCreatedInDataStorage()
        {
            var expectedForename = "Test";
            var expectedSurname = "Staffmember";
            var expectedDateOfBirth = DateTime.Today.AddYears(-18);
            var expectedExecutingUser = Environment.UserName;

            var expectedStaffMemberDto = new StaffMemberDto
            {
                Forename = expectedForename,
                Surname = expectedSurname,
                DateOfBirth = expectedDateOfBirth,
            };

            var expectedResponse = new CreateStaffMemberResponse
            {
                StaffMemberId = 1,
                Success = true
            };

            _createStaffMemberAdapter.CreateStaffMember(Arg.Is<StaffMemberDto>(expectedStaffMemberDto), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.StaffMemberId);
            _staffMemberRepository.CreateStaffMember(Arg.Is<StaffMemberDto>(expectedStaffMemberDto), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.StaffMemberId);

            _command = new CreateStaffMemberCommand(_createStaffMemberAdapter, _staffMemberRepository);

            var request = new CreateStaffMemberRequest
            {
                StaffMember = expectedStaffMemberDto,
                ExecutingUser = expectedExecutingUser
            };

            var response = _command.Execute(request);

            Assert.AreEqual(expectedResponse.Success, response.Success);
            Assert.AreEqual(expectedResponse.StaffMemberId, response.StaffMemberId);
        }
    }
}

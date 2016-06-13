using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Integration.Application.Interfaces.Repositories;
using NSubstitute;
using Voyage.Integration.ServiceContracts.Dtos;
using Voyage.Integration.Application.Commands;
using Voyage.Integration.Application.Interfaces.Adapters;
using Voyage.Integration.ServiceContracts.Responses;
using Voyage.Integration.ServiceContracts.Requests;

namespace Voyage.Integration.Application.UnitTests
{
    [TestClass]
    public class UpdateStaffMemberCommandUnitTests
    {
        private UpdateStaffMemberCommand _command;
        private IStaffMemberRepository _staffMemberRepository;
        private IUpdateStaffMemberAdapter _updateStaffMemberAdapter;

        [TestInitialize]
        public void TestInitialize()
        {
            _staffMemberRepository = Substitute.For<IStaffMemberRepository>();
            _updateStaffMemberAdapter = Substitute.For<IUpdateStaffMemberAdapter>();
        }

        [TestMethod]
        public void WhenPersonalDetailsAreSavedForAStaffMembereTheyAreUpdatedInDataStorage()
        {
            var expectedForename = "Test";
            var expectedSurname = "Staffmember";
            var expectedDateOfBirth = DateTime.Today.AddYears(-18);
            var expectedExecutingUser = Environment.UserName;

            var expectedStaffMemberDto = new StaffMemberDto
            {
                Id = 1,
                Forename = expectedForename,
                Surname = expectedSurname,
                DateOfBirth = expectedDateOfBirth,
            };

            var expectedResponse = new StaffMemberResponse
            {
                StaffMemberId = 1,
                Success = true
            };

            _updateStaffMemberAdapter.UpdateStaffMember(Arg.Is<StaffMemberDto>(expectedStaffMemberDto), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.StaffMemberId);
            _staffMemberRepository.UpdateStaffMember(Arg.Is<StaffMemberDto>(expectedStaffMemberDto), Arg.Is<string>(expectedExecutingUser)).Returns<int>(expectedResponse.StaffMemberId);

            _command = new UpdateStaffMemberCommand(_updateStaffMemberAdapter, _staffMemberRepository);

            var request = new StaffMemberRequest
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

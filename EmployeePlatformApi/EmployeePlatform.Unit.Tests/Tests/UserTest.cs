using EmployeePlatform.Business;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Unit.Tests.MockRepository.Areas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EmployeePlatform.Unit.Tests.Tests
{
    public class UserTest
    {
        UserBL _userBL;

        [SetUp]
        public void Setup()
        {
            Mock<IUserRepository> _userRepository = new UserRepositoryMock()._userRepository;
            _userBL = new UserBL(_userRepository.Object);
        }

        [Test]
        public async Task Test_get_user_by_id()
        {
            var result = await _userBL.GetById(1);
            result.Should().NotBeNull();
        }


        [Test]
        public async Task Test_get_all_user()
        {
            var result = await _userBL.GetAll();

            result.Should().NotBeNullOrEmpty();
        }

    }
}
using EmployeePlatform.DataAccess.Repositories.Contracts;
using Moq;
using System;

namespace EmployeePlatform.Unit.Tests.MockRepository.Areas
{
    public class UserRepositoryMock
    {
        public Mock<IUserRepository> _userRepository { get; set; }

        public UserRepositoryMock()
        {
            _userRepository = new Mock<IUserRepository>();
            Setup();
        }

        private void Setup()
        {
            _userRepository.Setup((x) => x.GetAll()).ReturnsAsync(Stubs.UserStub.List(5));
            _userRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(Stubs.UserStub.data);
        }
    }
}

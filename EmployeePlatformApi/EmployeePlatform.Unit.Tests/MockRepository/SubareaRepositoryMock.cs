using EmployeePlatform.DataAccess.Repositories.Contracts;
using Moq;
using System;

namespace EmployeePlatform.Unit.Tests.MockRepository.Areas
{
    public class SubareaRepositoryMock
    {
        public Mock<ISubareaRepository> _subareaRepository { get; set; }

        public SubareaRepositoryMock()
        {
            _subareaRepository = new Mock<ISubareaRepository>();
            Setup();
        }

        private void Setup()
        {
            _subareaRepository.Setup((x) => x.GetAll()).ReturnsAsync(Stubs.SubareaStub.List(15));
            _subareaRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(Stubs.SubareaStub.data);
        }
    }
}

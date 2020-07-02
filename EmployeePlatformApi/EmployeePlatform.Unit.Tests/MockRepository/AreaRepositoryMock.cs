using EmployeePlatform.DataAccess.Repositories.Contracts;
using Moq;
using System;

namespace EmployeePlatform.Unit.Tests.MockRepository.Areas
{
    public class AreaRepositoryMock
    {
        public Mock<IAreaRepository> _areaRepository { get; set; }

        public AreaRepositoryMock()
        {
            _areaRepository = new Mock<IAreaRepository>();
            Setup();
        }

        private void Setup()
        {
            _areaRepository.Setup((x) => x.GetAll()).ReturnsAsync(Stubs.AreaStub.List(15));
            _areaRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(Stubs.AreaStub.data);
        }
    }
}

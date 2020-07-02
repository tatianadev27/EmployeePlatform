using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using Moq;
using System;

namespace EmployeePlatform.Unit.Tests.MockRepository.Areas
{
    public class EmployeeRepositoryMock
    {
        public Mock<IEmployeeRepository> _employeeRepository { get; set; }

        public EmployeeRepositoryMock()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            Setup();
        }

        private void Setup()
        {
            _employeeRepository.Setup((x) => x.GetAll()).ReturnsAsync(Stubs.EmployeeStub.List(15));
            _employeeRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(Stubs.EmployeeStub.data);
            _employeeRepository.Setup((x) => x.Add(It.IsAny<EmployeeDTO>())).ReturnsAsync(Stubs.EmployeeStub.data);
            _employeeRepository.Setup((x) => x.Update(It.IsAny<EmployeeDTO>())).ReturnsAsync(Stubs.EmployeeStub.data);
        }
    }
}

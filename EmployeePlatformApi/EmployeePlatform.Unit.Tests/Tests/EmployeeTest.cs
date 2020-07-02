using EmployeePlatform.Business;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Unit.Tests.FakerData;
using EmployeePlatform.Unit.Tests.MockRepository.Areas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePlatform.Unit.Tests.Tests
{
    public class TestEmployeeBL
    {
        EmployeeBL _employeeBL;

        [SetUp]
        public void Setup()
        {
            Mock<IEmployeeRepository> _employeeRepository = new EmployeeRepositoryMock()._employeeRepository;
            _employeeBL = new EmployeeBL(_employeeRepository.Object);
        }

        [Test]
        public async Task Test_get_employee_by_id()
        {
            var result = await _employeeBL.GetById(1);
            result.Should().NotBeNull();
        }

        [Test]
        public async Task Test_get_all_employee()
        {
            var result = await _employeeBL.GetAll();

            result.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Test_add_employee()
        {
            var result = await _employeeBL.Add(new EmployeeData().GenerateData(1).FirstOrDefault());
            result.Should().NotBeNull();
        }

        [Test]
        public async Task Test_update_employee()
        {
            var result = await _employeeBL.Update(new EmployeeData().GenerateData(1).FirstOrDefault());
            result.Should().NotBeNull();
        }
    }
}
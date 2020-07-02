using EmployeePlatform.Business;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Unit.Tests.MockRepository.Areas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EmployeePlatform.Unit.Tests.Tests
{
    public class TestAreaBL
    {
        AreaBL _areaBL;

        [SetUp]
        public void Setup()
        {
            Mock<IAreaRepository> _areaRepository = new AreaRepositoryMock()._areaRepository;
            _areaBL = new AreaBL(_areaRepository.Object);
        }

        [Test]
        public async Task Test_get_area_by_id()
        {
            var result = await _areaBL.GetById(1);
            result.Should().NotBeNull();
        }


        [Test]
        public async Task Test_get_all_area()
        {
            var result = await _areaBL.GetAll();

            result.Should().NotBeNullOrEmpty();
        }

    }
}
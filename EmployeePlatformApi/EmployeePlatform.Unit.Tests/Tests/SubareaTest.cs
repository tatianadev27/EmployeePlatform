using EmployeePlatform.Business;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Unit.Tests.MockRepository.Areas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EmployeePlatform.Unit.Tests.Tests
{
    public class TestSubareaBL
    {
        SubareaBL _subareaBL;

        [SetUp]
        public void Setup()
        {
            Mock<ISubareaRepository> _SubareaRepository = new SubareaRepositoryMock()._subareaRepository;
            _subareaBL = new SubareaBL(_SubareaRepository.Object);
        }

        [Test]
        public async Task Test_get_Subarea_by_id()
        {
            var result = await _subareaBL.GetById(1);
            result.Should().NotBeNull();
        }


        [Test]
        public async Task Test_get_all_Subarea()
        {
            var result = await _subareaBL.GetAll();

            result.Should().NotBeNullOrEmpty();
        }

    }
}
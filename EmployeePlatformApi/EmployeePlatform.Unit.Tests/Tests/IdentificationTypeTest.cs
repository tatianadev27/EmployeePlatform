using EmployeePlatform.Business;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Unit.Tests.MockRepository.Areas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EmployeePlatform.Unit.Tests.Tests
{

    public class TestIdentificationTypeBL
    {
        IdentificationTypeBL _identificationTypeBL;


        [SetUp]
        public void Setup()
        {
            Mock<IIdentificationTypeRepository> _identificationTypeRepository = new IdentificationTypeRepositoryMock()._identificationTypeRepository;
            _identificationTypeBL = new IdentificationTypeBL(_identificationTypeRepository.Object);
        }

        [Test]
        public async Task Test_get_IdentificationType_by_id()
        {
            var result = await _identificationTypeBL.GetById(1);

            result.Should().NotBeNull();
            result.Id.Should().NotBe(2);
            result.Name.Should().NotBe("Nit");
            result.Name.Should().Be("Cedula Ciudadania");
        }


        [Test]
        public async Task Test_get_all_IdentificationType()
        {
            var result = await _identificationTypeBL.GetAll();

            result.Should().NotBeNullOrEmpty();
        }
    }
}

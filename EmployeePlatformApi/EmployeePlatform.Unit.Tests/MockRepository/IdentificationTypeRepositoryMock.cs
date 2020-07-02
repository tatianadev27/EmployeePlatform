using EmployeePlatform.DataAccess.Repositories.Contracts;
using Moq;
using System;

namespace EmployeePlatform.Unit.Tests.MockRepository.Areas
{
    public class IdentificationTypeRepositoryMock
    {
        public Mock<IIdentificationTypeRepository> _identificationTypeRepository { get; set; }

        public IdentificationTypeRepositoryMock()
        {
            _identificationTypeRepository = new Mock<IIdentificationTypeRepository>();
            Setup();
        }

        private void Setup()
        {
            _identificationTypeRepository.Setup((x) => x.GetAll()).ReturnsAsync(Stubs.IdentificationTypeStub.List);
            _identificationTypeRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(Stubs.IdentificationTypeStub.data);
        }
    }
}

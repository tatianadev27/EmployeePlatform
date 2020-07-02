using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Linq;
using EmployeePlatform.Unit.Tests.FakerData;

namespace EmployeePlatform.Unit.Tests.Stubs
{
    public static class IdentificationTypeStub
    {

        public static IdentificationTypeDTO data = new IdentificationTypeData().GenerateData().First();

        public static IEnumerable<IdentificationTypeDTO> List = new IdentificationTypeData().GenerateData();
    }
}

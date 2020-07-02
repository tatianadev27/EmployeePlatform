using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Linq;
using EmployeePlatform.Unit.Tests.FakerData;

namespace EmployeePlatform.Unit.Tests.Stubs
{
    public static class SubareaStub
    {

        public static SubareaDTO data = new SubareaData().GenerateData(1).First();

        public static IEnumerable<SubareaDTO> List(int quantity) => new SubareaData().GenerateData(quantity);
    }
}

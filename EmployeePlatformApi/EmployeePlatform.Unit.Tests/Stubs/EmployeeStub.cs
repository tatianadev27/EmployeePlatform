using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Linq;
using EmployeePlatform.Unit.Tests.FakerData;

namespace EmployeePlatform.Unit.Tests.Stubs
{
    public static class EmployeeStub
    {

        public static EmployeeDTO data = new EmployeeData().GenerateData(1).First();

        public static IEnumerable<EmployeeDTO> List(int quantity) => new EmployeeData().GenerateData(quantity);
    }
}

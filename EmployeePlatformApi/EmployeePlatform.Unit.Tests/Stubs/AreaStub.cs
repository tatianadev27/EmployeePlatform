using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Linq;
using EmployeePlatform.Unit.Tests.FakerData;

namespace EmployeePlatform.Unit.Tests.Stubs
{
    public static class AreaStub
    {

        public static AreaDTO data = new AreaData().GenerateData(1).First();

        public static IEnumerable<AreaDTO> List(int quantity) => new AreaData().GenerateData(quantity);
    }
}

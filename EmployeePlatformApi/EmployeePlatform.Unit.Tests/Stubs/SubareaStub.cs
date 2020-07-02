using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Linq;
using EmployeePlatform.Unit.Tests.FakerData;

namespace EmployeePlatform.Unit.Tests.Stubs
{
    public static class UserStub
    {

        public static UserDTO data = new UserData().GenerateData(1).First();

        public static IEnumerable<UserDTO> List(int quantity) => new UserData().GenerateData(quantity);
    }
}

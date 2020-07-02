using EmployeePlatform.Entities;
using FakerDotNet;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePlatform.Unit.Tests.FakerData
{
    public class UserData
    {
        public IEnumerable<UserDTO> GenerateData(int quantity)
        {
            List<UserDTO> list = new List<UserDTO>();
            for (int i = 0; i < quantity; i++)
            {  
                UserDTO data = new UserDTO
                {
                    Id = i,
                    FirstName = Faker.Name.FirstName(),
                    LastName = Faker.Name.LastName(),
                    CreatedBy = Faker.Name.Name(),
                    Email = Faker.Internet.Email(),
                    Password = BCrypt.Net.BCrypt.HashPassword(Faker.Number.Number(6)),
                    IdentificationNumber = Faker.Number.Number(6),
                    ModifiedBy = Faker.Name.Name(),
                    Role = "admin"
                };
            list.Add(data);
        }
            return list.AsEnumerable();
        }

}
}

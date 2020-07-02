using EmployeePlatform.Entities;
using FakerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePlatform.Unit.Tests.FakerData
{
    public class EmployeeData
    {
        public IEnumerable<EmployeeDTO> GenerateData(int quantity)
        {
            Random random = new Random();
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            for (int i = 0; i < quantity; i++)
            {
                EmployeeDTO data = new EmployeeDTO
                {
                    Id = i,
                    FirstName = Faker.Name.FirstName(),
                    LastName = Faker.Name.LastName(),
                    CreatedBy = Faker.Name.Name(),
                    ModifiedBy = Faker.Name.Name(),
                    SubareaId = int.Parse(Faker.Number.Number(1)),
                    IdentificationNumber = Faker.Number.Number(6),
                    IdentificationTypeId = int.Parse(Faker.Number.Number(1)),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };
            list.Add(data);
        }
            return list.AsEnumerable();
        }

}
}

using EmployeePlatform.Entities;
using FakerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePlatform.Unit.Tests.FakerData
{
    public class AreaData
    {
        public IEnumerable<AreaDTO> GenerateData(int quantity)
        {
            List<AreaDTO> list = new List<AreaDTO>();
            for (int i = 0; i < quantity; i++)
            {
                AreaDTO data = new AreaDTO()
                {
                    Id = i,
                    Name = Faker.Commerce.Department(),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    CreatedBy = Faker.Name.FirstName(),
                    ModifiedBy = Faker.Name.FirstName()
                };
                list.Add(data);
            }
            return list.AsEnumerable();
        }

    }
}

using EmployeePlatform.Entities;
using FakerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePlatform.Unit.Tests.FakerData
{
    public class SubareaData
    {
        public IEnumerable<SubareaDTO> GenerateData(int quantity)
        {
            List<SubareaDTO> list = new List<SubareaDTO>();
            for (int i = 0; i < quantity; i++)
            {
                SubareaDTO data = new SubareaDTO()
                {
                    Id = i,
                    Name = Faker.Commerce.Department(),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    CreatedBy = Faker.Name.FirstName(),
                    ModifiedBy = Faker.Name.FirstName(),
                    AreaId = int.Parse(Faker.Number.Number(1))
                };
                list.Add(data);
            }
            return list.AsEnumerable();
        }

    }
}

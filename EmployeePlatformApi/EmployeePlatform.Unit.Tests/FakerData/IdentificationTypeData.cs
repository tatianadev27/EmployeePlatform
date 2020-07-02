using EmployeePlatform.Entities;
using FakerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePlatform.Unit.Tests.FakerData
{
    public class IdentificationTypeData
    {
        public IEnumerable<IdentificationTypeDTO> GenerateData()
        {
            List<IdentificationTypeDTO> list = new List<IdentificationTypeDTO>();

            string identificationTypes = "Cedula Ciudadania, Cedula Extranjera, Tarjeta Identidad, Rut, Nit";
            int loop = 0;
            foreach (var identificationType in identificationTypes.Split(","))
            {
                loop++;
                IdentificationTypeDTO data = new IdentificationTypeDTO
                {
                    Id = loop,
                    Name = identificationType,
                    CreatedBy = Faker.Name.Name(),
                    ModifiedBy = Faker.Name.Name()
                };
                list.Add(data);
            }
            return list.AsEnumerable();
        }

    }
}

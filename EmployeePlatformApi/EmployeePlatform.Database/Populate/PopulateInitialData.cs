using EmployeePlatform.Database.Models;
using FakerDotNet;
using System;
using System.Linq;

namespace EmployeePlatform.Database.Populate
{
    public static class PopulateInitialData
    {
        private static EmployeePlatformContext _db;
        public static void PopulateData(this EmployeePlatformContext db)
        {
            _db = db;
            PopulateUser();
            PopulateIdentificationTypes();
            PopulateAreas();
            PopulateEmployees();
        }

        public static void PopulateUser()
        {
            if (_db.Users.ToList().Count <= 0)
            {
                User newUser = new User
                {
                    FirstName = Faker.Name.FirstName(),
                    LastName = Faker.Name.LastName(),
                    CreatedBy = Faker.Name.Name(),
                    Email = "Admin@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                    IdentificationNumber = Faker.Number.Number(6),
                    ModifiedBy = Faker.Name.Name(),
                    Role = "admin"
                };
                _db.Users.Add(newUser);
                _db.SaveChanges();
            }

        }

        public static void PopulateIdentificationTypes()
        {
            if (_db.IdentificationTypes.ToList().Count <= 0)
            {
                string identificationTypes = "Cedula Ciudadania, Cedula Extranjera, Tarjeta Identidad, Rut, Nit";
                foreach (var identificationType in identificationTypes.Split(","))
                {
                    IdentificationType newIdentificationType = new IdentificationType
                    {
                        Name = identificationType,
                        CreatedBy = Faker.Name.Name(),
                        ModifiedBy = Faker.Name.Name()
                    };
                    _db.IdentificationTypes.Add(newIdentificationType);
                    _db.SaveChanges();
                }
            }

        }
        public static void PopulateAreas()
        {
            if (_db.Areas.ToList().Count <= 0)
            {
                string areas = "Marketing,Produccion,Informatica";
                foreach (var area in areas.Split(","))
                {
                    Area newArea = new Area
                    {
                        Name = area,
                        CreatedBy = Faker.Name.Name(),
                        ModifiedBy = Faker.Name.Name()
                    };
                    _db.Areas.Add(newArea);
                    _db.SaveChanges();
                    PopulateSubareas(newArea.Id, area);
                }
            }

        }

        public static void PopulateSubareas(int areaId, string areaName)
        {
            string subareas = "";
            switch (areaName)
            {
                case "Marketing":
                    subareas = "Social media,CEO,Redactor";
                    break;
                case "Produccion":
                    subareas = "Analista,Supervisor";
                    break;
                case "Informatica":
                    subareas = "Desarrollo,Diseño,Testing";
                    break;
                default:
                    break;
            }
            foreach (var subarea in subareas.Split(","))
            {
                Subarea newSubarea = new Subarea
                {
                    Name = subarea,
                    AreaId = areaId,
                    CreatedBy = Faker.Name.Name(),
                    ModifiedBy = Faker.Name.Name(),
                };
                _db.Subareas.Add(newSubarea);
                _db.SaveChanges();
            }
        }


        public static void PopulateEmployees()
        {
            if (_db.Employees.ToList().Count <= 0)
            {
                for (int i = 0; i < 40; i++)
                {
                    Random rand = new Random();
                    int subareaRamdoNumber = rand.Next(1, _db.Subareas.Count());
                    int identificationRamdoNumber = rand.Next(1, _db.IdentificationTypes.Count());

                    Employee newEmployee = new Employee
                    {
                        FirstName = Faker.Name.FirstName(),
                        LastName = Faker.Name.LastName(),
                        IdentificationNumber = Faker.Number.Number(10),
                        IdentificationTypeId = _db.IdentificationTypes.OrderBy(r => Guid.NewGuid()).Skip(identificationRamdoNumber).Take(1).FirstOrDefault().Id,
                        SubareaId = _db.Subareas.OrderBy(r => Guid.NewGuid()).Skip(subareaRamdoNumber).Take(1).FirstOrDefault().Id,
                        CreatedBy = Faker.Name.Name(),
                        ModifiedBy = Faker.Name.Name()
                    };
                    _db.Employees.Add(newEmployee);
                    _db.SaveChanges();
                }
            }

        }
    }
}

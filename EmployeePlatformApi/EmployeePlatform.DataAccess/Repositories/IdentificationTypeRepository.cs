using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePlatform.DataAccess.Mappers;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Database;
using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeePlatform.DataAccess.Repositories
{
    public class IdentificationTypeRepository : IIdentificationTypeRepository
    {
        private readonly EmployeePlatformContext _db;

        public IdentificationTypeRepository(EmployeePlatformContext db)
        {
            _db = db;
        }

        public Task<IdentificationTypeDTO> Add(IdentificationTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentificationTypeDTO>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<IdentificationType> query = _db.IdentificationTypes.FromSqlRaw($"spGetIdentificationTypes").AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<IdentificationType, IdentificationTypeDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<IdentificationTypeDTO> GetById(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<IdentificationType> query = _db.IdentificationTypes.FromSqlRaw($"spGetIdentificationTypes").AsEnumerable();
                    IdentificationType data = query.Count() > 0 ? query.Where(x => x.Id == id).FirstOrDefault() : null;
                    return data != null ? new GenericMapper<IdentificationType, IdentificationTypeDTO>().Map(data) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<IdentificationTypeDTO> Update(IdentificationTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

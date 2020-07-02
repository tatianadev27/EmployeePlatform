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
    public class AreaRepository : IAreaRepository
    {
        private readonly EmployeePlatformContext _db;

        public AreaRepository(EmployeePlatformContext db)
        {
            _db = db;
        }

        public Task<AreaDTO> Add(AreaDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AreaDTO>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Area> query = _db.Areas.FromSqlRaw($"spGetAreas").AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<Area, AreaDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<AreaDTO> GetById(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Area> query = _db.Areas.FromSqlRaw($"spGetAreas").AsEnumerable();
                    Area data = query.Count() > 0 ? query.Where(x => x.Id == id).FirstOrDefault() : null;
                    return data != null ? new GenericMapper<Area, AreaDTO>().Map(data) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<AreaDTO> Update(AreaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

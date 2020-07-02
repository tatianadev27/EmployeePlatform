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
    public class SubareaRepository : ISubareaRepository
    {
        private readonly EmployeePlatformContext _db;

        public SubareaRepository(EmployeePlatformContext db)
        {
            _db = db;
        }

        public Task<SubareaDTO> Add(SubareaDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubareaDTO>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Subarea> query = _db.Subareas.FromSqlRaw($"spGetSubAreas").AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<Subarea, SubareaDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<IEnumerable<SubareaDTO>> GetAllForArea(int areaId)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Subarea> query = _db.Subareas.FromSqlRaw($"spGetSubAreas").AsEnumerable().Where(x => x.AreaId == areaId);
                    return query.Count() > 0 ? new GenericMapper<Subarea, SubareaDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<SubareaDTO> GetById(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Subarea> query = _db.Subareas.FromSqlRaw($"spGetSubAreas").AsEnumerable();
                    Subarea data = query.Count() > 0 ? query.Where(x => x.Id == id).FirstOrDefault() : null;
                    return data != null ? new GenericMapper<Subarea, SubareaDTO>().Map(data) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<SubareaDTO> Update(SubareaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

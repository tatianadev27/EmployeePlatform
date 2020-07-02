using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EmployeePlatform.DataAccess.Mappers;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Database;
using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeePlatform.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeePlatformContext _db;

        public EmployeeRepository(EmployeePlatformContext db)
        {
            _db = db;
        }

        public Task<IEnumerable<EmployeeDTO>> GetAll(int pageSize, int page, string filter)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Employee> query = _db.Employees.FromSqlInterpolated($"spGetEmployees @PageSize={pageSize}, @Page={page}, @Filter={filter}").AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<Employee, EmployeeDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }



        public Task<IEnumerable<EmployeeDTO>> GetAll(string filter)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Employee> query = _db.Employees.FromSqlInterpolated($"spGetEmployeesFilter @Filter={filter}").AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<Employee, EmployeeDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Employee> query = _db.Employees.AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<Employee, EmployeeDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<EmployeeDTO> GetById(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<Employee> query = _db.Employees.FromSqlInterpolated($"spGetEmployeesFilter").AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<Employee, EmployeeDTO>().MapList(query).Where(x => x.Id == id).FirstOrDefault() : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<EmployeeDTO> Add(EmployeeDTO entity)
        {
            return Task.Run(() =>
            {
                try
                {
                    SqlParameter Id = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    int result = _db.Database.ExecuteSqlInterpolated($"EXEC dbo.spCreateEmployee @CreatedAt={entity.CreatedAt}, @ModifiedAt={entity.ModifiedAt},@CreatedBy={entity.CreatedBy},@ModifiedBy={entity.ModifiedBy}, @IdentificationNumber={entity.IdentificationNumber}, @IdentificationTypeId={entity.IdentificationTypeId}, @FirstName={entity.FirstName}, @LastName={entity.LastName}, @SubareaId={entity.SubareaId}, @Id={Id} out");
                    entity.Id = int.Parse(Id.Value.ToString());
                    return entity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<EmployeeDTO> Update(EmployeeDTO entity)
        {
            return Task.Run(() =>
            {
                try
                {
                    int result = _db.Database.ExecuteSqlInterpolated($"EXEC dbo.spUpdateEmployee  @ModifiedAt={entity.ModifiedAt},@ModifiedBy={entity.ModifiedBy}, @IdentificationNumber={entity.IdentificationNumber}, @IdentificationTypeId={entity.IdentificationTypeId}, @FirstName={entity.FirstName}, @LastName={entity.LastName}, @SubareaId={entity.SubareaId}, @Id={entity.Id}");
                    return entity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

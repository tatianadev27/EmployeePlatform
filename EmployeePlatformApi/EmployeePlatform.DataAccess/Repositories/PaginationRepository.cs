using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Database;
using EmployeePlatform.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace EmployeePlatform.DataAccess.Repositories
{
    public class PaginationRepository: IPaginationRepository
    {
        private EmployeePlatformContext _db;

        public PaginationRepository(EmployeePlatformContext db)
        {
            _db = db;
        }

        public Task<PaginationDTO> GetPaginationData(int pageSize, string filter)
        {
            return Task.Run(() =>
           {
               try
               {
                   SqlParameter TotalRows = new SqlParameter()
                   {
                       ParameterName = "@TotalRows",
                       SqlDbType = SqlDbType.Int,
                       Direction = ParameterDirection.Output
                   };
                   SqlParameter TotalPage = new SqlParameter()
                   {
                       ParameterName = "@TotalPage",
                       SqlDbType = SqlDbType.Int,
                       Direction = ParameterDirection.Output
                   };
                   SqlParameter Error = new SqlParameter()
                   {
                       ParameterName = "@Error",
                       SqlDbType = SqlDbType.Bit,
                       Direction = ParameterDirection.Output
                   };
                   int result = _db.Database.ExecuteSqlInterpolated($"EXEC dbo.spGetPaginationTable @Filter={filter}, @PageSize={pageSize},@TotalRows={TotalRows} OUT,@TotalPage={TotalPage} OUT,@Error ={Error} OUT");

                   return new PaginationDTO()
                   {
                       TotalPages = int.Parse(TotalPage.Value.ToString()),
                       TotalRecords = int.Parse(TotalRows.Value.ToString()),
                       Error = bool.Parse(Error.Value.ToString()),
                   };
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"Internal Error: {ex}");
               }
               return null;
           });
        }
    }
}

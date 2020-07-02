using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class spGetEmployeesFilter : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE [dbo].[spGetEmployeesFilter]
	@Filter NVARCHAR(100) =  NULL
AS
BEGIN

    SET NOCOUNT ON;
    SELECT Id, IdentificationNumber, FirstName, LastName, CreatedAt, ModifiedAt, CreatedBy, IdentificationTypeId, SubareaId, ModifiedBy	
	FROM dbo.Employees 
	WHERE 
	((Lower(FirstName) LIKE '%'+Lower(@Filter)+'%') or @Filter IS NULL) OR
	(Lower(LastName) LIKE '%'+Lower(@Filter)+'%'or @Filter IS NULL) OR
	(Lower(IdentificationNumber) LIKE '%'+Lower(@Filter)+'%' or @Filter IS NULL)
	
END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetEmployeesFilter";
            migrationBuilder.Sql(procedure);

        }
    }
}

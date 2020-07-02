using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class spGetEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE [dbo].[spGetEmployees]
    @PageSize INT,
	@Page INT,
	@Filter NVARCHAR(100) =  NULL
AS
BEGIN

    SET NOCOUNT ON;
	SELECT Id, IdentificationNumber, FirstName, LastName, CreatedAt, ModifiedAt, CreatedBy, IdentificationTypeId, SubareaId, ModifiedBy	
	FROM dbo.Employees 
	WHERE 
	((Lower(FirstName) LIKE '%'+Lower(@Filter)+'%') or @Filter IS NULL) OR
	(Lower(LastName) LIKE '%'+Lower(@Filter)+'%'or @Filter IS NULL) OR
	(Lower(FirstName) +' '+ Lower(LastName)  LIKE  '%'+Lower(@Filter)+'%'or @Filter IS NULL) OR
	(Lower(IdentificationNumber) LIKE '%'+Lower(@Filter)+'%' or @Filter IS NULL)
	ORDER BY Id
	OFFSET (@Page - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
	
END
";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetEmployeesFilter";
            migrationBuilder.Sql(procedure);

        }
    }
}
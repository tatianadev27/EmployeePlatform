using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class spGetPaginationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE [dbo].[spGetPaginationTable]
    @Filter NVARCHAR(50),
    @PageSize INT,
	@TotalRows INT OUT,
	@TotalPage INT OUT,
	@Error BIT OUT
AS
BEGIN
    SET NOCOUNT ON;
	declare @Sql nvarchar(4000);
	declare @Total float;

	BEGIN TRY
	 SELECT @TotalRows = COUNT(*) 
		 FROM dbo.Employees 
		 WHERE 
		((Lower(FirstName) LIKE '%'+Lower(@Filter)+'%') or @Filter IS NULL) OR
		(Lower(LastName) LIKE '%'+Lower(@Filter)+'%'or @Filter IS NULL) OR
		(Lower(FirstName) +' '+ Lower(LastName)  LIKE  '%'+Lower(@Filter)+'%'or @Filter IS NULL) OR
		(Lower(IdentificationNumber) LIKE '%'+Lower(@Filter)+'%' or @Filter IS NULL)

		IF @TotalRows > 0
		BEGIN
			SET @Total = @TotalRows / CAST(@PageSize AS float)
			SET @TotalPage = @TotalRows / @PageSize
			If CAST(@Total AS nvarchar) like '%.%'
				SET @TotalPage = @TotalPage + 1
		END
		ELSE
			BEGIN
			SET @TotalPage = 0
			END

		SET @Error = 0
	END TRY
	BEGIN CATCH  
			SET @Error = 1
			SET @TotalPage = 0
			SET @TotalRows = 0
	END CATCH  
END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetPaginationTable";
            migrationBuilder.Sql(procedure);
        }
    }
}

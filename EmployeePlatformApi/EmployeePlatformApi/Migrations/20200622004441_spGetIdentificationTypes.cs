using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class spGetIdentificationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = 
                                   OBJECT_ID(N'[dbo].[spGetIdentificationTypes]') AND type in (N'P', N'PC'))
                                BEGIN  EXEC dbo.sp_executesql @statement = 
N'CREATE PROCEDURE [dbo].[spGetIdentificationTypes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy	
	FROM dbo.IdentificationTypes
END'
END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetIdentificationTypes";
            migrationBuilder.Sql(procedure);
        }
    }
}

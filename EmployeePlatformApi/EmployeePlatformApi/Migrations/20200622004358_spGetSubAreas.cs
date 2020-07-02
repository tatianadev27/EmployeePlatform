using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class spGetSubAreas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = 
                                   OBJECT_ID(N'[dbo].[spGetSubAreas]') AND type in (N'P', N'PC'))
                                BEGIN  EXEC dbo.sp_executesql @statement = 
N'CREATE PROCEDURE [dbo].[spGetSubAreas]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, AreaId, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy	
	FROM dbo.Subareas
END'
END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetSubAreas";
            migrationBuilder.Sql(procedure);
        }
    }
}

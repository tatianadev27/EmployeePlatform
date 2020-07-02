using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class spUpdateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE  spUpdateEmployee
	@ModifiedAt datetime2(7),
	@ModifiedBy nvarchar(100),
	@IdentificationNumber nvarchar(50),
	@IdentificationTypeId int,
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@SubareaId int,
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Employees]
	SET 
		 [ModifiedAt] = @ModifiedAt
		,[ModifiedBy] = @ModifiedBy
		,[IdentificationNumber] = @IdentificationNumber
		,[IdentificationTypeId] = @IdentificationTypeId
		,[FirstName] = @FirstName
		,[LastName] = @LastName
		,[SubareaId] = @SubareaId
	 WHERE Id = @Id
	END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spUpdateEmployee";
            migrationBuilder.Sql(procedure);

        }
    }
}

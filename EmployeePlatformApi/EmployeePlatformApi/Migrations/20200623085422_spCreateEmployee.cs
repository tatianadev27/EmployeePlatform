using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class spCreateEmployee : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE  spCreateEmployee
	-- Add the parameters for the stored procedure here
	@CreatedAt datetime2(7),
	@ModifiedAt datetime2(7),
	@CreatedBy nvarchar(100),
	@ModifiedBy nvarchar(100),
	@IdentificationNumber nvarchar(50),
	@IdentificationTypeId int,
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@SubareaId int,
	@Id int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Employees]
			   ([CreatedAt]
			   ,[ModifiedAt]
			   ,[CreatedBy]
			   ,[ModifiedBy]
			   ,[IdentificationNumber]
			   ,[IdentificationTypeId]
			   ,[FirstName]
			   ,[LastName]
			   ,[SubareaId])
		 VALUES(
			   @CreatedAt ,
			   @ModifiedAt ,
			   @CreatedBy ,
			   @ModifiedBy ,
			   @IdentificationNumber ,
			   @IdentificationTypeId ,
			   @FirstName ,
			   @LastName ,
			   @SubareaId)
		SET @Id =  SCOPE_IDENTITY();
	END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spCreateEmployee";
            migrationBuilder.Sql(procedure);

        }
    }
}

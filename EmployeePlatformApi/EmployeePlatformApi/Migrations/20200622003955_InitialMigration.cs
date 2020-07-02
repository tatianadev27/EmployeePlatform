using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePlatformApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: false),
                    IdentificationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 150, nullable: false),
                    role = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subareas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subareas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: false),
                    IdentificationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    IdentificationTypeId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false),
                    SubareaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_IdentificationTypes_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Subareas_SubareaId",
                        column: x => x.SubareaId,
                        principalTable: "Subareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentificationTypeId",
                table: "Employees",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubareaId",
                table: "Employees",
                column: "SubareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subareas_AreaId",
                table: "Subareas",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "IdentificationTypes");

            migrationBuilder.DropTable(
                name: "Subareas");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}

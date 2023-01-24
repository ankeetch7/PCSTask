using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Employee_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Entry_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entry_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationLists",
                columns: table => new
                {
                    Q_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Q_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationLists", x => x.Q_Id);
                });

            migrationBuilder.CreateTable(
                name: "EMP_Qualification",
                columns: table => new
                {
                    Employee_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Q_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMP_Qualification", x => new { x.Employee_Id, x.Q_Id });
                    table.ForeignKey(
                        name: "FK_EMP_Qualification_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMP_Qualification_QualificationLists_Q_Id",
                        column: x => x.Q_Id,
                        principalTable: "QualificationLists",
                        principalColumn: "Q_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMP_Qualification_Q_Id",
                table: "EMP_Qualification",
                column: "Q_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMP_Qualification");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "QualificationLists");
        }
    }
}

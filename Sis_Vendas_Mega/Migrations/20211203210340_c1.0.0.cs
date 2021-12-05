using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sis_Vendas_Mega.Migrations
{
    public partial class c100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    Entry = table.Column<TimeSpan>(nullable: false),
                    Lunch = table.Column<TimeSpan>(nullable: false),
                    Exit = table.Column<TimeSpan>(nullable: false),
                    TotalWeek = table.Column<TimeSpan>(nullable: false),
                    TotalMonth = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Login = table.Column<string>(maxLength: 20, nullable: true),
                    Senha = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<long>(nullable: false),
                    FunctionId = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: true, defaultValue: "01/01/1990")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Function_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Function",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    Log = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogScore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogScore_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Code = table.Column<long>(nullable: false),
                    EntryTime = table.Column<TimeSpan>(nullable: false),
                    OutLanch = table.Column<TimeSpan>(nullable: false),
                    ReturnLunch = table.Column<TimeSpan>(nullable: false),
                    DepartureTime = table.Column<TimeSpan>(nullable: false),
                    FullRange = table.Column<TimeSpan>(nullable: false),
                    Worked = table.Column<TimeSpan>(nullable: false),
                    Minutes = table.Column<double>(type: "double(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FunctionId",
                table: "Employee",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Id",
                table: "Employee",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Function_Description",
                table: "Function",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_LogScore_EmployeeId",
                table: "LogScore",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_EmployeeId",
                table: "Score",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_Id",
                table: "Score",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Nome",
                table: "Usuario",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hours");

            migrationBuilder.DropTable(
                name: "LogScore");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Function");
        }
    }
}

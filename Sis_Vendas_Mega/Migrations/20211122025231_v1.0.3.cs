using Microsoft.EntityFrameworkCore.Migrations;

namespace Sis_Vendas_Mega.Migrations
{
    public partial class v103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogScores_Employee_EmployeeId",
                table: "LogScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogScores",
                table: "LogScores");

            migrationBuilder.RenameTable(
                name: "LogScores",
                newName: "LogScore");

            migrationBuilder.RenameIndex(
                name: "IX_LogScores_EmployeeId",
                table: "LogScore",
                newName: "IX_LogScore_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogScore",
                table: "LogScore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogScore_Employee_EmployeeId",
                table: "LogScore",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogScore_Employee_EmployeeId",
                table: "LogScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogScore",
                table: "LogScore");

            migrationBuilder.RenameTable(
                name: "LogScore",
                newName: "LogScores");

            migrationBuilder.RenameIndex(
                name: "IX_LogScore_EmployeeId",
                table: "LogScores",
                newName: "IX_LogScores_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogScores",
                table: "LogScores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogScores_Employee_EmployeeId",
                table: "LogScores",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

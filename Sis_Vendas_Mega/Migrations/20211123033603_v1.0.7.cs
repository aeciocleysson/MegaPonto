using Microsoft.EntityFrameworkCore.Migrations;

namespace Sis_Vendas_Mega.Migrations
{
    public partial class v107 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Minutes",
                table: "Score",
                type: "double(12,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(12,3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Minutes",
                table: "Score",
                type: "double(12,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(12,2)");
        }
    }
}

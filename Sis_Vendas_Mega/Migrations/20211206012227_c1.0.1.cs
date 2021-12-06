using Microsoft.EntityFrameworkCore.Migrations;

namespace Sis_Vendas_Mega.Migrations
{
    public partial class c101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "NivelAcesso",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelAcesso",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Usuario",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}

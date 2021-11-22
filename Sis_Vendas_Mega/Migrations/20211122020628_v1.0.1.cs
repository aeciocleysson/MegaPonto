using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sis_Vendas_Mega.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Worked",
                table: "Score",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnLunch",
                table: "Score",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutLanch",
                table: "Score",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<long>(
                name: "Minutes",
                table: "Score",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FullRange",
                table: "Score",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureTime",
                table: "Score",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Worked",
                table: "Score",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnLunch",
                table: "Score",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutLanch",
                table: "Score",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "Minutes",
                table: "Score",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FullRange",
                table: "Score",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureTime",
                table: "Score",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}

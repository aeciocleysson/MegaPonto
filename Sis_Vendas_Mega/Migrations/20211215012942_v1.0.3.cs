using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sis_Vendas_Mega.Migrations
{
    public partial class v103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Register_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_RegisterId",
                table: "Product",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_ProviderId",
                table: "Register",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Register_RegisterId",
                table: "Product",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Register_RegisterId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Product_RegisterId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Product");
        }
    }
}

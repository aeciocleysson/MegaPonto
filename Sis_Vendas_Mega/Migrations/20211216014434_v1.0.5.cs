using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sis_Vendas_Mega.Migrations
{
    public partial class v105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Register_RegisterId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_RegisterId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "RegisterItensId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegisterItens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inserted = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    RegisterId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterItens_Register_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Register",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_RegisterItensId",
                table: "Product",
                column: "RegisterItensId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterItens_RegisterId",
                table: "RegisterItens",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_RegisterItens_RegisterItensId",
                table: "Product",
                column: "RegisterItensId",
                principalTable: "RegisterItens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_RegisterItens_RegisterItensId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "RegisterItens");

            migrationBuilder.DropIndex(
                name: "IX_Product_RegisterItensId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RegisterItensId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_RegisterId",
                table: "Product",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Register_RegisterId",
                table: "Product",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

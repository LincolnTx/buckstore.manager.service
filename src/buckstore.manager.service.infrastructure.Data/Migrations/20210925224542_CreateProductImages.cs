using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace buckstore.manager.service.infrastructure.Data.Migrations
{
    public partial class CreateProductImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    product_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsImage_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsImage_product_id",
                table: "ProductsImage",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsImage");
        }
    }
}

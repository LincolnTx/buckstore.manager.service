using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace buckstore.manager.service.infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(maxLength: 300, nullable: true),
                    price = table.Column<double>(nullable: false),
                    stock_quantity = table.Column<int>(nullable: false),
                    _categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_product_category__categoryId",
                        column: x => x._categoryId,
                        principalTable: "product_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "product_category",
                columns: new[] { "id", "description" },
                values: new object[,]
                {
                    { 1, "Gamer" },
                    { 2, "SmartPhones" },
                    { 3, "Computador" },
                    { 4, "Periféricos" },
                    { 5, "Hardware" },
                    { 6, "Office" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_Id",
                table: "product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product__categoryId",
                table: "product",
                column: "_categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "product_category");
        }
    }
}

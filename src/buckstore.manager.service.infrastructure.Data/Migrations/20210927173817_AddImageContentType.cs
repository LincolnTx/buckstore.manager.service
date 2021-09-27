using Microsoft.EntityFrameworkCore.Migrations;

namespace buckstore.manager.service.infrastructure.Data.Migrations
{
    public partial class AddImageContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "ProductsImage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "ProductsImage");
        }
    }
}

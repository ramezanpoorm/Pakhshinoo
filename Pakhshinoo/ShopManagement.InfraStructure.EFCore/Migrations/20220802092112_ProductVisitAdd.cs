using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.InfraStructure.EFCore.Migrations
{
    public partial class ProductVisitAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "Products");
        }
    }
}

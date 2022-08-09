using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.InfraStructure.EFCore.Migrations
{
    public partial class alterBrandUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Brand");
        }
    }
}

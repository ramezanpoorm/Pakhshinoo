using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.InfraStructure.EFCore.Migrations
{
    public partial class AddIsRemovedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Brand");
        }
    }
}

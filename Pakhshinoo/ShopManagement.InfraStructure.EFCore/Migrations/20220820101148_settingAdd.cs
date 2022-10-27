using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.InfraStructure.EFCore.Migrations
{
    public partial class settingAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner1Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner1Pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner1Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner2Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner2Pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner2Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner3Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner3Pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner3Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percent9 = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}

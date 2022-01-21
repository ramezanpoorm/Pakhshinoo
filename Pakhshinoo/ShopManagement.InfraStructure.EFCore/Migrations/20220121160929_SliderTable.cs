using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.InfraStructure.EFCore.Migrations
{
    public partial class SliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Heading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BtnText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");
        }
    }
}

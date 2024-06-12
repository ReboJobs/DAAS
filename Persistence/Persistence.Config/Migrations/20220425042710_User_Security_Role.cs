using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Config.Migrations
{
    public partial class User_Security_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "ReportInDashboard",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserReportCardImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReportDBID = table.Column<int>(type: "int", nullable: true),
                    ImageBlobURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReportCardImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserThemeSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DashboardColorHex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DashboardFontColorHex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NavigationColorHex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NavigationFontColorHex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BackgroundColorHex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BackgroundFontColorHex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HeaderImageLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundImageLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBackgroundImage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserThemeSetting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReportCardImage");

            migrationBuilder.DropTable(
                name: "UserThemeSetting");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "ReportInDashboard");
        }
    }
}

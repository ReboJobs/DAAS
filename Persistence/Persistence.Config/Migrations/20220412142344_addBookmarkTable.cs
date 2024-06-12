using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Config.Migrations
{
    public partial class addBookmarkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Bookmark",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: true),
                    reportDBID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type:  "Nvarchar(MAX)", unicode: false, maxLength: int.MaxValue, nullable: true),
                    DisplayName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmark", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Bookmark__reportDBID__114A936A",
                        column: x => x.reportDBID,
                        principalTable: "ReportInDashboard",
                        principalColumn: "reportDBID");
                    table.ForeignKey(
                        name: "FK__Bookmark__userID__10566F31",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_reportDBID",
                table: "Bookmark",
                column: "reportDBID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_userID",
                table: "Bookmark",
                column: "userID");
                       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmark");
            
        }
    }
}

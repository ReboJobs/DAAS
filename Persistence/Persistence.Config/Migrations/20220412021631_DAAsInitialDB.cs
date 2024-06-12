using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Config.Migrations
{
    public partial class DAAsInitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubmittedBy = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportBug",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReported = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReportedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportBug", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportInDashboard",
                columns: table => new
                {
                    reportDBID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReportIn__EA8D83C87673B0AE", x => x.reportDBID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "UserTrack",
                columns: table => new
                {
                    trackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    userName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dateTimeLog = table.Column<DateTime>(type: "datetime", nullable: true),
                    browser = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    page = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    reportName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrack", x => x.trackID);
                });

            migrationBuilder.CreateTable(
                name: "UserVault",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<byte>(type: "tinyint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVault", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdeaVoteDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaId = table.Column<int>(type: "int", nullable: true),
                    VotedBy = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DateVoted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaVoteDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdeaVoteDetail_Idea",
                        column: x => x.IdeaId,
                        principalTable: "Idea",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: true),
                    reportDBID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IsLike = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Like__reportDBID__114A936A",
                        column: x => x.reportDBID,
                        principalTable: "ReportInDashboard",
                        principalColumn: "reportDBID");
                    table.ForeignKey(
                        name: "FK__Like__userID__10566F31",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaVoteDetail_IdeaId",
                table: "IdeaVoteDetail",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_reportDBID",
                table: "Like",
                column: "reportDBID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_userID",
                table: "Like",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaVoteDetail");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "ReportBug");

            migrationBuilder.DropTable(
                name: "UserTrack");

            migrationBuilder.DropTable(
                name: "UserVault");

            migrationBuilder.DropTable(
                name: "Idea");

            migrationBuilder.DropTable(
                name: "ReportInDashboard");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

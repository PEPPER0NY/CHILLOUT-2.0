using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chillout.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Balance = table.Column<int>(nullable: false),
                    MaxWinCountAce = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LeftUserId = table.Column<int>(nullable: false),
                    RightUserId = table.Column<int>(nullable: false),
                    WinnerUserId = table.Column<int>(nullable: false),
                    AdditionMoney = table.Column<int>(nullable: false),
                    DateTimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryGame_User_LeftUserId",
                        column: x => x.LeftUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryGame_User_RightUserId",
                        column: x => x.RightUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryGame_User_WinnerUserId",
                        column: x => x.WinnerUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryGame_LeftUserId",
                table: "HistoryGame",
                column: "LeftUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryGame_RightUserId",
                table: "HistoryGame",
                column: "RightUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryGame_WinnerUserId",
                table: "HistoryGame",
                column: "WinnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryGame");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

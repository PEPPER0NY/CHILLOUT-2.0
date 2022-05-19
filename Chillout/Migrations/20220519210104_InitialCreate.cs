using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chillout.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Website = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    PassListRtoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_PassList_PassListRtoId",
                        column: x => x.PassListRtoId,
                        principalTable: "PassList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PassListRtoId",
                table: "User",
                column: "PassListRtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PassList");
        }
    }
}

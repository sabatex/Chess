using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebChess.Data.Migrations
{
    public partial class ChessParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChessParties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserWhite = table.Column<string>(nullable: true),
                    UserBlack = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    LastParty = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessParties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChessParties");
        }
    }
}

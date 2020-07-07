using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebChess.Data.Migrations
{
    public partial class DeskStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeskStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    UserMove = table.Column<string>(nullable: true),
                    Step = table.Column<string>(nullable: true),
                    Desk = table.Column<string>(nullable: true),
                    ChessPartyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeskStates_ChessParties_ChessPartyId",
                        column: x => x.ChessPartyId,
                        principalTable: "ChessParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskStates_ChessPartyId",
                table: "DeskStates",
                column: "ChessPartyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskStates");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebChess.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskStates_ChessParties_ChessPartyId",
                table: "DeskStates");

            migrationBuilder.AlterColumn<int>(
                name: "ChessPartyId",
                table: "DeskStates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskStates_ChessParties_ChessPartyId",
                table: "DeskStates",
                column: "ChessPartyId",
                principalTable: "ChessParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskStates_ChessParties_ChessPartyId",
                table: "DeskStates");

            migrationBuilder.AlterColumn<int>(
                name: "ChessPartyId",
                table: "DeskStates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DeskStates_ChessParties_ChessPartyId",
                table: "DeskStates",
                column: "ChessPartyId",
                principalTable: "ChessParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

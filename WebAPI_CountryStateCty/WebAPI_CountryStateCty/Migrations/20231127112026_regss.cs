using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_CountryStateCty.Migrations
{
    public partial class regss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Cities_CityId1",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_CityId1",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Registers");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registers_CityId",
                table: "Registers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Cities_CityId",
                table: "Registers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Cities_CityId",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_CityId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Registers");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Registers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registers_CityId1",
                table: "Registers",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Cities_CityId1",
                table: "Registers",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}

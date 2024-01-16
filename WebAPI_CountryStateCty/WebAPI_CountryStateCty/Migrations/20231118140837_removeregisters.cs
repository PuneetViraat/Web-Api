using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_CountryStateCty.Migrations
{
    public partial class removeregisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      migrationBuilder.DropTable("Registers");

      
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Cities_CityId",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_CityId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Subscribe",
                table: "Registers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "States",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Registers",
                type: "int",
                nullable: true);

            /*migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "Registers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId1",
                table: "Registers",
                type: "int",
                nullable: true);
*/
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Registers_CityId1",
                table: "Registers",
                column: "CityId1");

            /*migrationBuilder.CreateIndex(
                name: "IX_Registers_CountryId1",
                table: "Registers",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Registers_StateId1",
                table: "Registers",
                column: "StateId1");*/

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Cities_CityId1",
                table: "Registers",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Countries_CountryId1",
                table: "Registers",
                column: "CountryId1",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_States_StateId1",
                table: "Registers",
                column: "StateId1",
                principalTable: "States",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Cities_CityId1",
                table: "Registers");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Countries_CountryId1",
                table: "Registers");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_States_StateId1",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_CityId1",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_CountryId1",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_StateId1",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "StateId1",
                table: "Registers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "States",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Subscribe",
                table: "Registers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

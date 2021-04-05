using Microsoft.EntityFrameworkCore.Migrations;

namespace DocUp.Dal.Migrations
{
    public partial class DB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Readings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Readings_DeviceId",
                table: "Readings",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Devices_DeviceId",
                table: "Readings",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Devices_DeviceId",
                table: "Readings");

            migrationBuilder.DropIndex(
                name: "IX_Readings_DeviceId",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Readings");
        }
    }
}

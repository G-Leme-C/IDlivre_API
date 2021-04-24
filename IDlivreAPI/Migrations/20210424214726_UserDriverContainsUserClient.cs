using Microsoft.EntityFrameworkCore.Migrations;

namespace IDlivreAPI.Migrations
{
    public partial class UserDriverContainsUserClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersDrivers_Users_UserId",
                table: "UsersDrivers");

            migrationBuilder.DropIndex(
                name: "IX_UsersDrivers_UserId",
                table: "UsersDrivers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersDrivers");

            migrationBuilder.AddColumn<int>(
                name: "UserClientId",
                table: "UsersDrivers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDriverId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersDrivers_UserClientId",
                table: "UsersDrivers",
                column: "UserClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDriverId",
                table: "Users",
                column: "UserDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersDrivers_UserDriverId",
                table: "Users",
                column: "UserDriverId",
                principalTable: "UsersDrivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDrivers_UsersClient_UserClientId",
                table: "UsersDrivers",
                column: "UserClientId",
                principalTable: "UsersClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersDrivers_UserDriverId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDrivers_UsersClient_UserClientId",
                table: "UsersDrivers");

            migrationBuilder.DropIndex(
                name: "IX_UsersDrivers_UserClientId",
                table: "UsersDrivers");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserDriverId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserClientId",
                table: "UsersDrivers");

            migrationBuilder.DropColumn(
                name: "UserDriverId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersDrivers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersDrivers_UserId",
                table: "UsersDrivers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDrivers_Users_UserId",
                table: "UsersDrivers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

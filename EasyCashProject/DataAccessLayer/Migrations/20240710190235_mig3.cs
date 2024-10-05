using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "customerAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_customerAccounts_AppUserId",
                table: "customerAccounts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_customerAccounts_AspNetUsers_AppUserId",
                table: "customerAccounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerAccounts_AspNetUsers_AppUserId",
                table: "customerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_customerAccounts_AppUserId",
                table: "customerAccounts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "customerAccounts");
        }
    }
}

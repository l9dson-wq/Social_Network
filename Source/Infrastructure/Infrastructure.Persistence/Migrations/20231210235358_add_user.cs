using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class add_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfilePictures_UserProfileId",
                table: "UserProfilePictures");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "UserProfilePictures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePictures_UserProfileId",
                table: "UserProfilePictures",
                column: "UserProfileId",
                unique: true,
                filter: "[UserProfileId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfilePictures_UserProfileId",
                table: "UserProfilePictures");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "UserProfilePictures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePictures_UserProfileId",
                table: "UserProfilePictures",
                column: "UserProfileId",
                unique: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneQuizzCreationApp.Migrations
{
    public partial class credentialupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Users_UserId",
                table: "Credentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials");

            migrationBuilder.RenameTable(
                name: "Credentials",
                newName: "UserCredential");

            migrationBuilder.RenameIndex(
                name: "IX_Credentials_UserId",
                table: "UserCredential",
                newName: "IX_UserCredential_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCredential",
                table: "UserCredential",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCredential_Users_UserId",
                table: "UserCredential",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCredential_Users_UserId",
                table: "UserCredential");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCredential",
                table: "UserCredential");

            migrationBuilder.RenameTable(
                name: "UserCredential",
                newName: "Credentials");

            migrationBuilder.RenameIndex(
                name: "IX_UserCredential_UserId",
                table: "Credentials",
                newName: "IX_Credentials_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Users_UserId",
                table: "Credentials",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

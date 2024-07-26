using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneQuizzCreationApp.Migrations
{
    public partial class certificateupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmissionDate",
                table: "Submissions",
                newName: "SubmissionTime");

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "TestHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassed",
                table: "TestHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxObtainedScore",
                table: "TestHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Submissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsserId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxObtainedScore",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestHistories_CertificateId",
                table: "TestHistories",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestHistories_Certificates_CertificateId",
                table: "TestHistories",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_TestHistories_Certificates_CertificateId",
                table: "TestHistories");

            migrationBuilder.DropIndex(
                name: "IX_TestHistories_CertificateId",
                table: "TestHistories");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "TestHistories");

            migrationBuilder.DropColumn(
                name: "IsPassed",
                table: "TestHistories");

            migrationBuilder.DropColumn(
                name: "MaxObtainedScore",
                table: "TestHistories");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "UsserId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "MaxObtainedScore",
                table: "Certificates");

            migrationBuilder.RenameColumn(
                name: "SubmissionTime",
                table: "Submissions",
                newName: "SubmissionDate");
        }
    }
}

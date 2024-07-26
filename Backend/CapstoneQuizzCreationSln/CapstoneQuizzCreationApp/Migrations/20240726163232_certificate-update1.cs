using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneQuizzCreationApp.Migrations
{
    public partial class certificateupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestHistories_Certificates_CertificateId",
                table: "TestHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_TestHistories_Certificates_CertificateId",
                table: "TestHistories",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestHistories_Certificates_CertificateId",
                table: "TestHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_TestHistories_Certificates_CertificateId",
                table: "TestHistories",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnrollmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class deleteApplicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Applicants_ApplicantID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramEnrollment_Applicants_ApplicantID",
                table: "ProgramEnrollment");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ApplicantID",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantID",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AppUserId",
                table: "Documents",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_AppUserId",
                table: "Documents",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramEnrollment_AspNetUsers_ApplicantID",
                table: "ProgramEnrollment",
                column: "ApplicantID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_AppUserId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramEnrollment_AspNetUsers_ApplicantID",
                table: "ProgramEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AppUserId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantID",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantID);
                });

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "ApplicantID", "Address", "ApplicationStatus", "DateOfBirth", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[,]
                {
                    { "Applicant01", "Malabon City", "Pending", new DateTime(2000, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "montemorjeraldd@gmail.com", "Jerald", "Montemor", "Rabino", "09488749263" },
                    { "Applicant02", "Quezon City", "Approved", new DateTime(2000, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.lopez@example.com", "Anna", "Lopez", "Marie", "09488749263" },
                    { "Applicant03", "Caloocan City", "Pending", new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark.cruz@example.com", "Mark", "Cruz", "Anthony", "09488749263" },
                    { "Applicant04", "Makati City", "Rejected", new DateTime(2001, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.delrosario@example.com", "Sophia", "Del Rosario", "Grace", "09488749263" },
                    { "Applicant05", "Pasig City", "Pending", new DateTime(1998, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.santos@example.com", "John", "Santos", "Paul", "09488749263" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApplicantID",
                table: "Documents",
                column: "ApplicantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Applicants_ApplicantID",
                table: "Documents",
                column: "ApplicantID",
                principalTable: "Applicants",
                principalColumn: "ApplicantID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramEnrollment_Applicants_ApplicantID",
                table: "ProgramEnrollment",
                column: "ApplicantID",
                principalTable: "Applicants",
                principalColumn: "ApplicantID");
        }
    }
}

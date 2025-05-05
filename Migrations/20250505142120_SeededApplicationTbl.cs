using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnrollmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeededApplicationTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Applicants_ApplicantID",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Department_DepartmentID",
                table: "Programs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Document_ApplicantID",
                table: "Documents",
                newName: "IX_Documents_ApplicantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "DocumentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentID");

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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CourseCode", "DepartmentName" },
                values: new object[,]
                {
                    { "DEPARMENT001", "TEST", "College of Technology" },
                    { "DEPARMENT002", "TEST", "College of Engineering" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Applicants_ApplicantID",
                table: "Documents",
                column: "ApplicantID",
                principalTable: "Applicants",
                principalColumn: "ApplicantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Departments_DepartmentID",
                table: "Programs",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Applicants_ApplicantID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Departments_DepartmentID",
                table: "Programs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "ApplicantID",
                keyValue: "Applicant01");

            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "ApplicantID",
                keyValue: "Applicant02");

            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "ApplicantID",
                keyValue: "Applicant03");

            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "ApplicantID",
                keyValue: "Applicant04");

            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "ApplicantID",
                keyValue: "Applicant05");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: "DEPARMENT001");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: "DEPARMENT002");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ApplicantID",
                table: "Document",
                newName: "IX_Document_ApplicantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "DocumentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Applicants_ApplicantID",
                table: "Document",
                column: "ApplicantID",
                principalTable: "Applicants",
                principalColumn: "ApplicantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Department_DepartmentID",
                table: "Programs",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

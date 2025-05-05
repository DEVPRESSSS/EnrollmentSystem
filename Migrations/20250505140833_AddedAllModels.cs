using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Document_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantID");
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvailableForEnrollment = table.Column<bool>(type: "bit", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    CurrentEnrollment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramID);
                    table.ForeignKey(
                        name: "FK_Programs_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramEnrollment",
                columns: table => new
                {
                    ProgramEnrollmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicantID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProgramID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramEnrollment", x => x.ProgramEnrollmentID);
                    table.ForeignKey(
                        name: "FK_ProgramEnrollment_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantID");
                    table.ForeignKey(
                        name: "FK_ProgramEnrollment_Programs_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Programs",
                        principalColumn: "ProgramID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_ApplicantID",
                table: "Document",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEnrollment_ApplicantID",
                table: "ProgramEnrollment",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEnrollment_ProgramID",
                table: "ProgramEnrollment",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_DepartmentID",
                table: "Programs",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ProgramEnrollment");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicant",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    contactNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 788, DateTimeKind.Utc).AddTicks(612)),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 788, DateTimeKind.Utc).AddTicks(908))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "applicationStatus",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 789, DateTimeKind.Utc).AddTicks(3497)),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 789, DateTimeKind.Utc).AddTicks(3928))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gradeNumber = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 790, DateTimeKind.Utc).AddTicks(824)),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 790, DateTimeKind.Utc).AddTicks(1259))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicantId = table.Column<long>(type: "bigint", nullable: false),
                    gradeId = table.Column<long>(type: "bigint", nullable: false),
                    applicationStatusId = table.Column<long>(type: "bigint", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 790, DateTimeKind.Utc).AddTicks(5201)),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 25, 17, 39, 5, 790, DateTimeKind.Utc).AddTicks(5508)),
                    schoolYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application", x => x.id);
                    table.ForeignKey(
                        name: "FK_application_applicant_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicant",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_application_applicationStatus_applicationStatusId",
                        column: x => x.applicationStatusId,
                        principalTable: "applicationStatus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_application_grade_gradeId",
                        column: x => x.gradeId,
                        principalTable: "grade",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_application_applicantId",
                table: "application",
                column: "applicantId");

            migrationBuilder.CreateIndex(
                name: "IX_application_applicationStatusId",
                table: "application",
                column: "applicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_application_gradeId",
                table: "application",
                column: "gradeId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationStatus_name",
                table: "applicationStatus",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_grade_gradeNumber",
                table: "grade",
                column: "gradeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_grade_name",
                table: "grade",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application");

            migrationBuilder.DropTable(
                name: "applicant");

            migrationBuilder.DropTable(
                name: "applicationStatus");

            migrationBuilder.DropTable(
                name: "grade");
        }
    }
}

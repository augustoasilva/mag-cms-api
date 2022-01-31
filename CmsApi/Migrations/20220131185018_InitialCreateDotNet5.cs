using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsApi.Migrations
{
    public partial class InitialCreateDotNet5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mechanical Engineering" },
                    { 2, "Software Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDay", "FirstName", "LastName", "RegistrationNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "Silva", 1 },
                    { 2, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fernando", "Montero", 1 },
                    { 3, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guilherme", "Sousa", 1 },
                    { 4, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milton", "Nunes", 1 },
                    { 5, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alberto", "Silveira", 1 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "BirthDay", "FirstName", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lauro", "Alvarez", 1500m },
                    { 2, new DateTime(1985, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", "Hernandez", 1600m },
                    { 3, new DateTime(1990, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronaldo", "Silva", 1700m },
                    { 4, new DateTime(1989, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodrigo", "Wilhelm", 1800m },
                    { 5, new DateTime(1992, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "Lobo", 1900m }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, "Calculus 1", 1 },
                    { 2, 1, "Physics 1", 2 },
                    { 3, 2, "Algorithms 1", 3 },
                    { 4, 2, "Linear Algebra", 4 },
                    { 5, 1, "3D CAD Design", 5 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "StudentId", "SubjectId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 9.5 },
                    { 2, 1, 1, 7.25 },
                    { 3, 1, 1, 8.0 },
                    { 9, 1, 5, 9.0 },
                    { 8, 1, 5, 10.0 },
                    { 4, 1, 2, 8.5 },
                    { 5, 1, 2, 8.6999999999999993 },
                    { 6, 1, 2, 8.9000000000000004 },
                    { 7, 1, 5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId", "Id" },
                values: new object[,]
                {
                    { 1, 5, 0 },
                    { 5, 4, 0 },
                    { 4, 4, 0 },
                    { 5, 3, 0 },
                    { 2, 2, 0 },
                    { 3, 2, 0 },
                    { 2, 5, 0 },
                    { 1, 2, 0 },
                    { 3, 1, 0 },
                    { 2, 1, 0 },
                    { 1, 1, 0 },
                    { 4, 3, 0 },
                    { 3, 5, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}

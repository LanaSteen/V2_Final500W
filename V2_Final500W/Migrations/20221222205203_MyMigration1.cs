using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V2_Final500W.Migrations
{
    public partial class MyMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "address");

            migrationBuilder.EnsureSchema(
                name: "balance");

            migrationBuilder.EnsureSchema(
                name: "department");

            migrationBuilder.EnsureSchema(
                name: "room");

            migrationBuilder.EnsureSchema(
                name: "schedule");

            migrationBuilder.EnsureSchema(
                name: "schedule_room");

            migrationBuilder.EnsureSchema(
                name: "schedule_subject");

            migrationBuilder.EnsureSchema(
                name: "semester");

            migrationBuilder.EnsureSchema(
                name: "student");

            migrationBuilder.EnsureSchema(
                name: "student_subject");

            migrationBuilder.EnsureSchema(
                name: "subject");

            migrationBuilder.EnsureSchema(
                name: "teacher");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responces",
                columns: table => new
                {
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responces", x => x.StatusCode);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MaxNumberOfStudents = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                schema: "semester",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AvaliableGPA = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StartDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Credit = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LowerBound = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxNumberOfStudents = table.Column<int>(type: "int", nullable: false),
                    MaxNumberOfTeachers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    MaxNumberOfStudents = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CurrentAmount = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Semester",
                        column: x => x.SemesterId,
                        principalSchema: "semester",
                        principalTable: "Semester",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Semester",
                        column: x => x.SemesterId,
                        principalSchema: "semester",
                        principalTable: "Semester",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PersonalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "address",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Department",
                        column: x => x.DepartmentId,
                        principalSchema: "department",
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Semester",
                        column: x => x.SemesterId,
                        principalSchema: "semester",
                        principalTable: "Semester",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PersonalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "address",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_Department",
                        column: x => x.DepartmentId,
                        principalSchema: "department",
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "subject",
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleRoom",
                schema: "schedule_room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_ScheduleRooms",
                        column: x => x.RoomId,
                        principalSchema: "room",
                        principalTable: "Room",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduleRooms_Room",
                        column: x => x.ScheduleId,
                        principalSchema: "schedule",
                        principalTable: "Schedule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSubject",
                schema: "schedule_subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleSubject_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "subject",
                        principalTable: "Subject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduleSubjects_Room",
                        column: x => x.ScheduleId,
                        principalSchema: "schedule",
                        principalTable: "Schedule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                schema: "balance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    Debth = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balance_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "semester",
                        principalTable: "Semester",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Balance_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                schema: "student_subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Student",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "subject",
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Responces",
                columns: new[] { "StatusCode", "Message" },
                values: new object[] { -3, "AKA \"System Error\" by meaning I don't have idea what's going on :)" });

            migrationBuilder.InsertData(
                table: "Responces",
                columns: new[] { "StatusCode", "Message" },
                values: new object[] { -2, "Wrong parameters" });

            migrationBuilder.InsertData(
                table: "Responces",
                columns: new[] { "StatusCode", "Message" },
                values: new object[] { -1, "Operation wass completed successfully" });

            migrationBuilder.CreateIndex(
                name: "IX_Balance_SemesterId",
                schema: "balance",
                table: "Balance",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Balance_StudentId",
                schema: "balance",
                table: "Balance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_SemesterId",
                schema: "department",
                table: "Department",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SemesterId",
                schema: "schedule",
                table: "Schedule",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRoom_RoomId",
                schema: "schedule_room",
                table: "ScheduleRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRoom_ScheduleId",
                schema: "schedule_room",
                table: "ScheduleRoom",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSubject_ScheduleId",
                schema: "schedule_subject",
                table: "ScheduleSubject",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSubject_SubjectId",
                schema: "schedule_subject",
                table: "ScheduleSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                schema: "student",
                table: "Student",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                schema: "student",
                table: "Student",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SemesterId",
                schema: "student",
                table: "Student",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                schema: "student_subject",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                schema: "student_subject",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AddressId",
                schema: "teacher",
                table: "Teacher",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DepartmentId",
                schema: "teacher",
                table: "Teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectId",
                schema: "teacher",
                table: "Teacher",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance",
                schema: "balance");

            migrationBuilder.DropTable(
                name: "Responces");

            migrationBuilder.DropTable(
                name: "ScheduleRoom",
                schema: "schedule_room");

            migrationBuilder.DropTable(
                name: "ScheduleSubject",
                schema: "schedule_subject");

            migrationBuilder.DropTable(
                name: "StudentSubject",
                schema: "student_subject");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "teacher");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "room");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "student");

            migrationBuilder.DropTable(
                name: "Subject",
                schema: "subject");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "address");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "department");

            migrationBuilder.DropTable(
                name: "Semester",
                schema: "semester");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace grad2021.Migrations
{
    public partial class StudentTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    FirstSemesterStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterExamsStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterControlStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterObjectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterObjectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterExamsStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterControlStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterObjectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterObjectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberExamsStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberControlStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberObjectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberObjectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.AcademicYearID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BranchDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullCapacity = table.Column<int>(type: "int", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchName);
                    table.ForeignKey(
                        name: "FK_Branches_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCodes",
                columns: table => new
                {
                    DepartmentCodeValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCodes", x => x.DepartmentCodeValue);
                    table.ForeignKey(
                        name: "FK_DepartmentCodes_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorNatId);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeatNo = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelName = table.Column<int>(type: "int", nullable: true),
                    BranchName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNatId);
                    table.ForeignKey(
                        name: "FK_Students_Branches_BranchName1",
                        column: x => x.BranchName1,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DepartmentCodeValue = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LectureWeeklyDuration = table.Column<int>(type: "int", nullable: true),
                    SectionWeeklyDuration = table.Column<int>(type: "int", nullable: true),
                    CourseWorkMaxScore = table.Column<double>(type: "float", nullable: false),
                    MidTermExamMaxScore = table.Column<double>(type: "float", nullable: false),
                    OralExamMaxScore = table.Column<double>(type: "float", nullable: false),
                    TermExamMaxScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseName);
                    table.ForeignKey(
                        name: "FK_Courses_DepartmentCodes_DepartmentCodeValue",
                        column: x => x.DepartmentCodeValue,
                        principalTable: "DepartmentCodes",
                        principalColumn: "DepartmentCodeValue",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorProfessions",
                columns: table => new
                {
                    InstructorProfessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ProfessionDegree = table.Column<int>(type: "int", nullable: false),
                    PromotionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorProfessions", x => x.InstructorProfessionID);
                    table.ForeignKey(
                        name: "FK_InstructorProfessions_Instructors_InstructorNatId",
                        column: x => x.InstructorNatId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorNatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollments",
                columns: table => new
                {
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsNovember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollments", x => new { x.StudentNatId, x.AcademicYearID });
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_AcademicYears_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Branches_BranchName",
                        column: x => x.BranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Students_StudentNatId",
                        column: x => x.StudentNatId,
                        principalTable: "Students",
                        principalColumn: "StudentNatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelName = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollments", x => new { x.CourseName, x.BranchName });
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Branches_BranchName",
                        column: x => x.BranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Selection",
                columns: table => new
                {
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    SelectionNo = table.Column<int>(type: "int", nullable: false),
                    CurrentBranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SelectionBranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentNatId1 = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selection", x => x.SelectionID);
                    table.ForeignKey(
                        name: "FK_Selection_AcademicYears_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Selection_Branches_CurrentBranchName",
                        column: x => x.CurrentBranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selection_Branches_SelectionBranchName",
                        column: x => x.SelectionBranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selection_StudentEnrollments_StudentNatId_AcademicYearID",
                        columns: x => new { x.StudentNatId, x.AcademicYearID },
                        principalTable: "StudentEnrollments",
                        principalColumns: new[] { "StudentNatId", "AcademicYearID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selection_Students_StudentNatId1",
                        column: x => x.StudentNatId1,
                        principalTable: "Students",
                        principalColumn: "StudentNatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorEnrollments",
                columns: table => new
                {
                    InstructorEnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorEnrollments", x => x.InstructorEnrollmentID);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_AcademicYears_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_CourseEnrollments_CourseName_BranchName",
                        columns: x => new { x.CourseName, x.BranchName },
                        principalTable: "CourseEnrollments",
                        principalColumns: new[] { "CourseName", "BranchName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_Instructors_InstructorNatId",
                        column: x => x.InstructorNatId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorNatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentCourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MidTermMark = table.Column<double>(type: "float", nullable: false),
                    CourseWorkMark = table.Column<double>(type: "float", nullable: false),
                    OralExamMark = table.Column<double>(type: "float", nullable: false),
                    FinalExamMark = table.Column<double>(type: "float", nullable: false),
                    MerciMark = table.Column<double>(type: "float", nullable: false),
                    IsNovember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.StudentCourseID);
                    table.ForeignKey(
                        name: "FK_StudentCourses_CourseEnrollments_CourseName_BranchName",
                        columns: x => new { x.CourseName, x.BranchName },
                        principalTable: "CourseEnrollments",
                        principalColumns: new[] { "CourseName", "BranchName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_StudentEnrollments_StudentNatId_AcademicYearID",
                        columns: x => new { x.StudentNatId, x.AcademicYearID },
                        principalTable: "StudentEnrollments",
                        principalColumns: new[] { "StudentNatId", "AcademicYearID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicYears",
                columns: new[] { "AcademicYearID", "FirstSemesterControlStartDate", "FirstSemesterExamsStartDate", "FirstSemesterObjectionEndDate", "FirstSemesterObjectionStartDate", "FirstSemesterStartDate", "NovemberControlStartDate", "NovemberExamsStartDate", "NovemberObjectionEndDate", "NovemberObjectionStartDate", "SecondSemesterControlStartDate", "SecondSemesterExamsStartDate", "SecondSemesterObjectionEndDate", "SecondSemesterObjectionStartDate", "SecondSemesterStartDate" },
                values: new object[,]
                {
                    { 2021, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2022, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2023, null, null, null, null, null, null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentName", "DepartmentDescription" },
                values: new object[,]
                {
                    { "الرياضيات والفيزيقا الهندسية", "وصف قسم الرياضيات والفيزيقا الهندسية" },
                    { "الهندسة المدنية", "وصف قسم الهندسة المدنية" },
                    { "الهندسة الكهربية", "وصف قسم الهندسة الكهربية" },
                    { "الهندسة المعمارية", "وصف قسم الهندسة المعمارية" },
                    { "الهندسة الميكانيكية", "وصف قسم الهندسة الميكانيكية" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNatId", "BirthDate", "BirthPlace", "Discriminator", "EnrollmentDate", "Gender", "Phone", "SeatNo", "StudentName" },
                values: new object[,]
                {
                    { 535340593458m, null, null, "Student", null, 1, null, null, "إيمان محمود رشوان" },
                    { 535340593459m, null, null, "Student", null, 1, null, null, "إحسان محمود رشوان" },
                    { 789654564m, null, null, "Student", null, 1, null, null, "أميرة محمود رشوان" },
                    { 976546345334m, null, null, "Student", null, 0, null, null, "حسن محمود رشوان" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchName", "BranchDescription", "CurrentCapacity", "DepartmentName", "FullCapacity" },
                values: new object[,]
                {
                    { "الرياضيات والفيزيقا الهندسية", "وصف قسم الرياضيات والفيزيقا الهندسية", 0, "الرياضيات والفيزيقا الهندسية", 2 },
                    { "هندسة القوى الميكانيكية", "وصف شعبة هندسة القوى الميكانيكية", 0, "الهندسة الميكانيكية", 2 },
                    { "الهندسة الصناعية", "وصف شعبة الهندسة الصناعية", 0, "الهندسة الميكانيكية", 2 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "وصف شعبة هندسة الإنتاج والتصميم الميكانيكي", 0, "الهندسة الميكانيكية", 2 },
                    { "الهندسة الميكانيكية", "وصف قسم الهندسة الميكانيكية", 0, "الهندسة الميكانيكية", 1 },
                    { "الهندسة المدنية", "وصف قسم الهندسة المدنية", 0, "الهندسة المدنية", 2 },
                    { "الهندسة المعمارية", "وصف قسم الهندسة المعمارية", 0, "الهندسة المعمارية", 2 },
                    { "هندسة القوى والآلات الكهربية", "وصف شعبة هندسة القوى والآلات الكهربية", 0, "الهندسة الكهربية", 2 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "وصف شعبة هندسة الإلكترونيات والاتصالات الكهربية", 0, "الهندسة الكهربية", 2 },
                    { "هندسة الحاسبات والنظم", "وصف شعبة هندسة الحاسبات والنظم", 0, "الهندسة الكهربية", 2 }
                });

            migrationBuilder.InsertData(
                table: "DepartmentCodes",
                columns: new[] { "DepartmentCodeValue", "DepartmentName" },
                values: new object[,]
                {
                    { "صنع", "الهندسة الميكانيكية" },
                    { "تمج", "الهندسة الميكانيكية" },
                    { "عمر", "الهندسة المعمارية" },
                    { "كهح", "الهندسة الكهربية" },
                    { "كهت", "الهندسة الكهربية" },
                    { "كھع", "الهندسة الكهربية" },
                    { "قوى", "الهندسة الميكانيكية" },
                    { "مدن", "الهندسة المدنية" },
                    { "هند", "الرياضيات والفيزيقا الهندسية" },
                    { "عام", "الرياضيات والفيزيقا الهندسية" },
                    { "ميك", "الرياضيات والفيزيقا الهندسية" },
                    { "فيز", "الرياضيات والفيزيقا الهندسية" },
                    { "ريض", "الرياضيات والفيزيقا الهندسية" },
                    { "كهق", "الهندسة الكهربية" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorNatId", "BirthDate", "BirthPlace", "DepartmentName", "Gender", "HireDate", "InstructorName", "Phone" },
                values: new object[,]
                {
                    { 7567456456646m, null, null, "الهندسة الكهربية", null, null, "إبراهيم فايق", null },
                    { 435345345390m, null, null, "الهندسة المدنية", null, null, "أحمد السيد", null },
                    { 2983423493422m, null, null, "الرياضيات والفيزيقا الهندسية", null, null, "محمد عبد السلام", null },
                    { 435345345345m, null, null, "الهندسة الميكانيكية", null, null, "فايز السيد", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "مجالات كھربية ومغناطيسية ٢", "203", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "إدارة ھندسية", "216", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "حساب التفاضل", "001", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "خواص المادة ومبادئ الديناميكا الحرارية", "001", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "ميكانيكا الھياكل", "213", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "جيولوجيا ھندسية", "102", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "الأساسات", "222", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "التشييد ونظم البناء", "126", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "ھندسة ميكانيكية 1", "105", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "اختبارات كھربية", "305", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "ھندسة الاتصالات والالكترونيات", "215", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "البرمجيات الھندسية", "207", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "InstructorProfessions",
                columns: new[] { "InstructorProfessionID", "InstructorNatId", "ProfessionDegree", "PromotionDate" },
                values: new object[,]
                {
                    { 2, 7567456456646m, 3, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 435345345345m, 2, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 435345345390m, 2, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 1, 2983423493422m, 4, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "AcademicYearID", "StudentNatId", "BranchName", "IsNovember", "LevelName" },
                values: new object[,]
                {
                    { 2023, 976546345334m, "الهندسة الميكانيكية", false, 2 },
                    { 2023, 535340593459m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2023, 789654564m, "هندسة القوى والآلات الكهربية", false, 2 },
                    { 2023, 535340593458m, "الرياضيات والفيزيقا الهندسية", false, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "الرياضيات والفيزيقا الهندسية", "حساب التفاضل", 0, 0 },
                    { "الهندسة الميكانيكية", "خواص المادة ومبادئ الديناميكا الحرارية", 2, 0 },
                    { "الهندسة المدنية", "الأساسات", 1, 0 },
                    { "هندسة القوى والآلات الكهربية", "مجالات كھربية ومغناطيسية ٢", 3, 1 },
                    { "هندسة القوى والآلات الكهربية", "اختبارات كھربية", 2, 1 },
                    { "هندسة القوى والآلات الكهربية", "ھندسة الاتصالات والالكترونيات", 2, 1 },
                    { "الهندسة الميكانيكية", "ميكانيكا الھياكل", 2, 0 },
                    { "الهندسة الميكانيكية", "إدارة ھندسية", 2, 0 },
                    { "الهندسة الميكانيكية", "ھندسة ميكانيكية 1", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Selection",
                columns: new[] { "SelectionID", "AcademicYearID", "CurrentBranchName", "SelectionBranchName", "SelectionNo", "StudentNatId", "StudentNatId1" },
                values: new object[,]
                {
                    { 1, 2023, "الرياضيات والفيزيقا الهندسية", "الهندسة الميكانيكية", 1, 535340593458m, null },
                    { 2, 2023, "الرياضيات والفيزيقا الهندسية", "الهندسة المدنية", 2, 535340593458m, null },
                    { 3, 2023, "الرياضيات والفيزيقا الهندسية", "الهندسة الميكانيكية", 1, 535340593459m, null },
                    { 4, 2023, "الرياضيات والفيزيقا الهندسية", "الهندسة المدنية", 2, 535340593459m, null }
                });

            migrationBuilder.InsertData(
                table: "InstructorEnrollments",
                columns: new[] { "InstructorEnrollmentID", "AcademicYearID", "BranchName", "CourseName", "InstructorNatId" },
                values: new object[,]
                {
                    { 1, 2023, "الرياضيات والفيزيقا الهندسية", "حساب التفاضل", 2983423493422m },
                    { 6, 2023, "الهندسة الميكانيكية", "خواص المادة ومبادئ الديناميكا الحرارية", 435345345345m },
                    { 8, 2023, "الهندسة المدنية", "الأساسات", 435345345345m },
                    { 3, 2023, "هندسة القوى والآلات الكهربية", "اختبارات كھربية", 7567456456646m },
                    { 2, 2023, "هندسة القوى والآلات الكهربية", "ھندسة الاتصالات والالكترونيات", 7567456456646m },
                    { 5, 2023, "الهندسة الميكانيكية", "ميكانيكا الھياكل", 435345345345m },
                    { 4, 2023, "الهندسة الميكانيكية", "إدارة ھندسية", 435345345345m },
                    { 7, 2023, "الهندسة الميكانيكية", "ھندسة ميكانيكية 1", 435345345345m }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "StudentCourseID", "AcademicYearID", "BranchName", "CourseName", "CourseWorkMark", "FinalExamMark", "IsNovember", "MerciMark", "MidTermMark", "OralExamMark", "StudentNatId" },
                values: new object[,]
                {
                    { 1, 2023, "الرياضيات والفيزيقا الهندسية", "حساب التفاضل", 0.0, 0.0, false, 0.0, 0.0, 0.0, 535340593458m },
                    { 2, 2023, "الرياضيات والفيزيقا الهندسية", "حساب التفاضل", 0.0, 0.0, false, 0.0, 0.0, 0.0, 535340593459m },
                    { 7, 2023, "الهندسة الميكانيكية", "خواص المادة ومبادئ الديناميكا الحرارية", 0.0, 0.0, false, 0.0, 0.0, 0.0, 976546345334m },
                    { 4, 2023, "هندسة القوى والآلات الكهربية", "اختبارات كھربية", 0.0, 10.0, false, 0.0, 0.0, 0.0, 789654564m },
                    { 3, 2023, "هندسة القوى والآلات الكهربية", "ھندسة الاتصالات والالكترونيات", 0.0, 70.0, false, 0.0, 0.0, 0.0, 789654564m },
                    { 6, 2023, "الهندسة الميكانيكية", "ميكانيكا الھياكل", 0.0, 0.0, false, 0.0, 0.0, 0.0, 976546345334m },
                    { 5, 2023, "الهندسة الميكانيكية", "إدارة ھندسية", 0.0, 0.0, false, 0.0, 0.0, 0.0, 976546345334m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DepartmentName",
                table: "Branches",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_BranchName",
                table: "CourseEnrollments",
                column: "BranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentCodeValue",
                table: "Courses",
                column: "DepartmentCodeValue");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCodes_DepartmentName",
                table: "DepartmentCodes",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_AcademicYearID",
                table: "InstructorEnrollments",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_CourseName_BranchName",
                table: "InstructorEnrollments",
                columns: new[] { "CourseName", "BranchName" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_InstructorNatId",
                table: "InstructorEnrollments",
                column: "InstructorNatId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProfessions_InstructorNatId",
                table: "InstructorProfessions",
                column: "InstructorNatId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentName",
                table: "Instructors",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_AcademicYearID",
                table: "Selection",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_CurrentBranchName",
                table: "Selection",
                column: "CurrentBranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_SelectionBranchName",
                table: "Selection",
                column: "SelectionBranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_StudentNatId_AcademicYearID",
                table: "Selection",
                columns: new[] { "StudentNatId", "AcademicYearID" });

            migrationBuilder.CreateIndex(
                name: "IX_Selection_StudentNatId1",
                table: "Selection",
                column: "StudentNatId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseName_BranchName",
                table: "StudentCourses",
                columns: new[] { "CourseName", "BranchName" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentNatId_AcademicYearID",
                table: "StudentCourses",
                columns: new[] { "StudentNatId", "AcademicYearID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_AcademicYearID",
                table: "StudentEnrollments",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_BranchName",
                table: "StudentEnrollments",
                column: "BranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BranchName1",
                table: "Students",
                column: "BranchName1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InstructorEnrollments");

            migrationBuilder.DropTable(
                name: "InstructorProfessions");

            migrationBuilder.DropTable(
                name: "Selection");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "CourseEnrollments");

            migrationBuilder.DropTable(
                name: "StudentEnrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "DepartmentCodes");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

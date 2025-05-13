using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentCredits.Infrastructure.Contexts.StudentCredits.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.EnsureSchema(
        name: "dbo");

    migrationBuilder.CreateTable(
        name: "Student",
        schema: "dbo",
        columns: table => new
        {
          StudentId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
          DocumentNumber = table.Column<string>(type: "text", nullable: false),
          Firstname = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
          Lastname = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
          Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
          Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
          xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Student", x => x.StudentId);
        });

    migrationBuilder.CreateTable(
        name: "Subject",
        schema: "dbo",
        columns: table => new
        {
          SubjectId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
          Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
          Description = table.Column<string>(type: "text", nullable: true),
          Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
          xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Subject", x => x.SubjectId);
        });

    migrationBuilder.CreateTable(
        name: "Teacher",
        schema: "dbo",
        columns: table => new
        {
          TeacherId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
          DocumentNumber = table.Column<string>(type: "text", nullable: false),
          Firstname = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
          Lastname = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
          Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
          Profession = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
          Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
          xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Teacher", x => x.TeacherId);
        });

    migrationBuilder.CreateTable(
        name: "TeacherDetail",
        schema: "dbo",
        columns: table => new
        {
          TeacherDetailId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
          TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
          SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
          Credits = table.Column<decimal>(type: "numeric(2,1)", precision: 2, scale: 1, nullable: false),
          Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
          xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_TeacherDetail", x => x.TeacherDetailId);
          table.ForeignKey(
                    name: "FK_TeacherDetail_Subject_SubjectId",
                    column: x => x.SubjectId,
                    principalSchema: "dbo",
                    principalTable: "Subject",
                    principalColumn: "SubjectId",
                    onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
                    name: "FK_TeacherDetail_Teacher_TeacherId",
                    column: x => x.TeacherId,
                    principalSchema: "dbo",
                    principalTable: "Teacher",
                    principalColumn: "TeacherId",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateTable(
        name: "StudentDetail",
        schema: "dbo",
        columns: table => new
        {
          StudentDetailId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
          TeacherDetailId = table.Column<Guid>(type: "uuid", nullable: false),
          StudentId = table.Column<Guid>(type: "uuid", nullable: false),
          Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
          xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_StudentDetail", x => x.StudentDetailId);
          table.ForeignKey(
                    name: "FK_StudentDetail_Student_StudentId",
                    column: x => x.StudentId,
                    principalSchema: "dbo",
                    principalTable: "Student",
                    principalColumn: "StudentId",
                    onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
                    name: "FK_StudentDetail_TeacherDetail_TeacherDetailId",
                    column: x => x.TeacherDetailId,
                    principalSchema: "dbo",
                    principalTable: "TeacherDetail",
                    principalColumn: "TeacherDetailId",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "Student",
        columns: new[] { "StudentId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname" },
        values: new object[,]
        {
                  { new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new DateTimeOffset(new DateTime(2024, 3, 3, 2, 2, 2, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1109432112", "jeison.bonilla@gmail.com", "Jeison Andrés", "Bonilla" },
                  { new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new DateTimeOffset(new DateTime(2024, 3, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1033671288", "angela.suarez@outlook.com", "Angela Natalia", "Suarez" }
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "Subject",
        columns: new[] { "SubjectId", "Created", "Description", "Name" },
        values: new object[,]
        {
                  { new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"), new DateTimeOffset(new DateTime(2024, 1, 11, 1, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn to identify system problems with a general, reusable, scalable and applicable solution", "Design Patterns" },
                  { new Guid("4b2d9626-0259-42a5-a98c-11019b4cf873"), new DateTimeOffset(new DateTime(2024, 1, 20, 7, 6, 7, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Discover how a Scrum Master can lead a team and keep members focused on the principles of the framework", "Scrum Master Fundamentals" },
                  { new Guid("5a5f617c-4b9b-4974-9104-bd173b107172"), new DateTimeOffset(new DateTime(2024, 1, 16, 3, 2, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how clean architectures work to separate concerns into different, well-defined layers, with strict rules about how they should interact with each other", "Clean Architecture" },
                  { new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"), new DateTimeOffset(new DateTime(2024, 1, 15, 2, 1, 2, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to apply a set of rules and best practices for software development", "S.O.L.I.D Principles" },
                  { new Guid("9748e5ff-07ba-4cb8-8617-53a785fc2ebf"), new DateTimeOffset(new DateTime(2024, 1, 22, 9, 8, 9, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to become an expert with TypeScript the JavaScript superset for strict typing", "Development With TypeScript" },
                  { new Guid("a3e42c74-8a68-4e2d-b339-caa2e89db0a7"), new DateTimeOffset(new DateTime(2024, 1, 23, 10, 9, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to develop with one of the most popular and powerful frameworks, create robust applications", "Angular Fundamentals" },
                  { new Guid("e2fd4b74-7b10-446e-821e-55717899c400"), new DateTimeOffset(new DateTime(2024, 1, 19, 6, 5, 6, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn about the most popular tools for QA Automation, features and benefits", "QA Automation Tools" },
                  { new Guid("e9a4cce8-57b0-4693-bf22-cfec292bccc5"), new DateTimeOffset(new DateTime(2024, 1, 18, 5, 4, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn why QA Automation is so important in the software development cycle", "QA Automation Fundamentals" },
                  { new Guid("eb8e2deb-9f48-4376-b5d0-9e5f898d6586"), new DateTimeOffset(new DateTime(2024, 1, 17, 4, 3, 4, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to implement a design methodology for rapid deployment and updating of cloud-based applications", "Microservices Architecture" },
                  { new Guid("fc560c08-aa92-44c6-9ae1-101987824877"), new DateTimeOffset(new DateTime(2024, 1, 21, 8, 7, 8, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Discover how a Scrum Master should expertly plan to maintain a fully agile team", "Planning a scrum master" }
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "Teacher",
        columns: new[] { "TeacherId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname", "Profession" },
        values: new object[,]
        {
                  { new Guid("08cd0782-93ba-4de3-b363-e7a4df2bfe7b"), new DateTimeOffset(new DateTime(2024, 2, 3, 2, 3, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1127789231", "ana.suarez@outlook.com", "Ana Camila", "Suarez", "QA Automation" },
                  { new Guid("42318f73-c7fd-4490-9594-7c72a77bbee7"), new DateTimeOffset(new DateTime(2024, 2, 4, 3, 4, 4, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1643398122", "maria_natalia.garcia@outlook.com", "Maria Natalia", "Garcia", "Scrum Master" },
                  { new Guid("c774f591-750a-47f9-b283-327cdb62f627"), new DateTimeOffset(new DateTime(2024, 2, 5, 4, 5, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1992233120", "carlos.herrera@gmail.com", "Carlos Francisco", "Herrera", "Senior Frontend Developer" },
                  { new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"), new DateTimeOffset(new DateTime(2024, 2, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1023944678", "cristian10camilo95@gmail.com", "Cristian Camilo", "Bonilla", "Senior Software Developer" },
                  { new Guid("f41ed5f9-d853-4077-b6fe-9bb277bee93d"), new DateTimeOffset(new DateTime(2024, 2, 2, 1, 2, 2, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1090012334", "fernando.gutierrez@gmail.com", "Fernando", "Gutierrez", "Senior Software Architect" }
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "TeacherDetail",
        columns: new[] { "TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId" },
        values: new object[,]
        {
                  { new Guid("10ed0335-ece3-4e80-9c01-28e1f1f3fe67"), new DateTimeOffset(new DateTime(2024, 2, 11, 11, 10, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("a3e42c74-8a68-4e2d-b339-caa2e89db0a7"), new Guid("c774f591-750a-47f9-b283-327cdb62f627") },
                  { new Guid("3b34bdd2-dc7c-41a1-bd79-dc8465aa2bf1"), new DateTimeOffset(new DateTime(2024, 2, 5, 4, 3, 4, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("eb8e2deb-9f48-4376-b5d0-9e5f898d6586"), new Guid("f41ed5f9-d853-4077-b6fe-9bb277bee93d") },
                  { new Guid("4f098579-1bd2-4e7c-822a-9160871450de"), new DateTimeOffset(new DateTime(2024, 2, 8, 7, 6, 7, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("4b2d9626-0259-42a5-a98c-11019b4cf873"), new Guid("42318f73-c7fd-4490-9594-7c72a77bbee7") },
                  { new Guid("7240162d-4f52-425d-a4f6-54b4127e8828"), new DateTimeOffset(new DateTime(2024, 2, 10, 9, 8, 9, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("9748e5ff-07ba-4cb8-8617-53a785fc2ebf"), new Guid("c774f591-750a-47f9-b283-327cdb62f627") },
                  { new Guid("a5794476-1317-4ebc-86b3-e9640b20a1a8"), new DateTimeOffset(new DateTime(2024, 2, 9, 8, 7, 8, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("fc560c08-aa92-44c6-9ae1-101987824877"), new Guid("42318f73-c7fd-4490-9594-7c72a77bbee7") },
                  { new Guid("ccc8bb25-685f-404b-b53d-d446686f9cec"), new DateTimeOffset(new DateTime(2024, 2, 7, 6, 5, 6, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("e2fd4b74-7b10-446e-821e-55717899c400"), new Guid("08cd0782-93ba-4de3-b363-e7a4df2bfe7b") },
                  { new Guid("cf98b2d3-7d9b-4ce1-996a-ed25c706b644"), new DateTimeOffset(new DateTime(2024, 2, 6, 5, 4, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("e9a4cce8-57b0-4693-bf22-cfec292bccc5"), new Guid("08cd0782-93ba-4de3-b363-e7a4df2bfe7b") },
                  { new Guid("d6e0c50c-e994-4d6b-aca0-ebc09b411aa0"), new DateTimeOffset(new DateTime(2024, 2, 4, 3, 2, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("5a5f617c-4b9b-4974-9104-bd173b107172"), new Guid("f41ed5f9-d853-4077-b6fe-9bb277bee93d") },
                  { new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046"), new DateTimeOffset(new DateTime(2024, 2, 3, 2, 1, 2, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"), new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47") },
                  { new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2"), new DateTimeOffset(new DateTime(2024, 2, 2, 1, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.0m, new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"), new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47") }
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "StudentDetail",
        columns: new[] { "StudentDetailId", "Created", "StudentId", "TeacherDetailId" },
        values: new object[,]
        {
                  { new Guid("11ab0e13-3a0a-4fd7-9f80-3dc89b181efb"), new DateTimeOffset(new DateTime(2024, 3, 2, 1, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2") },
                  { new Guid("2096ecba-29db-49d6-9646-a6c3e424953f"), new DateTimeOffset(new DateTime(2024, 3, 3, 2, 1, 2, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046") },
                  { new Guid("90812e38-67ad-4207-8017-e2b09231231e"), new DateTimeOffset(new DateTime(2024, 3, 2, 1, 0, 4, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046") },
                  { new Guid("eab71419-9084-4e72-9558-ce4d76f0fd30"), new DateTimeOffset(new DateTime(2024, 3, 4, 3, 2, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2") }
        });

    migrationBuilder.CreateIndex(
        name: "IX_Student_DocumentNumber_Email",
        schema: "dbo",
        table: "Student",
        columns: new[] { "DocumentNumber", "Email" },
        unique: true);

    migrationBuilder.CreateIndex(
        name: "IX_StudentDetail_StudentId",
        schema: "dbo",
        table: "StudentDetail",
        column: "StudentId");

    migrationBuilder.CreateIndex(
        name: "IX_StudentDetail_TeacherDetailId",
        schema: "dbo",
        table: "StudentDetail",
        column: "TeacherDetailId");

    migrationBuilder.CreateIndex(
        name: "IX_Subject_Name",
        schema: "dbo",
        table: "Subject",
        column: "Name",
        unique: true);

    migrationBuilder.CreateIndex(
        name: "IX_Teacher_DocumentNumber_Email",
        schema: "dbo",
        table: "Teacher",
        columns: new[] { "DocumentNumber", "Email" },
        unique: true);

    migrationBuilder.CreateIndex(
        name: "IX_TeacherDetail_SubjectId",
        schema: "dbo",
        table: "TeacherDetail",
        column: "SubjectId");

    migrationBuilder.CreateIndex(
        name: "IX_TeacherDetail_TeacherId",
        schema: "dbo",
        table: "TeacherDetail",
        column: "TeacherId");
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "StudentDetail",
        schema: "dbo");

    migrationBuilder.DropTable(
        name: "Student",
        schema: "dbo");

    migrationBuilder.DropTable(
        name: "TeacherDetail",
        schema: "dbo");

    migrationBuilder.DropTable(
        name: "Subject",
        schema: "dbo");

    migrationBuilder.DropTable(
        name: "Teacher",
        schema: "dbo");
  }
}

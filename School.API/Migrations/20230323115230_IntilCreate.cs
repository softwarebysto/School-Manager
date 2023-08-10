using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.API.Migrations
{
    /// <inheritdoc />
    public partial class IntilCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    school_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    region_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    school_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    students_count = table.Column<int>(type: "int", nullable: false),
                    class_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schoolid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Classes_school_Schoolid",
                        column: x => x.Schoolid,
                        principalTable: "school",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_Classesid",
                        column: x => x.Classesid,
                        principalTable: "Classes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectsDTO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    techer_id = table.Column<int>(type: "int", nullable: true),
                    subject_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsDTO", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubjectsDTO_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "school",
                columns: new[] { "id", "school_name" },
                values: new object[,]
                {
                    { 1, "124-School" },
                    { 2, "123-School" }
                });

            migrationBuilder.InsertData(
                table: "schools",
                columns: new[] { "id", "region_name", "school_name" },
                values: new object[] { 1, "Tashkent", "124-School" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Schoolid",
                table: "Classes",
                column: "Schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Classesid",
                table: "Students",
                column: "Classesid");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsDTO_StudentsId",
                table: "SubjectsDTO",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schools");

            migrationBuilder.DropTable(
                name: "SubjectsDTO");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "school");
        }
    }
}

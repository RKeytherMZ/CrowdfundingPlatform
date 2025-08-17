using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrowdFunding.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyStudentProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Students_StudentId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_StudentId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "StudentProjects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProjects", x => new { x.ProjectId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentProjects_StudentId",
                table: "StudentProjects",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentProjects");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentId",
                table: "Projects",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Students_StudentId",
                table: "Projects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

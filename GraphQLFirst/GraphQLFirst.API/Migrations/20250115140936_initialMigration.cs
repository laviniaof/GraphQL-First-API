using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLFirst.API.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorID",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Courses",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorID",
                table: "Courses",
                newName: "IX_Courses_InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Courses",
                newName: "InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                newName: "IX_Courses_InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorID",
                table: "Courses",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

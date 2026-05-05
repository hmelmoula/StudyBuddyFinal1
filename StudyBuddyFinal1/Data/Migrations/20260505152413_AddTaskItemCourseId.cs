using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyBuddyFinal1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskItemCourseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "TaskItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CourseId",
                table: "TaskItems",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Course_CourseId",
                table: "TaskItems",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Course_CourseId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_CourseId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "TaskItems");
        }
    }
}

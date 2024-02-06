using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizMaster.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingUserQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Quizzes",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quizzes",
                newName: "QuizId");
        }
    }
}

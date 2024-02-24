using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizMaster.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixingUserQuizConflict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizzes_Quizzes_QuizId1",
                table: "UserQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_UserQuizzes_QuizId1",
                table: "UserQuizzes");

            migrationBuilder.DropColumn(
                name: "QuizId1",
                table: "UserQuizzes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizId1",
                table: "UserQuizzes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizzes_QuizId1",
                table: "UserQuizzes",
                column: "QuizId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizzes_Quizzes_QuizId1",
                table: "UserQuizzes",
                column: "QuizId1",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }
    }
}

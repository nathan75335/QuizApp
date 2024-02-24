using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizMaster.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUSerQuizEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserQuizzes");

            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "UserQuizzes");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeLimit",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "UserQuizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeLimit",
                table: "UserQuizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

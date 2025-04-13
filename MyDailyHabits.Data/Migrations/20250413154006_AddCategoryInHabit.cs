using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyHabits.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryInHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Habits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Habits");
        }
    }
}

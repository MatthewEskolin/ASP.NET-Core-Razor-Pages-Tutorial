using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_Pages_Tutorial.Migrations
{
    public partial class testId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Comment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Comment");
        }
    }
}

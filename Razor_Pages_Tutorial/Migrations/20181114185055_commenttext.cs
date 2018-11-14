using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_Pages_Tutorial.Migrations
{
    public partial class commenttext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentText",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentText",
                table: "Comments");
        }
    }
}

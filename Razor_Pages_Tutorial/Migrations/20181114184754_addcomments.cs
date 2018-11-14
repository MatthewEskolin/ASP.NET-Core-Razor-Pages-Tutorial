using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_Pages_Tutorial.Migrations
{
    public partial class addcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Bug_BugID",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BugID",
                table: "Comments",
                newName: "IX_Comments_BugID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Bug_BugID",
                table: "Comments",
                column: "BugID",
                principalTable: "Bug",
                principalColumn: "BugID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Bug_BugID",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BugID",
                table: "Comment",
                newName: "IX_Comment_BugID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Bug_BugID",
                table: "Comment",
                column: "BugID",
                principalTable: "Bug",
                principalColumn: "BugID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

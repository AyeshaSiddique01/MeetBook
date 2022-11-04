using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetBook.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostLikeID",
                table: "PostLikes",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PostLikes",
                newName: "PostLikeID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetBook.Migrations
{
    public partial class myMig9133k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateCreated",
                table: "Account",
                type: "nchar(20)",
                fixedLength: true,
                maxLength: 20,
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetBook.Migrations
{
    public partial class newInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Table");

            //migrationBuilder.AddColumn<int>(
            //    name: "PostLikeID",
            //    table: "PostLikes",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProfilePic",
            //    table: "Account",
            //    type: "nchar(200)",
            //    fixedLength: true,
            //    maxLength: 200,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nchar(50)",
            //    oldFixedLength: true,
            //    oldMaxLength: 50,
            //    oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "PostLikeID",
            //    table: "PostLikes");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProfilePic",
            //    table: "Account",
            //    type: "nchar(50)",
            //    fixedLength: true,
            //    maxLength: 50,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nchar(200)",
            //    oldFixedLength: true,
            //    oldMaxLength: 200,
            //    oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Table",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Table", x => x.Id);
            //    });
        }
    }
}

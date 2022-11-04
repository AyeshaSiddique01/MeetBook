using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetBook.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdDate",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedDate",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "PostLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdDate",
                table: "PostLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "PostLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedDate",
                table: "PostLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "FriendList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdDate",
                table: "FriendList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "FriendList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedDate",
                table: "FriendList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdDate",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modifiedDate",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "modifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "modifiedDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "modifiedDate",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "FriendList");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "FriendList");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "FriendList");

            migrationBuilder.DropColumn(
                name: "modifiedDate",
                table: "FriendList");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "modifiedDate",
                table: "Account");
        }
    }
}

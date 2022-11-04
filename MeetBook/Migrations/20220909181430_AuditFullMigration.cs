using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetBook.Migrations
{
    public partial class AuditFullMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Users",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "modifiedDate",
                table: "Users",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Users",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Users",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Posts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "modifiedDate",
                table: "Posts",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Posts",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Posts",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "PostLikes",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "modifiedDate",
                table: "PostLikes",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "PostLikes",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "PostLikes",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "FriendList",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "modifiedDate",
                table: "FriendList",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "FriendList",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "FriendList",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Account",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "modifiedDate",
                table: "Account",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Account",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Account",
                newName: "CreatedByUserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PostLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FriendList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FriendList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FriendList");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FriendList");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Users",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "Users",
                newName: "modifiedDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Users",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Users",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Posts",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "Posts",
                newName: "modifiedDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Posts",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Posts",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "PostLikes",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "PostLikes",
                newName: "modifiedDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "PostLikes",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "PostLikes",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "FriendList",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "FriendList",
                newName: "modifiedDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "FriendList",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "FriendList",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Account",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "Account",
                newName: "modifiedDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Account",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Account",
                newName: "createdBy");
        }
    }
}

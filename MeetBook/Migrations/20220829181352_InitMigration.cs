using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetBook.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        LName = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
            //        DOB = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Gender = table.Column<string>(type: "nchar(7)", fixedLength: true, maxLength: 7, nullable: false),
            //        email = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
            //        PhoneNo = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.UserId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Account",
            //    columns: table => new
            //    {
            //        AccountId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(type: "int", nullable: false),
            //        Password = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
            //        DateCreated = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        AccountStatus = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
            //        ProfilePic = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
            //        Status = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
            //        LoginID = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
            //        logIn = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Account", x => x.AccountId);
            //        table.ForeignKey(
            //            name: "FK_Account_Users",
            //            column: x => x.UserID,
            //            principalTable: "Users",
            //            principalColumn: "UserId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FriendList",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AccountID = table.Column<int>(type: "int", nullable: false),
            //        FriendID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FriendList", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_FriendList_Account1",
            //            column: x => x.AccountID,
            //            principalTable: "Account",
            //            principalColumn: "AccountId");
            //        table.ForeignKey(
            //            name: "FK_FriendList_Account2",
            //            column: x => x.FriendID,
            //            principalTable: "Account",
            //            principalColumn: "AccountId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Posts",
            //    columns: table => new
            //    {
            //        PostId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AccountID = table.Column<int>(type: "int", nullable: false),
            //        PostImage = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
            //        PostDate = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
            //        NumberOfLikes = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Posts", x => x.PostId);
            //        table.ForeignKey(
            //            name: "FK_Posts_Account",
            //            column: x => x.AccountID,
            //            principalTable: "Account",
            //            principalColumn: "AccountId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostLikes",
            //    columns: table => new
            //    {
            //        PostID = table.Column<int>(type: "int", nullable: false),
            //        ReactedBy = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "FK_PostLikes_Accounts",
            //            column: x => x.ReactedBy,
            //            principalTable: "Account",
            //            principalColumn: "AccountId");
            //        table.ForeignKey(
            //            name: "FK_PostLikes_Posts",
            //            column: x => x.PostID,
            //            principalTable: "Posts",
            //            principalColumn: "PostId");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Account_UserID",
            //    table: "Account",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FriendList_AccountID",
            //    table: "FriendList",
            //    column: "AccountID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FriendList_FriendID",
            //    table: "FriendList",
            //    column: "FriendID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostLikes_PostID",
            //    table: "PostLikes",
            //    column: "PostID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostLikes_ReactedBy",
            //    table: "PostLikes",
            //    column: "ReactedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Posts_AccountID",
            //    table: "Posts",
            //    column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "FriendList");

            //migrationBuilder.DropTable(
            //    name: "PostLikes");

            //migrationBuilder.DropTable(
            //    name: "Table");

            //migrationBuilder.DropTable(
            //    name: "Posts");

            //migrationBuilder.DropTable(
            //    name: "Account");

            //migrationBuilder.DropTable(
            //    name: "Users");
        }
    }
}

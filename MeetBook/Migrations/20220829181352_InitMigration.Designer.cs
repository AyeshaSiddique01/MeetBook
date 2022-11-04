﻿// <auto-generated />
using MeetBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MeetBook.Models;

#nullable disable

namespace MeetBook.Migrations
{
    [DbContext(typeof(MeetBookContext))]
    [Migration("20220829181352_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MeetBook.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength();

                    b.Property<string>("DateCreated")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("LogIn")
                        .HasColumnType("int")
                        .HasColumnName("logIn");

                    b.Property<string>("LoginId")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .HasColumnName("LoginID")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .IsFixedLength();

                    b.Property<string>("ProfilePic")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("MeetBook.Models.FriendList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<int>("FriendId")
                        .HasColumnType("int")
                        .HasColumnName("FriendID");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("FriendId");

                    b.ToTable("FriendList", (string)null);
                });

            modelBuilder.Entity("MeetBook.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<string>("PostDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength();

                    b.Property<string>("PostImage")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .IsFixedLength();

                    b.HasKey("PostId");

                    b.HasIndex("AccountId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MeetBook.Models.PostLike", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    b.Property<int>("ReactedBy")
                        .HasColumnType("int");

                    b.HasIndex("PostId");

                    b.HasIndex("ReactedBy");

                    b.ToTable("PostLikes");
                });

            modelBuilder.Entity("MeetBook.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Table", (string)null);
                });

            modelBuilder.Entity("MeetBook.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("DOB");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("email")
                        .IsFixedLength();

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("FName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nchar(7)")
                        .IsFixedLength();

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("LName")
                        .IsFixedLength();

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeetBook.Models.Account", b =>
                {
                    b.HasOne("MeetBook.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Account_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeetBook.Models.FriendList", b =>
                {
                    b.HasOne("MeetBook.Models.Account", "Account")
                        .WithMany("FriendListAccounts")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_FriendList_Account1");

                    b.HasOne("MeetBook.Models.Account", "Friend")
                        .WithMany("FriendListFriends")
                        .HasForeignKey("FriendId")
                        .IsRequired()
                        .HasConstraintName("FK_FriendList_Account2");

                    b.Navigation("Account");

                    b.Navigation("Friend");
                });

            modelBuilder.Entity("MeetBook.Models.Post", b =>
                {
                    b.HasOne("MeetBook.Models.Account", "Account")
                        .WithMany("Posts")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Posts_Account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MeetBook.Models.PostLike", b =>
                {
                    b.HasOne("MeetBook.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_PostLikes_Posts");

                    b.HasOne("MeetBook.Models.Account", "ReactedByNavigation")
                        .WithMany()
                        .HasForeignKey("ReactedBy")
                        .IsRequired()
                        .HasConstraintName("FK_PostLikes_Accounts");

                    b.Navigation("Post");

                    b.Navigation("ReactedByNavigation");
                });

            modelBuilder.Entity("MeetBook.Models.Account", b =>
                {
                    b.Navigation("FriendListAccounts");

                    b.Navigation("FriendListFriends");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("MeetBook.Models.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}

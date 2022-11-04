using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Mvc;
using MeetBook.Models.Interfaces;

namespace MeetBook.Models
{
    public partial class MeetBookContext : DbContext
    {
        public MeetBookContext() { }

        public MeetBookContext(DbContextOptions<MeetBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<FriendList> FriendLists { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostLike> PostLikes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // optionsBuilder.UseSqlServer(@"Server=localhost,1440; Database=master; User=sa; Password=Strong@Passw0rd");
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MeetBook;Integrated Secugtirity=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        public override int SaveChanges()
        {
            
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is FullAuditModel)
                {

                    if (entry.Entity is User)
                    {
                        var UserReferenceEntity = entry.Entity as User;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                UserReferenceEntity.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                UserReferenceEntity.CreatedByUserId = UserReferenceEntity.Email;
                                UserReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                UserReferenceEntity.LastModifiedUserId = UserReferenceEntity.Email;
                                UserReferenceEntity.IsActive = true;
                                break;

                            case EntityState.Deleted:
                                UserReferenceEntity.IsDeleted = true;
                                UserReferenceEntity.IsActive = false;
                                break;

                            case EntityState.Modified:
                                UserReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                UserReferenceEntity.LastModifiedUserId = UserReferenceEntity.Email;
                                break;

                            default:
                                break;
                        }
                    }
                    else if (entry.Entity is Account)
                    {
                        var AccreferenceEntity = entry.Entity as Account;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                AccreferenceEntity.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                AccreferenceEntity.CreatedByUserId = AccreferenceEntity.AccountId.ToString();
                                AccreferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                AccreferenceEntity.LastModifiedUserId = AccreferenceEntity.AccountId.ToString();
                                AccreferenceEntity.IsActive = true;
                                break;

                            case EntityState.Deleted:
                                AccreferenceEntity.IsDeleted = true;
                                AccreferenceEntity.IsActive = false;
                                break;

                            case EntityState.Modified:
                                AccreferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                AccreferenceEntity.LastModifiedUserId = AccreferenceEntity.AccountId.ToString();
                                break;

                            default:
                                break;
                        }
                    }
                    else if (entry.Entity is FriendList)
                    {
                        var FLReferenceEntity = entry.Entity as FriendList;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                FLReferenceEntity.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                FLReferenceEntity.CreatedByUserId = FLReferenceEntity.AccountId.ToString();
                                FLReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                FLReferenceEntity.LastModifiedUserId = FLReferenceEntity.AccountId.ToString();
                                FLReferenceEntity.IsActive = true;
                                break;

                            case EntityState.Deleted:
                                FLReferenceEntity.IsDeleted = true;
                                FLReferenceEntity.IsActive = false;
                                break;

                            case EntityState.Modified:
                                FLReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                FLReferenceEntity.LastModifiedUserId = FLReferenceEntity.AccountId.ToString();
                                break;

                            default:
                                break;
                        }
                    }
                    else if (entry.Entity is Post)
                    {
                        var PostReferenceEntity = entry.Entity as Post;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                PostReferenceEntity.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                PostReferenceEntity.CreatedByUserId = PostReferenceEntity.AccountId.ToString();
                                PostReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                PostReferenceEntity.LastModifiedUserId = PostReferenceEntity.AccountId.ToString();
                                PostReferenceEntity.IsActive = true;
                                break;

                            case EntityState.Deleted:
                                PostReferenceEntity.IsDeleted = true;
                                PostReferenceEntity.IsActive = false;
                                break;

                            case EntityState.Modified:
                                PostReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                PostReferenceEntity.LastModifiedUserId = PostReferenceEntity.AccountId.ToString();
                                break;

                            default:
                                break;
                        }
                    }
                    else if (entry.Entity is PostLike)
                    {
                        var PostLikeReferenceEntity = entry.Entity as PostLike;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                PostLikeReferenceEntity.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                PostLikeReferenceEntity.CreatedByUserId = PostLikeReferenceEntity.ReactedBy.ToString();
                                PostLikeReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                PostLikeReferenceEntity.LastModifiedUserId = PostLikeReferenceEntity.ReactedBy.ToString();
                                PostLikeReferenceEntity.IsActive = true;
                                break;

                            case EntityState.Deleted:
                                PostLikeReferenceEntity.IsDeleted = true;
                                PostLikeReferenceEntity.IsActive = false;
                                break;

                            case EntityState.Modified:
                                PostLikeReferenceEntity.LastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy");
                                PostLikeReferenceEntity.LastModifiedUserId = PostLikeReferenceEntity.ReactedBy.ToString();
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountStatus)
                    .HasMaxLength(15)
                    .IsFixedLength();

                //entity.Property(e => e.DateCreated)
                //    .HasMaxLength(20)
                //    .IsFixedLength();

                entity.Property(e => e.LogIn).HasColumnName("logIn");

                entity.Property(e => e.LoginId)
                    .HasMaxLength(100)
                    .HasColumnName("LoginID")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.ProfilePic)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Users");
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.ToTable("FriendList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FriendListAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendList_Account1");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendListFriends)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendList_Account2");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.PostDate)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PostImage)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Account");
            });

            modelBuilder.Entity<PostLike>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.PostId).HasColumnName("PostID");

                //entity.Property(e => e.Id)
                //    .ValueGeneratedOnAdd()
                //    .HasColumnName("ID");

                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostLikes_Posts");

                entity.HasOne(d => d.ReactedByNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ReactedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostLikes_Accounts");
            });
            
            modelBuilder.Entity<User>(entity =>
            {

                entity.Property(e => e.Dob)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .HasColumnName("LName")
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

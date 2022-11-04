using System;
using System.Collections.Generic;

namespace MeetBook.Models
{
    public partial class Account : FullAuditModel
    {
        public Account()
        {
            FriendListAccounts = new HashSet<FriendList>();
            FriendListFriends = new HashSet<FriendList>();
            Posts = new HashSet<Post>();
        }

        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; } = null!;
        //public string? DateCreated { get; set; }
        public string AccountStatus { get; set; } = null!;
        public string? ProfilePic { get; set; }
        public string? Status { get; set; }
        public string? LoginId { get; set; }
        public int LogIn { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<FriendList> FriendListAccounts { get; set; }
        public virtual ICollection<FriendList> FriendListFriends { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

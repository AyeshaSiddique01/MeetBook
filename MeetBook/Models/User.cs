using System;
using System.Collections.Generic;

namespace MeetBook.Models
{
    public partial class User : FullAuditModel
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        public int UserId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Dob { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}

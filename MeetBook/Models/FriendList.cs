using System;
using System.Collections.Generic;

namespace MeetBook.Models
{
    public partial class FriendList : FullAuditModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int FriendId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Account Friend { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace MeetBook.Models
{
    public partial class Post : FullAuditModel
    {
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public string? PostImage { get; set; }
        public string PostDate { get; set; } = null!;
        public int NumberOfLikes { get; set; }
        public virtual Account Account { get; set; } = null!;
    }
}

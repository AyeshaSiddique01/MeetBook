using System;
using System.Collections.Generic;

namespace MeetBook.Models
{
    public partial class PostLike : FullAuditModel
    {
        public int PostId { get; set; }
        public int ReactedBy { get; set; }
        public int Id { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual Account ReactedByNavigation { get; set; } = null!;
    }
}

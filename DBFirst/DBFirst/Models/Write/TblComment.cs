using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirst.Models.Write
{
    public partial class TblComment
    {
        public int IntCommentId { get; set; }
        public string StrCommentDescription { get; set; }
        public int IntUserId { get; set; }
        public int IntPostId { get; set; }

        public virtual TblPost IntPost { get; set; }
    }
}

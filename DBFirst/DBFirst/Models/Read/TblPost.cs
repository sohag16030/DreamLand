using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirst.Models.Read
{
    public partial class TblPost
    {
        public TblPost()
        {
            TblComment = new HashSet<TblComment>();
        }

        public int IntPostId { get; set; }
        public string StrPostDescription { get; set; }
        public int IntUserId { get; set; }

        public virtual ICollection<TblComment> TblComment { get; set; }
    }
}

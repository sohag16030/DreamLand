using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirst.Models.Write
{
    public partial class TblPost
    {
        public TblPost()
        {
            TblComment = new HashSet<TblComment>();
            TblLike = new HashSet<TblLike>();
        }

        public int IntPostId { get; set; }
        public string StrPostDescription { get; set; }
        public int IntUserId { get; set; }

        public virtual TblUser IntUser { get; set; }
        public virtual ICollection<TblComment> TblComment { get; set; }
        public virtual ICollection<TblLike> TblLike { get; set; }
    }
}

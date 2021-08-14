using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirst.Models.Read
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblComment = new HashSet<TblComment>();
            TblLike = new HashSet<TblLike>();
            TblPost = new HashSet<TblPost>();
        }

        public int IntUserId { get; set; }
        public string StrUserName { get; set; }

        public virtual ICollection<TblComment> TblComment { get; set; }
        public virtual ICollection<TblLike> TblLike { get; set; }
        public virtual ICollection<TblPost> TblPost { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirst.Models.Write
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblLike = new HashSet<TblLike>();
        }

        public int IntUserId { get; set; }
        public string StrUserName { get; set; }

        public virtual ICollection<TblLike> TblLike { get; set; }
    }
}

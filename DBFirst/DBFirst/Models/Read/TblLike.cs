using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirst.Models.Read
{
    public partial class TblLike
    {
        public int IntLikeId { get; set; }
        public int IntUserId { get; set; }

        public virtual TblUser IntUser { get; set; }
    }
}

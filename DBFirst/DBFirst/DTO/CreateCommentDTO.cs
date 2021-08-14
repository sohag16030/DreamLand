using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.DTO
{
    public class CreateCommentDTO
    {
        public string CommentDescription { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}

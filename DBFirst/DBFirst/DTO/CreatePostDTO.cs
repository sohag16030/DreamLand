using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.DTO
{
    public class CreatePostDTO
    {
        public int PostId { get; set; }
        public string PostDescription { get; set; }
        public int UserId { get; set; }
    }
}

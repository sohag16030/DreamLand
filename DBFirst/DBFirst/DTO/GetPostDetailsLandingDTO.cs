using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.DTO
{
    public class GetPostDetailsLandingDTO
    {
        public long SL { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long PostId { get; set; }
        public string PostDescription { get; set; }
        public long Like { get; set; }
        public long comment { get; set; }
    }
}

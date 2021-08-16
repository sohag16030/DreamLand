using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.DTO
{
    public class PostDetailLandingPagination
    {
        public List<GetPostDetailsLandingDTO> data { get; set; }
        public long currentPage { get; set; }
        public long totalCount { get; set; }
        public long pageSize { get; set; }
    }
}

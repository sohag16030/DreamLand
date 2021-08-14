using DBFirst.DTO;
using DBFirst.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.IRepository
{
    public interface IPost
    {
        public Task<MessageHelper> CreatePost(CreatePostDTO objCreate);
    }
}

using DBFirst.DbContexts;
using DBFirst.DTO;
using DBFirst.Helper;
using DBFirst.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.Repository
{
    public class Post : IPost
    {
        public readonly ReadDbContext _contextR;
        public readonly WriteDbContext _contextW;
        public Post(ReadDbContext contextR, WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }
        public async Task<MessageHelper> CreatePost(CreatePostDTO objCreate)
        {
            var postObj = new Models.Write.TblPost
            {

                StrPostDescription = objCreate.PostDescription,
                IntUserId = objCreate.UserId
            };

            await _contextW.TblPost.AddAsync(postObj);
            await _contextW.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "Post Created Successfully";
            msg.statuscode = 200;

            return msg;
        }
    }
}

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
    public class Comment : IComment
    {
        public readonly ReadDbContext _contextR;
        public readonly WriteDbContext _contextW;
        public Comment(ReadDbContext contextR, WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }

        public async Task<MessageHelper> CreateComment(CreateCommentDTO objCreate)
        {
            var commObj = new Models.Write.TblComment
            {

                IntUserId = objCreate.UserId,
                IntPostId = objCreate.PostId
            };

            await _contextW.TblComment.AddAsync(commObj);
            await _contextW.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "Commented in a  Post Successfully";
            msg.statuscode = 200;

            return msg;
        }
    }
}

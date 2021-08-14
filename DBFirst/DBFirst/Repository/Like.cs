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
    public class Like : ILike
    {
        public readonly ReadDbContext _contextR;
        public readonly WriteDbContext _contextW;
        public Like(ReadDbContext contextR, WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }
        public async Task<MessageHelper> CreateLike(CreateLikeDTO objCreate)
        {
            var likeObj = new Models.Write.TblLike
            {

                IntLikeId = objCreate.LikeId,
                IntUserId = objCreate.UserId,
                IntPostId = objCreate.PostId
            };

            await _contextW.TblLike.AddAsync(likeObj);
            await _contextW.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "Liked Post Successfully";
            msg.statuscode = 200;

            return msg;
        }
    }
}

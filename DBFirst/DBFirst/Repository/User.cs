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
    public class User : IUser
    {
        public readonly ReadDbContext _contextR;
        public readonly WriteDbContext _contextW;
        public User(ReadDbContext contextR, WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }
        public async Task<MessageHelper> CreateUser(CreateUserDTO objCreate)
        {

            var userObj = new Models.Write.TblUser
            {
                StrUserName = objCreate.UserName
            };

            await _contextW.TblUser.AddAsync(userObj);
            await _contextW.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "User Created Successfully";
            msg.statuscode = 200;

            return msg;
        }

        public async Task<PostDetailLandingPagination> PostDetailLandingPasignation(string search, long PageNo, long PageSize, string viewOrder)
        {
            IQueryable<GetPostDetailsLandingDTO> data = await Task.FromResult(from u in _contextR.TblUser
                                                                              join p in _contextR.TblPost on u.IntUserId equals p.IntPostId

                                                                              where (search == null || u.StrUserName.ToLower().Contains(search.ToLower()))
                                                                              select new GetPostDetailsLandingDTO
                                                                              {
                                                                                  UserId = u.IntUserId,
                                                                                  UserName = u.StrUserName,
                                                                                  PostId = (from a in _contextR.TblPost where a.IntUserId == u.IntUserId select a.IntPostId).FirstOrDefault(),
                                                                                  PostDescription = (from a in _contextR.TblPost where a.IntUserId == u.IntUserId select a.StrPostDescription).FirstOrDefault(),
                                                                                  Like = (from a in _contextR.TblLike where a.IntPostId == p.IntPostId select a.IntLikeId).Count(),
                                                                                  comment = (from a in _contextR.TblComment where a.IntPostId == p.IntPostId select a.IntCommentId).Count()
                                                                              });

            PostDetailLandingPagination itm = new PostDetailLandingPagination();

            if (data == null)
                throw new Exception("Data Not Found");

            else
            {
                if (viewOrder.ToUpper() == "ASC")
                    data = data.OrderBy(o => o.UserId);
                else if (viewOrder.ToUpper() == "DESC")
                    data = data.OrderByDescending(o => o.UserId);
            }

            if (PageNo <= 0)
                PageNo = 1;
            var itemdata = PagingList<GetPostDetailsLandingDTO>.CreateAsync(data, PageNo, PageSize);

            long index = (int)(1 + ((PageNo - 1) * PageSize));
            foreach (var itms in itemdata)
            {
                itms.SL = index++;
            }

            itm.data = itemdata;
            itm.currentPage = PageNo;
            itm.totalCount = data.Count();
            itm.pageSize = PageSize;

            return itm;

        }
    }
}

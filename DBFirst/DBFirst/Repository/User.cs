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
            msg.Message = "Zone Created Successfully";
            msg.statuscode = 200;

            return msg;
        }
    }
}

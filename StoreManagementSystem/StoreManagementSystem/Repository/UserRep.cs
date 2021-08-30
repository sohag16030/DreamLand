using StoreManagementSystem.DbContexts;
using StoreManagementSystem.Helper;
using StoreManagementSystem.IRepository;
using StoreManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Repository
{
    public class UserRep : IUser
    {
        private readonly MyDbContext _context;
        public UserRep(MyDbContext context)
        {
            _context = context;
        }
        public async Task<MessageHelper> AddUser(User objCreate)
        {
            var count = _context.Users.Where(x => x.UserName.Trim().ToLower() == objCreate.UserName.Trim().ToLower() && x.UserId != objCreate.UserId).Count();
            if (count > 0)
                throw new Exception($"{objCreate.UserName}User exist");

            var userObj = new Models.User
            {
                UserName = objCreate.UserName,
                UserRole = objCreate.UserRole,
                Active = true,
                LastActionDateTime = DateTime.UtcNow
            };

            await _context.Users.AddAsync(userObj);
            await _context.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "User Created Successfully";
            msg.statuscode = 200;

            return msg;
        }

        public Task<MessageHelper> DeActivateUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageHelper> EditUser(User model)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoadUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}

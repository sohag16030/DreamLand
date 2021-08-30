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
            if(objCreate.Password != objCreate.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password Doesn't match");
            }

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

        public async Task<MessageHelper> DeActivateUser(int id)
        {
            var exitUser = await Task.FromResult((from a in _context.Users where a.UserId == id select a).FirstOrDefault());

            exitUser.Active = false;

            _context.Users.Update(exitUser);
            _context.SaveChanges();

            var msg = new MessageHelper();
            msg.Message = "Deleted successfully";
            msg.statuscode = 200;
            return msg;
        }

        public async Task<MessageHelper> EditUser(User model)
        {
            var countExUser = _context.Users.Where(x => x.UserName.Trim().ToLower() == model.UserName.Trim().ToLower() && x.UserId != model.UserId).Count();
            if (countExUser > 0)
                throw new Exception($"{model.UserName}User exist");


            var exitUser = await Task.FromResult((from a in _context.Users where a.UserId == model.UserId select a).FirstOrDefault());
            exitUser.UserName = model.UserName;


            _context.Users.Update(exitUser);
            _context.SaveChanges();

            var msg = new MessageHelper();
            msg.Message = "updated successfully";
            msg.statuscode = 200;
            return msg;
        }

        public async Task<User> LoadUser(int id)
        {
            var product = await Task.FromResult((from a in _context.Users where id == a.UserId && a.Active == true select a).FirstOrDefault());
            return product;
        }
    }
}

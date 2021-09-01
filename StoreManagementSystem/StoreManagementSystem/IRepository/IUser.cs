using StoreManagementSystem.Helper;
using StoreManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.IRepository
{
    public interface IUser
    {
        public Task<MessageHelper> Login(User objLogin);
        public Task<MessageHelper> AddUser(User objCreate);
        public Task<User> LoadUser(int id);
        public Task<MessageHelper> EditUser(User model);
        public Task<MessageHelper> EditInactiveUser(User model);
        public Task<MessageHelper> DeActivateUser(int id);
    }
}

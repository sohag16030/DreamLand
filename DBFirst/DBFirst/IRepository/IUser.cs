using DBFirst.DTO;
using DBFirst.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.IRepository
{
    public interface IUser
    {
        public Task<MessageHelper> CreateUser(CreateUserDTO objCreate);
        public Task<PostDetailLandingPagination> PostDetailLandingPasignation(string search, long PageNo, long PageSize, string viewOrder);

    }
}

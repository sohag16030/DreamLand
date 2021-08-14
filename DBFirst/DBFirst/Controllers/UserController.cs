using DBFirst.DTO;
using DBFirst.Helper;
using DBFirst.IRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.Controllers
{

    [Route("Blog/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _IRepository;
        public UserController(IUser IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpPost]
        [Route("CreateOrEditUser")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> CreateOrEditUser(CreateUserDTO create)
        {
            try
            {
                var msg = await _IRepository.CreateUser(create);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

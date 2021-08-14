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
    public class PostController : Controller
    {
        private readonly IPost _IRepository;
        public PostController(IPost IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpPost]
        [Route("CreateOrEditPost")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> CreateOrEditPost(CreatePostDTO create)
        {
            try
            {
                var msg = await _IRepository.CreatePost(create);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

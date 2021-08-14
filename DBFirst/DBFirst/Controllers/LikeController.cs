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
    public class LikeController : Controller
    {
        private readonly ILike _IRepository;
        public LikeController(ILike IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpPost]
        [Route("CreateOrEditLike")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> CreateOrEditLike(CreateLikeDTO create)
        {
            try
            {
                var msg = await _IRepository.CreateLike(create);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

﻿using DBFirst.DTO;
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
    public class CommentController : Controller
    {
        private readonly IComment _IRepository;
        public CommentController(IComment IRepository)
        {
            _IRepository = IRepository;
        }
        [HttpGet]
        [Route("Weather")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> Weather(string City)
        {
            try
            {
                //var msg = "hello";
                return new MessageHelper();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("CreateOrEditComment")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<MessageHelper> CreateOrEditComment(CreateCommentDTO create)
        {
            try
            {
                var msg = await _IRepository.CreateComment(create);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

using DBFirst.DbContexts;
using DBFirst.DTO;
using DBFirst.Helper;
using DBFirst.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DBFirst.Repository
{
    public class Comment : IComment
    {
        public readonly ReadDbContext _contextR;
        public readonly WriteDbContext _contextW;
        public Comment(ReadDbContext contextR, WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }

        public async Task<MessageHelper> CreateComment(CreateCommentDTO objCreate)
        {
            var commObj = new Models.Write.TblComment
            {
                StrCommentDescription = objCreate.CommentDescription,
                IntUserId = objCreate.UserId,
                IntPostId = objCreate.PostId
            };

            await _contextW.TblComment.AddAsync(commObj);
            await _contextW.SaveChangesAsync();

            var msg = new MessageHelper();
            msg.Message = "Commented in a  Post Successfully";
            msg.statuscode = 200;

            return msg;
        }

        public async Task<GetWeatherInfoDTO> GetWeatherInfoDTO(string cityName)
        {
            using (var client = new HttpClient())
            {
                var url = new Url($"http://api.openweathermap.org/data/2.5/weather?q=Dhaka&appid=e035ca5c00b6f72b3e2447c49dd92c57");
                var response = await client.GetAsync(url);

            }
            var obj = new GetWeatherInfoDTO();
            //return obj;
        }
    }
}

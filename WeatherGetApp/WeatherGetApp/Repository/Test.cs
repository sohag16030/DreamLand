using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherGetApp.DTO;
using WeatherGetApp.IRepository;

namespace WeatherGetApp.Repository
{
    public class Test : ITest
    {
        public async Task<WeatherCommonDTO> GetWeatherInfo(string cityName)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"http://api.openweathermap.org/data/2.5/weather?q=Dhaka&appid=e035ca5c00b6f72b3e2447c49dd92c57");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                var obj =  JsonConvert.DeserializeObject<WeatherCommonDTO>(json);
                return JsonConvert.DeserializeObject<WeatherCommonDTO>(json);
            }
        }
    }
}

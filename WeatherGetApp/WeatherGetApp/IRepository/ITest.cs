using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherGetApp.DTO;

namespace WeatherGetApp.IRepository
{
    public interface ITest 
    {
        Task<WeatherCommonDTO> GetWeatherInfo(string cityName);
    }
}

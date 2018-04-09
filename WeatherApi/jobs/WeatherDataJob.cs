using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Quartz;
using WeatherForcastLib.Service;

namespace WeatherApi.jobs
{
    public class WeatherDataJob:IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            WeatherSevice seviceWeather =new WeatherSevice();
            seviceWeather.StoreDataWeather("9000","BE");
            return null;
        }
    }
}
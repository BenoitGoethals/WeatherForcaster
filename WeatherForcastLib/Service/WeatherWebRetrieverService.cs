using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;
using WeatherForcastLib.Util;

namespace WeatherForcastLib.Service
{
    public class WeatherWebRetrieverService
    {
      
        public  WeatherStatics GetWeatherBulkNow(List<string> datas, string country)
        {
            WeatherStatics weatherStatics = new WeatherStatics();

            foreach (var dataCity in datas)
            {
                 var dataFromUrlByZipCode =   RestWeatherForcastUtil.GetDataFromUrlByZipCode(dataCity, country).Result;
                if(dataFromUrlByZipCode!=null)
                {
                    weatherStatics.Add(new WeatherData(dataFromUrlByZipCode));
                }
            }
            return weatherStatics;
        }

        public WeatherStatics Get_weatherStaticsrNow(string postCode, string country)
        {
             WeatherStatics weatherStatics = new WeatherStatics();
            weatherStatics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode(postCode, country).Result));
            return weatherStatics;
        }


        public WeatherData GetWeatherDataNow(string postCode, string country)
        {
            return new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode(postCode, country).Result);
        }

    }
}
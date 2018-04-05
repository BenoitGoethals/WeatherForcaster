using System.Collections.Generic;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;
using WeatherForcastLib.Util;

namespace WeatherForcastLib.Service
{
    public class WeatherService
    {
      

        public WeatherData GetWeatherNow()
        {
            return null;
        }

        public WeatherData GetWeatherBulkNow()
        {
            return null;
        }

        public List<WeatherData> GetWeatherBulkNow(string postCode, string country)
        {
            return null;
        }

        public WeatherStatics Get_weatherStaticsrNow(string postCode, string country)
        {
             WeatherStatics _weatherStatics = new WeatherStatics();
        _weatherStatics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode(postCode, country)));
            return _weatherStatics;
        }


        public WeatherData GetWeatherDataNow(string postCode, string country)
        {
            return new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode(postCode, country));
        }

    }
}
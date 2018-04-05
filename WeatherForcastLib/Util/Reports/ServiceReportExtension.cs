using System.Runtime.CompilerServices;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;
using WeatherForcastLib.Service;

namespace WeatherForcastLib.Util.Reports
{
    public static class ServiceReportExtension
    {
        private static ReportCreator creator = new ReportCreator();



        public static void CreateReport(this WeatherStatics weather)
        {

            //   creator.CreateReport(new CurrentWeatherReport(weatherData: weather.AllWeatherDatas()));
        }


        public static void CreateReport(this  WeatherData weather)
        {
            creator.CreateReport(new CurrentWeatherReport(weather));
        }


    }
}

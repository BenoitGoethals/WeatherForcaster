using System.Runtime.CompilerServices;
using WeatherFocastCommonClassLibrary;
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

               creator.CreateReport(new CurrentWeatherFromAllCity(weather));
        }


        public static void CreateReport(this  WeatherData weather)
        {
            creator.CreateReport(new CurrentWeatherReport(weather));
        }


    }
}

using System;
using WeatherForcastLib.Util.Reports;

namespace WeatherForcastLib.Util
{
    public class CurrentWeatherReport : Report, ICurrentWeatherReport
    {
        public CurrentWeatherReport()
        {
            base.CurrentWeatherReport = this;
        }
        public void MakeHeather()
        {
            
        }

        public void MakBody()
        {
            Console.WriteLine("body");
        }


        public void MakeFooter()
        {
            Console.WriteLine("MakeFooter");
        }

    }
}
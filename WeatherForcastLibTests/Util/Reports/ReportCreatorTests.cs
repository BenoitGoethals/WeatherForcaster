using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForcastLib.Model;
using WeatherForcastLib.Util.Reports;

namespace WeatherForcastLibTests.Util.Reports
{
    [TestClass()]
    public class ReportCreatorTests
    {
        [TestMethod()]
        public void CreateReportTest()
        {
            ReportCreator creator=new ReportCreator();
            creator.CreateReport(new CurrentWeatherReport(
                new WeatherData()
                {
                    Country = "BE",
                    Temperature = 12.5,
                    Speed = 10.2,
                    City = "Ghent",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(5)

                }));
            
        }


        [TestMethod()]
        public void CreateReportBulkTest()
        {
            ReportCreator creator = new ReportCreator();
            creator.CreateReport(new CurrentWeatherFromAllCity(GetDatas()));

        }



        private List<WeatherData> GetDatas()
        {
            List<WeatherData> datas = new List<WeatherData>()
            {
                new WeatherData()
                {
                    Country = "BE",
                    Temperature = 12.5,
                    Speed = 10.2,
                    City = "Ghent",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now

                },
                new WeatherData()
                {
                    Country = "BE",
                    Temperature = 12.5,
                    Speed = 10.2,
                    City = "Ghent",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(5)

                },
                new WeatherData()
                {
                    Country = "BE",
                    Temperature = 13,
                    Speed = 10.2,
                    City = "Ghent",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(6)

                },
                new WeatherData()
                {
                    Country = "BE",
                    Temperature = 14,
                    Speed = 10.2,
                    City = "Ghent",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(7)

                },
                new WeatherData()
                {
                    Country = "BE",
                    Temperature = 12,
                    Speed = 10.2,
                    City = "Ostend",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(1)

                },new WeatherData()
                {
                    Country = "BE",
                    Temperature = 12.5,
                    Speed = 10.2,
                    City = "Ostend",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(2)

                }
                ,new WeatherData()
                {
                    Country = "BE",
                    Temperature = 15.5,
                    Speed = 10.2,
                    City = "Ostend",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(3)

                }
                ,new WeatherData()
                {
                    Country = "BE",
                    Temperature = 12.5,
                    Speed = 10.2,
                    City = "Ostend",
                    Pressure = 12,
                    WindSpeed = 5,
                    Id = Guid.NewGuid(),
                    Humidty = 5,
                    WindDirection = "NE",
                    UpdateWeather = DateTime.Now.AddHours(4)

                }


            };





            return datas;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;
using WeatherForcastLib.Repos;
using WeatherForcastLib.Service;
using WeatherForcastLib.Util.Reports;

namespace WeatherForcastLibTests.Service
{
    [TestClass()]
    public class WeatherServiceTests
    {
        [TestMethod()]
        public void GetWeatherNowTest()
        {
            WeatherWebRetrieverService webRetrieverService=new WeatherWebRetrieverService();
           
            webRetrieverService.GetWeatherDataNow("9000", "BE");//.CreateReport();
            Assert.IsNotNull(webRetrieverService.GetWeatherDataNow("9000", "BE"));
        }



        [TestMethod()]
        public void GetWeatherBulkNowTest()
        {
            WeatherWebRetrieverService webRetrieverService = new WeatherWebRetrieverService();

            WeatherStatics statics = webRetrieverService.GetWeatherBulkNow(CityRepo.Cities().Take(5).ToList(), "BE");
      //      statics.CreateReport();
            Assert.AreEqual(4,statics.AllWeatherDatas().Count);

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
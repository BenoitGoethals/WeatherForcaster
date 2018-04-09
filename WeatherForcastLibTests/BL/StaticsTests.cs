using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;
using WeatherForcastLib.Repos;
using WeatherForcastLib.Util;

namespace WeatherForcastLibTests.BL
{
    [TestClass()]
    public class StaticsTests
    {
        [TestMethod()]
        public void AddTest()
        {
          
            WeatherStatics weatherStatics=new WeatherStatics();
            weatherStatics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1,weatherStatics.AllWeatherDatas().Count);
        }

        [TestMethod()]
        public void AddBulkTest()
        {

            WeatherStatics weatherStatics = new WeatherStatics();
            foreach (var city in CityRepo.Cities().Take(5))
            {
                Current current= RestWeatherForcastUtil.GetDataFromUrlByZipCode(city, "BE");
                if (current != null)
                {
                    weatherStatics.Add(new WeatherData(current));
                }
          
            }
         
            Assert.AreEqual(4,weatherStatics.AllWeatherDatas().Count);
        }

        [TestMethod()]
        public void GetMaxTempTest()
        {
            WeatherStatics weatherStatics = new WeatherStatics();
            foreach (var data in GetDatas())
            {
                weatherStatics.Add(data);
            }
            
            Assert.AreEqual(8, weatherStatics.AllWeatherDatas().Count);
            Assert.AreEqual(14,weatherStatics.GetMaxTemp("Ghent").Temperature);
        }

        [TestMethod()]
        public void GetMaxTempAllTest()
        {
            WeatherStatics weatherStatics = new WeatherStatics();
            foreach (var data in GetDatas())
            {
                weatherStatics.Add(data);
            }
            Assert.AreEqual(8, weatherStatics.AllWeatherDatas().Count);
            Assert.AreEqual(15.5,weatherStatics.GetMaxTemp());
        }


        [TestMethod()]
        public void GetAverageTest()
        {
            WeatherStatics weatherStatics = new WeatherStatics();
            foreach (var data in GetDatas())
            {
                weatherStatics.Add(data);
            }
            Assert.AreEqual(8, weatherStatics.AllWeatherDatas().Count);
            Assert.AreEqual(13,weatherStatics.GetAverage("Ghent"));
        }

        [TestMethod()]
        public void GetAverageTestAll()
        {
            WeatherStatics weatherStatics = new WeatherStatics();
            foreach (var data in GetDatas())
            {
                weatherStatics.Add(data);
            }
            Assert.AreEqual(8, weatherStatics.AllWeatherDatas().Count);
            Assert.AreEqual(13.0625, weatherStatics.GetAverage());
        }

        [TestMethod()]
        public void GetMinTest()
        {
            WeatherStatics weatherStatics = new WeatherStatics();
            foreach (var data in GetDatas())
            {
                weatherStatics.Add(data);
            }
            Assert.AreEqual(8, weatherStatics.AllWeatherDatas().Count);
            Assert.AreEqual(12.5, weatherStatics.GetMin("Ghent").Temperature);
        }

        [TestMethod()]
        public void GetMinTestAll()
        {
            WeatherStatics weatherStatics = new WeatherStatics();
            foreach (var data in GetDatas())
            {
                weatherStatics.Add(data);
            }
            Assert.AreEqual(8, weatherStatics.AllWeatherDatas().Count);
            Assert.AreEqual(12, weatherStatics.GetMin());
        }


        private List<WeatherData> GetDatas()
        {
            List<WeatherData> datas =new List<WeatherData>()
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
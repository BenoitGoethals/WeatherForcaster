using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
          
            Statics statics=new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1,statics.AllWeatherDatas().Count);
        }

        [TestMethod()]
        public void AddBulkTest()
        {

            Statics statics = new Statics();
            foreach (var city in CityRepo.Cities().Take(5))
            {
                Current current= RestWeatherForcastUtil.GetDataFromUrlByZipCode(city, "BE");
                if (current != null)
                {
                    statics.Add(new WeatherData(current));
                }
          
            }
         
            Assert.AreEqual(4,statics.AllWeatherDatas().Count);
        }

        [TestMethod()]
        public void GetMaxTempTest()
        {
            Statics statics = new Statics();
            foreach (var data in GetDatas())
            {
                statics.Add(data);
            }
            
            Assert.AreEqual(8, statics.AllWeatherDatas().Count);
            Assert.AreEqual(14,statics.GetMaxTemp("Ghent").Temperature);
        }

        [TestMethod()]
        public void GetMaxTempAllTest()
        {
            Statics statics = new Statics();
            foreach (var data in GetDatas())
            {
                statics.Add(data);
            }
            Assert.AreEqual(8, statics.AllWeatherDatas().Count);
            Assert.AreEqual(15.5,statics.GetMaxTemp());
        }


        [TestMethod()]
        public void GetAverageTest()
        {
            Statics statics = new Statics();
            foreach (var data in GetDatas())
            {
                statics.Add(data);
            }
            Assert.AreEqual(8, statics.AllWeatherDatas().Count);
            Assert.AreEqual(13,statics.GetAverage("Ghent"));
        }

        [TestMethod()]
        public void GetAverageTestAll()
        {
            Statics statics = new Statics();
            foreach (var data in GetDatas())
            {
                statics.Add(data);
            }
            Assert.AreEqual(8, statics.AllWeatherDatas().Count);
            Assert.AreEqual(13.0625, statics.GetAverage());
        }

        [TestMethod()]
        public void GetMinTest()
        {
            Statics statics = new Statics();
            foreach (var data in GetDatas())
            {
                statics.Add(data);
            }
            Assert.AreEqual(8, statics.AllWeatherDatas().Count);
            Assert.AreEqual(12.5, statics.GetMin("Ghent").Temperature);
        }

        [TestMethod()]
        public void GetMinTestAll()
        {
            Statics statics = new Statics();
            foreach (var data in GetDatas())
            {
                statics.Add(data);
            }
            Assert.AreEqual(8, statics.AllWeatherDatas().Count);
            Assert.AreEqual(12, statics.GetMin());
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
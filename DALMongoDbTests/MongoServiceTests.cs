using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DALMongoDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.Model;

namespace DALMongoDbTests
{
    [TestClass()]
    public class MongoServiceTests
    {
        [TestMethod()]
        public void GetDataTest()
        {
            MongoDbUtil.Instance().Drop();
            MongoService service = new MongoService();
            service.AddBulk(GetDatas().ToArray());

            Assert.IsTrue(service.GetWeatherStatics().AllWeatherDatas().Count()==8);
        }



        [TestMethod()]
        public void AddTest()
        {
            MongoService service = new MongoService();
            MongoDbUtil.Instance().Drop();
            service.Add(new WeatherData()
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

            });
            Assert.IsTrue(service.GetWeatherDatas().Count() == 1);
        }

        [TestMethod()]
        public void GetWeatherStaticsTest()
        {
            MongoService service = new MongoService();
            MongoDbUtil.Instance().Drop();
            service.AddBulk(GetDatas().ToArray());
            Assert.IsTrue(service.GetWeatherStatics().AllWeatherDatas().Count > 1);

        }

        [TestMethod()]
        public void GetListOfWeatherkTest()
        {
            MongoService service = new MongoService();
            MongoDbUtil.Instance().Drop();
            service.AddBulk(GetDatas().ToArray());
            Assert.IsTrue(service.GetWeatherDatas().Count() == 8);

        }

        private IEnumerable<WeatherData> GetDatas()
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

                },
                new WeatherData()
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

                },
                new WeatherData()
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

                },
                new WeatherData()
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
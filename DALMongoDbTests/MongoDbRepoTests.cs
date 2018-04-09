using System;
using System.Collections.Generic;
using System.Linq;
using DALMongoDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.Model;


namespace DALMongoDbTests
{
    [TestClass()]
    public class MongoDbRepoTests
    {
        [TestMethod()]
        public void AddBulkTest()
        {
           MongoDbWeatherDataRepo service=new MongoDbWeatherDataRepo();
            service.Drop();
            service.AddBulk(GetDatas().ToArray());
            Assert.IsTrue(service.GetWeatherDatas().Count()>1);
          
        }


        [TestMethod()]
        public void AddTest()
        {
            MongoDbWeatherDataRepo service = new MongoDbWeatherDataRepo();
            service.Drop();
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
            Assert.IsTrue(service.GetWeatherDatas().Count() ==1);
        }

        [TestMethod()]
        public void GetWeatherStaticsTest()
        {
            MongoDbWeatherDataRepo service = new MongoDbWeatherDataRepo();
            service.Drop();
            service.AddBulk(GetDatas().ToArray());
            Assert.IsTrue(service.GetWeatherStatics().AllWeatherDatas().Count>1);

        }

        [TestMethod()]
        public void GetListOfWeatherkTest()
        {
            MongoDbWeatherDataRepo service = new MongoDbWeatherDataRepo();
            service.Drop();
            service.AddBulk(GetDatas().ToArray());
            Assert.IsTrue(service.GetWeatherDatas().Count()==8);

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
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.Model;
using WeatherForcastLib.Repos;
using WeatherForcastLib.Service;

namespace WeatherForcastLibTests.Service
{
    [TestClass()]
    public class WeatherSeviceTests
    {
        [TestMethod()]
        public void StoreDataWeatherTest()
        {
            MongoDbUtil.Instance().Drop();
            WeatherSevice sevice=new WeatherSevice();
            sevice.StoreDataWeather("9000","BE");
            Assert.IsTrue(sevice.GetWeatherDatas().Count()==1);
        }


        [TestMethod()]
        public void StoreDataWeatherStaticsTest()
        {
            MongoDbUtil.Instance().Drop();
            WeatherSevice sevice = new WeatherSevice();
           sevice.StoreDataWeather( CityRepo.Cities().Take(5).ToList(), "BE");
            sevice.GetWeatherStatics();
            Assert.IsTrue(sevice.GetWeatherStatics().AllWeatherDatas().Count() == 4);
        }

       
    }
}
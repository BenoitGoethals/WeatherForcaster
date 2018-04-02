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
            Assert.AreEqual(1,statics.GetAllCity().Count);
        }

        [TestMethod()]
        public void AddBulkTest()
        {

            Statics statics = new Statics();
            foreach (var city in CityRepo.Cities().Take(3))
            {
                Current current= RestWeatherForcastUtil.GetDataFromUrlByZipCode(city, "BE");
                if (current != null)
                {
                    statics.Add(new WeatherData(current));
                }
          
            }
         
            Assert.IsNotNull(statics.GetAllCity());
        }

        [TestMethod()]
        public void GetMaxTempTest()
        {
            Statics statics = new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1, statics.GetAllCity().Count);
            Assert.IsNotNull(statics.GetMaxTemp("9000"));
        }

        [TestMethod()]
        public void GetMaxTempTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAverageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAverageTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMinTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMinTest1()
        {
            Assert.Fail();
        }

    }
}
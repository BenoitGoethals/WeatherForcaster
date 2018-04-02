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
            foreach (var city in CityRepo.Cities().Take(5))
            {
                Current current= RestWeatherForcastUtil.GetDataFromUrlByZipCode(city, "BE");
                if (current != null)
                {
                    statics.Add(new WeatherData(current));
                }
          
            }
         
            Assert.AreEqual(4,statics.GetAllCity().Count);
        }

        [TestMethod()]
        public void GetMaxTempTest()
        {
            Statics statics = new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1, statics.GetAllCity().Count);
            Assert.IsNotNull(statics.GetMaxTemp("Ghent"));
        }

        [TestMethod()]
        public void GetMaxTempAllTest()
        {
            Statics statics = new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1, statics.GetAllCity().Count);
            Assert.IsNotNull(statics.GetMaxTemp());
        }


        [TestMethod()]
        public void GetAverageTest()
        {
            Statics statics = new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1, statics.GetAllCity().Count);
            Assert.IsNotNull(statics.GetAverage("Ghent"));
        }

        [TestMethod()]
        public void GetAverageTestAll()
        {
            Statics statics = new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1, statics.GetAllCity().Count);
            Assert.IsNotNull(statics.GetAverage());
        }

        [TestMethod()]
        public void GetMinTest()
        {
            Statics statics = new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1, statics.GetAllCity().Count);
            Assert.IsNotNull(statics.GetAverage("Ghent"));
        }

        [TestMethod()]
        public void GetMinTestAll()
        {
            Statics statics = new Statics();
            statics.Add(new WeatherData(RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000", "BE")));
            Assert.AreEqual(1, statics.GetAllCity().Count);
            Assert.IsNotNull(statics.GetMin());
        }

    }
}
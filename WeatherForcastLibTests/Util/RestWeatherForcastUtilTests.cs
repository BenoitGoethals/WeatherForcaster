using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForcastLib.Util;

namespace WeatherForcastLibTests.Util
{
    [TestClass()]
    public class RestWeatherForcastUtilTests
    {
        [TestMethod()]
        public void GetDataFromUrlByZipCodeTest()
        {
            Assert.AreEqual("Ghent",RestWeatherForcastUtil.GetDataFromUrlByZipCode("9000","be").Result.City.Name);
        }



        [TestMethod()]
        public void GetDataBadFromUrlByZipCodeTest()
        {
            Assert.IsNull(RestWeatherForcastUtil.GetDataFromUrlByZipCode("1111", "zz"));
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForcastLib.Repos;

namespace WeatherForcastLibTests.Repos
{
    [TestClass()]
    public class CityRepoTests
    {
        [TestMethod()]
        public void CitiesTest()
        {
          
           Assert.IsNotNull(CityRepo.Cities().Count>5);
            Assert.IsNotNull(CityRepo.Cities().Contains("9880"));
        }
    }
}
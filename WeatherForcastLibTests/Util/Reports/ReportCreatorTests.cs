using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForcastLib.Util.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForcastLib.Util.Reports.Tests
{
    [TestClass()]
    public class ReportCreatorTests
    {
        [TestMethod()]
        public void CreateReportTest()
        {
            ReportCreator creator=new ReportCreator();
            creator.CreateReport(new CurrentWeatherReport());
            
        }
    }
}
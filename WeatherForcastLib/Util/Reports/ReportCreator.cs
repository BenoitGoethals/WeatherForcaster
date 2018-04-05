using System;

namespace WeatherForcastLib.Util.Reports
{
    public class ReportCreator
    {

        private static readonly log4net.ILog log
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void CreateReport(Report report)
        {
            try
            {
                report.Generate();
                log.Info("report created "+ report);
            }
            catch (Exception e)
            {
                log.Error("report created "+e.InnerException);
                throw;
            }
           
        }
    }
}
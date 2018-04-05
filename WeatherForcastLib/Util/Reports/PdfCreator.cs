using System.ComponentModel;
using WeatherForcastLib.Util.Reports;

namespace WeatherForcastLib.BL
{
    public class PdfCreator
    {
        private static PdfCreator instance=new PdfCreator();
        private static ReportCreator creator = new ReportCreator();

        

        public static PdfCreator InstanceCreationEditor()
        {
            return instance;
        }
    }
}
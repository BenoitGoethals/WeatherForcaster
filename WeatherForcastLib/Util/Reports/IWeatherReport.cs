using iText.Layout;

namespace WeatherForcastLib.Util.Reports
{
    public interface IWeatherReport
    {
        void MakeHeather(Document document);
        void MakBody(Document document);
        void MakeFooter(Document document);
        string GetNameReport();
    }
}
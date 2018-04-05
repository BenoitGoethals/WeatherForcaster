using iText.IO.Font;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using WeatherForcastLib.Model;

namespace WeatherForcastLib.Util.Reports
{
    public class CurrentWeatherReport : Report, IWeatherReport
    {

        private PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

        private readonly WeatherData _weatherData;

        public CurrentWeatherReport(WeatherData weatherData)
        {
            this._weatherData = weatherData;
            base.WeatherReport = this;
        }


        public void MakeHeather(Document document)
        {


            document.Add(new Paragraph("Weather Data  is:").SetFont(font).SetBold().SetFontSize(20));
        }

        public void MakBody(Document document)
        {
            List list = new List().SetSymbolIndent(12).SetListSymbol("\u2022").SetFont(font);
            // Add ListItem objects
            list.Add(new ListItem($"City : {_weatherData.City}"))
                .Add(new ListItem($"Temperature : {_weatherData.Temperature}"))
                .Add(new ListItem($"WindSpeed :{_weatherData.WindSpeed}"))
                .Add(new ListItem($"Pressure : {_weatherData.Pressure}"))
                .Add(new ListItem($"WindDirection : {_weatherData.WindDirection}"))
                .Add(new ListItem($"UpdateWeatherDate : {_weatherData.UpdateWeather}"));

            document.Add(list);

          
        }

        public void MakeFooter(Document document)
        {
            document.Add(new Paragraph("----------------------------").SetFont(font));
        }

        public string GetNameReport()
        {
            return _weatherData.City + "CurrentWeatherReport" + _weatherData.UpdateWeather.Millisecond;
        }
    }
}
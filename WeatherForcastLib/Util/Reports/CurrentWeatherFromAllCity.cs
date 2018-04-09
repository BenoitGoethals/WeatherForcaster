using System;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using WeatherForcastLib.BL;

namespace WeatherForcastLib.Util.Reports
{
    public class CurrentWeatherFromAllCity : Report, IWeatherReport
    {

        private PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

        private readonly WeatherStatics _weatherData;

        public CurrentWeatherFromAllCity(WeatherStatics weatherData)
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
            foreach (var data in _weatherData.AllWeatherDatas())
            {
                
           
                List list = new List().SetSymbolIndent(12).SetListSymbol("\u2022").SetFont(font);
                // Add ListItem objects
                list.Add(new ListItem($"City : {data.City}")).SetBold()
                    .Add(new ListItem($"Temperature : {data.Temperature}"))
                    .Add(new ListItem($"WindSpeed :{data.WindSpeed}"))
                    .Add(new ListItem($"Pressure : {data.Pressure}"))
                    .Add(new ListItem($"WindDirection : {data.WindDirection}"))
                    .Add(new ListItem($"UpdateWeatherDate : {data.UpdateWeather}"));

                document.Add(list);
                document.Add(new Paragraph("----------------------------").SetFont(font));
            }

        }

        public void MakeFooter(Document document)
        {
            document.Add(new Paragraph("----------------------------").SetFont(font));
        }

        public string GetNameReport()
        {
            return  "CurrentWeatherFromAllCity" + DateTime.Now.Millisecond;
        }
    }
}